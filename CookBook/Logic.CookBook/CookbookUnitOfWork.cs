using Data.AppContext;
using Data.Models.Entities.CookBook;
using Data.Models.Entities.Logging;
using Data.Models.ExportModels.CookBook;
using Logic.CookBook.Extensions;
using Logic.CookBook.Interfaces;
using Logic.Shared;
using Logic.Shared.Interfaces;
using Logic.Shared.Models;

namespace Logic.CookBook
{
    public class CookbookUnitOfWork : ALogicBase, ICookBookUnitOfWork
    {
        private readonly AppDbContext _context;
        private IRepositoryBase<RecipeEntity>? _recipeRepository;
        private IRepositoryBase<CategoryEntity>? _categoryRepository;
        private IRepositoryBase<IngredientEntity>? _ingredientRepository;
        private IRepositoryBase<RecipeIngredientEntity>? _recipeIngredientRepository;
        private IRepositoryBase<UnitEntity>? _ingredientUnitRepository;

        public IRepositoryBase<RecipeEntity> RecipeRepository => _recipeRepository ?? new RepositoryBase<RecipeEntity>(_context);
        public IRepositoryBase<CategoryEntity> CategoryRepository => _categoryRepository ?? new RepositoryBase<CategoryEntity>(_context);
        public IRepositoryBase<IngredientEntity> IngredientRepository => _ingredientRepository ?? new RepositoryBase<IngredientEntity>(_context);
        public IRepositoryBase<RecipeIngredientEntity> RecipeIngredientRepository => _recipeIngredientRepository ?? new RepositoryBase<RecipeIngredientEntity>(_context);
        public IRepositoryBase<UnitEntity> IngredientUnitRepository => _ingredientUnitRepository ?? new RepositoryBase<UnitEntity>(_context);
        public CookbookUnitOfWork(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<RecipeModel>> GetRecipes(int? categoryId)
        {
            try
            {
                var models = new List<RecipeModel>();

                var recipes = await RecipeRepository.GetAllAsync(new DbQuery<RecipeEntity>
                {
                    AsNoTracking = true,
                    WhereExpression = categoryId != null ? x => x.FKCategoryId == categoryId : null
                });

                if (recipes.Any())
                {
                    foreach (var recipe in recipes)
                    {
                        var recipeIngredients = await RecipeIngredientRepository.GetAllAsync(new DbQuery<RecipeIngredientEntity>
                        {
                            AsNoTracking = true,
                            WhereExpression = x => x.RecipeId == recipe.RecipeId
                        });

                        var ingredients = new List<RecipeIngredientModel>();

                        var category = await CategoryRepository.GetFirstOrDefaultAsync(new DbQuery<CategoryEntity>
                        {
                            AsNoTracking = true,
                            WhereExpression = x => x.CategoryId == recipe.FKCategoryId
                        });

                        foreach (var ingredient in recipeIngredients)
                        {
                            var ingredentEntity = await IngredientRepository.GetFirstOrDefaultAsync(new DbQuery<IngredientEntity>
                            {
                                AsNoTracking = true,
                                WhereExpression = x => x.IngredientId == ingredient.IngredientId
                            });

                            var unit = await IngredientUnitRepository.GetFirstOrDefaultAsync(new DbQuery<UnitEntity>
                            {
                                AsNoTracking = true,
                                WhereExpression = x => x.UnitId == ingredient.UnitId
                            });

                            ingredients.Add(ingredient.ToUiModel(ingredentEntity?.Name, category?.ToUiModel(), new UnitModel { UnitId = unit.Id, Name = unit.Name }));

                        }

                        models.Add(recipe.ToUiModel(ingredients));
                    }
                }

                return models;
            }
            catch (Exception exception)
            {
                await LogError(new LogMessageEntity
                {
                    Message = "Could not load recipes from database!",
                    ExceptionMessage = exception.Message,
                    Stacktrace = exception.StackTrace ?? string.Empty,
                    TimeStamp = DateTime.Now,
                    Trigger = nameof(CookbookUnitOfWork)
                });

                return new List<RecipeModel>();
            }
        }

        public async Task<List<CategoryModel>> GetRecipeCategories()
        {
            try
            {
                var categories = await CategoryRepository.GetAllAsync(new DbQuery<CategoryEntity>
                {
                    AsNoTracking = true,
                    WhereExpression = x => x.IsRecipeCategory
                });

                if (categories.Any())
                {
                    return (from c in categories
                            select c.ToUiModel()).ToList();
                }

                return new List<CategoryModel>();
            }
            catch (Exception exception)
            {
                await LogError(new LogMessageEntity
                {
                    Message = "Could not load recipe categories from database!",
                    ExceptionMessage = exception.Message,
                    Stacktrace = exception.StackTrace ?? string.Empty,
                    TimeStamp = DateTime.Now,
                    Trigger = nameof(CookbookUnitOfWork)
                });

                return new List<CategoryModel>();
            }
        }

        public async Task<List<IngredientModel>> GetIngredients()
        {
            try
            {
                var ingredents = await IngredientRepository.GetAllAsync(new DbQuery<IngredientEntity>
                {
                    AsNoTracking = true,
                    WhereExpression = null
                });

                if (!ingredents.Any())
                {
                    return (from i in ingredents
                            select i.ToUiModel()).ToList();
                }

                return new List<IngredientModel>();
            }
            catch (Exception exception)
            {
                await LogError(new LogMessageEntity
                {
                    Message = "Could not load ingredients from database!",
                    ExceptionMessage = exception.Message,
                    Stacktrace = exception.StackTrace ?? string.Empty,
                    TimeStamp = DateTime.Now,
                    Trigger = nameof(CookbookUnitOfWork)
                });

                return new List<IngredientModel>();
            }
        }

        #region dispose
        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in der Methode "Dispose(bool disposing)" ein.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
