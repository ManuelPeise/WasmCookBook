﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models.Entities.CookBook
{
    public class RecipeIngredientEntity: AEntity
    {
        public int RecipeIngredientId => Id;
        public decimal Amount { get; set; }
        public string Unit { get; set; } = string.Empty;
        
        public int RecipeId { get; set; }
        [ForeignKey(nameof(RecipeId))]
        public virtual RecipeEntity Recipe { get; set; } = new RecipeEntity();
        
        public int IngredientId { get; set; }
        [ForeignKey(nameof(IngredientId))]
        public virtual IngredientEntity Ingredient { get; set; } = new IngredientEntity();
    }
}