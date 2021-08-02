using System;
using System.Collections.Generic;
using System.Linq;
using fahlen_dev_webapi.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace fahlen_dev_webapi.Data
{
    public class PostgresFoodRepo : IFoodDBRepo
    {
        private readonly FoodContext _context;

        public PostgresFoodRepo(FoodContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        // Account Requests

        public void CreateAccount(Account acc)
        {
            if (acc == null) {
                throw new ArgumentNullException(nameof(acc));
            }

            _context.Accounts.Add(acc);
        }

        public Account GetAccountById(int id)
        {
            return _context.Accounts.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return _context.Accounts.ToList();
        }

        // Recipe Requests

        public IEnumerable<Recipe> GetAllRecipes()
        {
            return _context.Recipes.ToList();
        }

        public Recipe GetRecipeById(int id)
        {
            return _context.Recipes.FirstOrDefault(r => r.Id == id);
        }

        public void CreateRecipe(Recipe rep)
        {
            if (rep == null) {
                throw new ArgumentNullException(nameof(rep));
            }

            _context.Recipes.Add(rep);
        }

        public void DeleteRecipe(Recipe rep) {
            if(rep == null) {
                throw new ArgumentNullException(nameof(rep));
            }
            _context.Recipes.Remove(rep);
        }

        // Recipe Group Requests

        public IEnumerable<RecipeGroup> GetAllRecipeGroups()
        {
            return _context.RecipeGroups.ToList();
        }

        public RecipeGroup GetRecipeGroupById(int id)
        {
            return _context.RecipeGroups.FirstOrDefault(r => r.Id == id);
        }

        public void CreateRecipeGroup(RecipeGroup repGro)
        {
            if (repGro == null) {
                throw new ArgumentNullException(nameof(repGro));
            }

            _context.RecipeGroups.Add(repGro);
        }

        public void DeleteRecipeGroup(RecipeGroup repGro) {
            if(repGro == null) {
                throw new ArgumentNullException(nameof(repGro));
            }
            _context.RecipeGroups.Remove(repGro);
        }

        public IEnumerable<Ingredient> GetAllIngredients()
        {
            return _context.Ingredients.ToList();
        }

        public Ingredient GetIngredientById(int id)
        {
            return _context.Ingredients.FirstOrDefault(i => i.Id == id);
        }

        public void CreateIngredient(Ingredient ing)
        {
            if (ing == null) {
                throw new ArgumentNullException(nameof(ing));
            }

            _context.Ingredients.Add(ing);
        }

        public void DeleteIngredient(Ingredient ing)
        {
            if(ing == null) {
                throw new ArgumentNullException(nameof(ing));
            }
            _context.Ingredients.Remove(ing);
        }

        public IEnumerable<Measure> GetAllMeasures()
        {
            return _context.Measures.ToList();
        }

        public Measure GetMeasureById(int id)
        {
            return _context.Measures.FirstOrDefault(m => m.Id == id);
        }

        public void CreateMeasure(Measure mea)
        {
            if (mea == null) {
                throw new ArgumentNullException(nameof(mea));
            }

            _context.Measures.Add(mea);
        }

        public void DeleteMeasure(Measure mea)
        {
            if(mea == null) {
                throw new ArgumentNullException(nameof(mea));
            }
            _context.Measures.Remove(mea);
        }

        public IEnumerable<RecipeGroup> GetAllRecipeGroupsByAccountId(int id)
        {
            var listOfIds = _context.RecipeGroups.Where(n=>n.RecipeId == id).Select(x=>x.Id);
            var itemEntity = _context.RecipeGroups.Where(m=>listOfIds.Contains(m.Id));
            return itemEntity.ToList();
        }

        public IEnumerable<Ingredient> GetAllIngredientsByRecipeGroupId(int id)
        {
            var listOfIds = _context.Ingredients.Where(n=>n.RecipeGroupId == id).Select(x=>x.Id);
            var itemEntity = _context.Ingredients.Where(m=>listOfIds.Contains(m.Id));
            return itemEntity.ToList();
        }

        public IEnumerable<Instruction> GetAllInstructions()
        {
            return _context.Instructions.ToList();
        }

        public Instruction GetInstructionById(int id)
        {
            return _context.Instructions.FirstOrDefault(i => i.Id == id);
        }

        public void CreateInstruction(Instruction ins)
        {
            if (ins == null) {
                throw new ArgumentNullException(nameof(ins));
            }

            _context.Instructions.Add(ins);
        }

        public void DeleteInstruction(Instruction ins)
        {
            if(ins == null) {
                throw new ArgumentNullException(nameof(ins));
            }
            _context.Instructions.Remove(ins);
        }

        public IEnumerable<Instruction> GetAllInstructionsByRecipeId(int id)
        {
            var listOfIds = _context.Instructions.Where(n=>n.RecipeId == id).Select(x=>x.Id);
            var itemEntity = _context.Instructions.Where(m=>listOfIds.Contains(m.Id));
            return itemEntity.ToList();
        }

    // public IEnumerable<Recipe> GetAllRecipesWithRecipeGroup()
    // {
    //     throw new NotImplementedException();
    // }
    }
}