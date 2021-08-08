using System.Collections.Generic;
using System.Threading.Tasks;
using fahlen_dev_webapi.Models;

namespace fahlen_dev_webapi.Data {
  public interface IFoodDBRepo {
      bool SaveChanges();

      Task<bool> SaveChangesAsync();
      // IEnumerable<Command> GetAllCommands();
      // Command GetCommandById(int id);

      // Account Requests

      IEnumerable<Account> GetAllAccounts();
      Account GetAccountById(int id);
      void CreateAccount(Account acc);

      Account GetAccountByEmail(string email);

      // Recipe Requests

      IEnumerable<Recipe> GetAllRecipes();

      Task<IEnumerable<Recipe>> GetAllRecipesByUserIdAsync(string userId);
      Recipe GetRecipeById(int id);
      Task<Recipe> GetRecipeByIdAsync(int id);
      void CreateRecipe(Recipe rep);
      void DeleteRecipe(Recipe rep);

      // IEnumerable<RecipeReadWithRecipeGroups> GetAllRecipesWithRecipeGroup();

      // Recipe Group Requests
      IEnumerable<RecipeGroup> GetAllRecipeGroups();
      RecipeGroup GetRecipeGroupById(int id);
      IEnumerable<RecipeGroup> GetAllRecipeGroupsByAccountId(int id);
      void CreateRecipeGroup(RecipeGroup rep);
      void DeleteRecipeGroup(RecipeGroup rep);

      Task<bool> UserOwnsRecipeAsync(int recipeId, string userId);

      void DeleteRecipeGroupAsync(int id);

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

      IEnumerable<Instruction> GetAllInstructions();
      Instruction GetInstructionById(int id);
      void CreateInstruction(Instruction ins);
      void DeleteInstruction(Instruction ins);

      IEnumerable<Instruction> GetAllInstructionsByRecipeId(int id);


      // void CreateCommand(Command cmd);
      // void UpdateCommand(Command cmd);
      // void DeleteCommand(Command cmd);
  }
}