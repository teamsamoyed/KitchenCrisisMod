## ingredient

Let's call the unique ID of the material to be added to the game `CustomIngredient`. The files below are required to add materials.

- `assets/sprites/food/CustomIngredient.png`: This is the in-game icon image for the ingredient. It must be a png image of 16x16 size.
- `assets/settings/i18n.json`: Name and description information of materials that will appear in the game. The form is discussed again below.


### i18n.json

```json
{
   "en": {
     "ingredient": {
       "CustomIngredient": "CustomIngredient Name",
       "desc": {
         "CustomIngredient": "CustomIngredient Desc",
       }
     },
     "unlock": {
       "ingredient": {
         "CustomIngredient": "unlock"
       }
     }
   }
}
```

You can record the name/description and unlock conditions of each material in the form above. When adding multiple materials in one mode, the unique ID of each material is used as the key value, and the information required under `lang/ingredient/key`, `lang/ingredient/desc/key`, and `lang/unlock/ingredient/key` Just add .

### Scripting

Added materials can only be used after unlocking them. If an ingredient has not been unlocked, recipes using that ingredient will not appear in the game.

```lua
kitchen_crisis.save_data.unlock_ingredient("CustomIngredient");
```

You can unlock the material using the code above.

## recipe

Let's name the recipe you want to add as `CustomRecipe.json`. To add a recipe, you need the files below.

- `assets/sprite/food/CustomRecipe.json`: This is the in-game icon image for the recipe. It must be a png image of 16x16 size.
- `assets/recipe.json`: Defines the cooking process of the recipe. The form is discussed again below.
- `assets/settings/i18n.json`: Information on the name of the dish that will appear in the game. The form is discussed again below.

### recipe.json

```json
{
   "CustomRecipe": {
     "Required": [
     ],
     "Process": "Pan",
     "Result": "CustomRecipe",
     "IsMenu": true
   }
}
```

`Required` is a list of previous step recipes required to make that recipe. `Process` refers to the tools needed to proceed with cooking. Key values for each tool are as follows.

- Store: Material box. For material boxes, Required must be an empty array.
- Board: cutting board
- Pan: Frying pan
- Fryer: Fryer
- Oven: Oven
- Pot : Pot
- Empty: Countertop

`Result` must be the same value as the key value. `IsMenu` is true if the recipe is to be used as a menu, and false if the recipe is to be used as an intermediate step but is not a menu.

### i18n.json

```json
{
   "en": {
     "ingredient": {
       "CustomRecipe": "CustomRecipe Name"
     }
   }
}
```

You can record the name of each recipe in the form above. When adding multiple recipes in one mode, use the unique ID of each treasure as the key value and add the necessary information under `lang/ingredient/key`.