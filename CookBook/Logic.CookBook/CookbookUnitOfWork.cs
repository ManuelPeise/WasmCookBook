using Data.AppContext;
using Data.Models.Entities.CookBook;
using Data.Models.Entities.Logging;
using Data.Models.ExportModels.CookBook;
using Data.Models.ImportModels.CookBook;
using Data.Models.UI;
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
        private IRepositoryBase<RecipeImportEntity>? _recipeImportRepository;

        public IRepositoryBase<RecipeEntity> RecipeRepository => _recipeRepository ?? new RepositoryBase<RecipeEntity>(_context);
        public IRepositoryBase<CategoryEntity> CategoryRepository => _categoryRepository ?? new RepositoryBase<CategoryEntity>(_context);
        public IRepositoryBase<IngredientEntity> IngredientRepository => _ingredientRepository ?? new RepositoryBase<IngredientEntity>(_context);
        public IRepositoryBase<RecipeIngredientEntity> RecipeIngredientRepository => _recipeIngredientRepository ?? new RepositoryBase<RecipeIngredientEntity>(_context);
        public IRepositoryBase<UnitEntity> IngredientUnitRepository => _ingredientUnitRepository ?? new RepositoryBase<UnitEntity>(_context);
        public IRepositoryBase<RecipeImportEntity> RecipeImportRepository => _recipeImportRepository ?? new RepositoryBase<RecipeImportEntity>(_context);

        public CookbookUnitOfWork(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<RecipeModel>> GetRecipes(int? categoryId)
        {
            try
            {
                var recipes = await QueryRecipes(categoryId);

                var models = new List<RecipeModel>();

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

        public async Task<List<CategoryModel>> GetCategories(bool isRecipeCategory)
        {
            try
            {
                var categories = await CategoryRepository.GetAllAsync(new DbQuery<CategoryEntity>
                {
                    AsNoTracking = true,
                    WhereExpression = x => x.IsRecipeCategory == isRecipeCategory
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

        public async Task<List<UnitModel>> GetUnits()
        {
            try
            {
                var units = await IngredientUnitRepository.GetAllAsync(new DbQuery<UnitEntity>
                {
                    AsNoTracking = true,
                    WhereExpression = null
                });

                if (units.Any())
                {
                    return (from unit in units
                            select unit.ToUiModel()).ToList();
                }

                return new List<UnitModel>();
            }
            catch (Exception exception)
            {
                await LogError(new LogMessageEntity
                {
                    Message = "Could not load units from database!",
                    ExceptionMessage = exception.Message,
                    Stacktrace = exception.StackTrace ?? string.Empty,
                    TimeStamp = DateTime.Now,
                    Trigger = nameof(CookbookUnitOfWork)
                });

                return new List<UnitModel>();
            }
        }

        public async Task<List<RecipeRequestExportModel>> GetRecipeImports(bool importFinished = false)
        {
            try
            {
                var entities = await RecipeImportRepository.GetAllAsync(new DbQuery<RecipeImportEntity>
                {
                    AsNoTracking = true,
                    WhereExpression = x => x.ImportFinished == importFinished
                });


                if (entities.Any())
                {
                    return (from entity in entities
                            select entity.ToExportModel()).ToList();
                }

                return new List<RecipeRequestExportModel>();

            }
            catch (Exception exception)
            {
                await LogError(new LogMessageEntity
                {
                    Message = "Could get RecipeRequestExportModels!",
                    ExceptionMessage = exception.Message,
                    Stacktrace = exception.StackTrace ?? string.Empty,
                    TimeStamp = DateTime.Now,
                    Trigger = nameof(CookbookUnitOfWork)
                });

                return new List<RecipeRequestExportModel>();
            }
        }

        public async Task<bool> ImportRecipeRequest(RecipeImportModel model)
        {
            try
            {
                if (model == null)
                {
                    return false;
                }

                var importEntity = model.ToEntity(false);

                await RecipeImportRepository.AddAsync(importEntity, true);

                await SaveChanges();

                return true;

            }
            catch (Exception exception)
            {
                await LogError(new LogMessageEntity
                {
                    Message = "Could import recipe!",
                    ExceptionMessage = exception.Message,
                    Stacktrace = exception.StackTrace ?? string.Empty,
                    TimeStamp = DateTime.Now,
                    Trigger = nameof(CookbookUnitOfWork)
                });

                return false;
            }
        }

        public async Task<bool> DeleteRecipeRequest(int id)
        {
            try
            {
                await RecipeImportRepository.DeleteAsync(id);

                await SaveChanges();

                return true;
            }
            catch (Exception exception)
            {
                await LogError(new LogMessageEntity
                {
                    Message = "Could delete recipe request!",
                    ExceptionMessage = exception.Message,
                    Stacktrace = exception.StackTrace ?? string.Empty,
                    TimeStamp = DateTime.Now,
                    Trigger = nameof(CookbookUnitOfWork)
                });

                return false;
            }
        }

        public async Task<bool> ImportRecipe(int id)
        {
            try
            {
                var entity = await RecipeImportRepository.GetFirstOrDefaultAsync(new DbQuery<RecipeImportEntity>
                {
                    AsNoTracking = true,
                    WhereExpression = x => x.Id == id
                });

                if (entity == null)
                {
                    return false;
                }

                var importModel = entity.ToImportModel();

                if (importModel == null)
                {
                    return false;
                }

                var recipe = importModel.ToEntity();


                if (recipe == null)
                {
                    return false;
                }

                var (recipeId, inserted) = await RecipeRepository.AddIfNotExists(recipe, x => x.Title.Equals(importModel.Title) &&
                x.ShortDescription.Equals(importModel.ShortDescription), true);

                if (inserted)
                {
                    foreach (var ingredientModel in importModel.Ingredients)
                    {
                        var ingredientId = await GetIngredientId(ingredientModel);

                        await RecipeIngredientRepository.AddIfNotExists(ingredientModel.ToEntity(recipeId, ingredientId), x => x.IngredientId == ingredientId && x.RecipeId == recipeId, true);
                    }

                    entity.ImportFinishedAt = DateTime.Now;
                    entity.ImportFinished = true;

                    await RecipeImportRepository.UpdateAsync(entity, x => x.Id == entity.Id);

                    await SaveChanges();

                    return true;
                }

                return false;

            }
            catch (Exception exception)
            {
                await LogError(new LogMessageEntity
                {
                    Message = "Could finish recipe import!",
                    ExceptionMessage = exception.Message,
                    Stacktrace = exception.StackTrace ?? string.Empty,
                    TimeStamp = DateTime.Now,
                    Trigger = nameof(CookbookUnitOfWork)
                });

                return false;
            }
        }

        public async Task DeleteRecipe(int recipeId)
        {
            try
            {
                var databaseModified = false;

                var recipe = await QueryRecipe(recipeId);

                if(recipe == null)
                {
                    return;
                }

                var recipeIngredients = await QueryRecipeIngredients(recipe.RecipeId);

                foreach(var ingredient in recipeIngredients)
                {
                    await RecipeIngredientRepository.DeleteAsync(ingredient.IngredientId);

                    databaseModified = true;
                }

                await RecipeRepository.DeleteAsync(recipe.RecipeId);

                if (databaseModified)
                {
                    await SaveChanges();

                }

            }
            catch(Exception exception)
            {
                await LogError(new LogMessageEntity
                {
                    Message = $"Could delete recipe {recipeId}!",
                    ExceptionMessage = exception.Message,
                    Stacktrace = exception.StackTrace ?? string.Empty,
                    TimeStamp = DateTime.Now,
                    Trigger = nameof(CookbookUnitOfWork)
                });
            }
        }

        #region dispose

        private async Task<List<RecipeEntity>> QueryRecipes(int? categoryId = null)
        {
            var recipeCollection = new List<RecipeEntity>();

            using (var repo = RecipeRepository)
            {
                var recipes = await repo.GetAllAsync(new DbQuery<RecipeEntity>
                {
                    AsNoTracking = true,
                    WhereExpression = categoryId != null ? x => x.FKCategoryId == categoryId : null
                });

                recipeCollection =  recipes.ToList();
            }

            return recipeCollection;
        }

        private async Task<RecipeEntity?> QueryRecipe(int id)
        {
            RecipeEntity? recipe = null;

            using (var repo = RecipeRepository)
            {
                var entity = await repo.GetFirstOrDefaultAsync(new DbQuery<RecipeEntity>
                {
                    AsNoTracking = true,
                    WhereExpression = x => x.RecipeId == id
                });

                recipe = entity;
            }

            return recipe;
        }

        private async Task<List<RecipeIngredientEntity>> QueryRecipeIngredients(int recipeId)
        {
            var ingredientCollection = new List<RecipeIngredientEntity>();

            using (var repo = RecipeIngredientRepository)
            {
                var recipes = await repo.GetAllAsync(new DbQuery<RecipeIngredientEntity>
                {
                    AsNoTracking = true,
                    WhereExpression = x => x.RecipeId == recipeId
                });

                ingredientCollection = recipes.ToList();
            }

            return ingredientCollection;
        }

        private async Task<int> GetIngredientId(RecipeIngredientImportModel model)
        {
            var (id, imported) = await IngredientRepository.AddIfNotExists(new IngredientEntity
            {
                Name = model.Name,
                FkCategoryId = model.CategoryId,
                Category = null,
                RecipeIngredients = null

            }, x => x.FkCategoryId == model.CategoryId && x.Name.Equals(model.Name), true);

            return id;
        }

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
