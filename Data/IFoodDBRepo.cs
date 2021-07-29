using System.Collections.Generic;
using fahlen_dev_webapi.Models;

namespace fahlen_dev_webapi.Data {
  public interface IFoodDBRepo {
      bool SaveChanges();
      // IEnumerable<Command> GetAllCommands();
      // Command GetCommandById(int id);

      // Account Requests

      IEnumerable<Account> GetAllAccounts();
      Account GetAccountById(int id);
      void CreateAccount(Account acc);

      // Recipe Requests

      IEnumerable<Recipe> GetAllRecipes();
      Recipe GetRecipeById(int id);
      void CreateRecipe(Recipe rep);
      void DeleteRecipe(Recipe rep);

      // IEnumerable<RecipeReadWithRecipeGroups> GetAllRecipesWithRecipeGroup();

      // Recipe Group Requests
      IEnumerable<RecipeGroup> GetAllRecipeGroups();
      RecipeGroup GetRecipeGroupById(int id);
      IEnumerable<RecipeGroup> GetAllRecipeGroupsByAccountId(int id);
      void CreateRecipeGroup(RecipeGroup rep);
      void DeleteRecipeGroup(RecipeGroup rep);

      // Ingredient Requests
      IEnumerable<Ingredient> GetAllIngredients();
      Ingredient GetIngredientById(int id);
      void CreateIngredient(Ingredient ing);
      void DeleteIngredient(Ingredient ing);

      IEnumerable<Ingredient> GetAllIngredientsByRecipeGroupId(int id);

      // Measure Requests
      IEnumerable<Measure> GetAllMeasures();
      Measure GetMeasureById(int id);
      void CreateMeasure(Measure mea);
      void DeleteMeasure(Measure mea);

      // void CreateCommand(Command cmd);
      // void UpdateCommand(Command cmd);
      // void DeleteCommand(Command cmd);
  }
}