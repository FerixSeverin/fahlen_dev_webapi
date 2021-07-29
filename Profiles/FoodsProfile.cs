using fahlen_dev_webapi.Dtos;
using fahlen_dev_webapi.Models;
using AutoMapper;

namespace fahlen_dev_webapi.Profiles
{
    public class FoodsProfile : Profile
    {

        public FoodsProfile() {
            CreateMap<Account, AccountRead>();
            CreateMap<AccountCreate, Account>();

            CreateMap<Recipe, RecipeRead>();
            CreateMap<RecipeCreate, Recipe>();
            CreateMap<Recipe, RecipeReadWithRecipeGroups>();


            CreateMap<RecipeGroup, RecipeGroupRead>();
            CreateMap<RecipeGroupCreate, RecipeGroup>();
            CreateMap<RecipeGroup, RecipeGroupReadWithIngredientRead>();

            CreateMap<Ingredient, IngredientRead>();
            CreateMap<IngredientCreate, Ingredient>();
            CreateMap<Ingredient, IngredientReadWithMeasure>();

            CreateMap<Measure, MeasureRead>();
            CreateMap<MeasureCreate, Measure>();
        }
    }
}