## Ingredient Upgrade

Let's call the unique ID of the material enhancement to be added to the game `CustomIngredientUpgrade`. The files below are required to add material reinforcement.
- `assets/settings/ingredient_upgrade.json`: Records numerical information related to material reinforcement. The format of the json file is explained again below.
- `assets/settings/i18n.json`: Name and description information for material reinforcement that will appear in the game. The form is discussed again below.

### ingredient_upgrade.json

```json
{
   "CustomIngredientUpgrade": {
     "Value": [
       1,
       2,
       3,
       4,
       5,
       6,
       7,
       8,
       9,
       10
     ]
   }
}
```

You can record the setting value to be used for each material reinforcement in the form above. When adding multiple material enhancements in one mode, add content to ingredient_upgrade.json above using the unique ID of each material enhancement as the key.

### i18n.json

```json
{
   "en": {
     "upgrade": {
       "ingredient": {
         "CustomIngredientUpgrade": {
           "name": "CustomIngredient Name",
           "desc": "CustomIngredient Desc {Ingredient} {Value}",
           "simple_desc": "CustomIngredient simple desc {Value}",
           "guide_desc": "CustomIngredient Guide Desc"
         }
       }
     }
   }
}
```

`name, desc` are the name and description of the material enhancement, respectively. `simple_desc` is text that shows the application status of ingredient enhancement in the recipe information pop-up (since there is less space, it is better to keep it shorter than `desc`). `guide_desc` is explanatory text that can be found in the guide window.

### scripting

Lua script required to define the behavior of material reinforcement.

```lua

kitchen_crisis.upgrade.ingredient.register("CustomIngredientUpgrade")

kitchen_crisis.upgrade.ingredient.CustomIngredientUpgrade = {
   simple_desc = function (setting, level)
     return kitchen_crisis.i18n_bind("upgrade.tool.CustomIngredientUpgrade.simple_desc", {
       Value = tostring(setting.Value[now + 1].Value)
     })
   end,
   view_desc = function (setting, ingredient, now, nxt)
     return kitchen_crisis.i18n_bind("upgrade.tool.CustomIngredientUpgrade.desc", {
       Ingredient = ingredient, ingredient
       Value = tostring(setting.Value[now + 1].Value)
     })
   end,
   max_count = function (setting)
     #setting.Value
   end,
   run_upgrade_first = function (setting, ingredient)
   end,
   run_upgrade = function(setting, ingredient, level)
   end
}
```

You can register information about the material enhancement you want to make in the game through `kitchen_crisis.ingredient_upgrade.register`.

`setting`, the argument of the `simple_desc, iew_desc, max_count, run_upgrade_first, run_upgrade` function, is the value defined in `tool_upgrade.json` above and is delivered in table format.

The `simple_desc` function is a function that returns explanatory text when a recipe pops up for strengthening ingredients. level is the current level and is a value in the range of 1 to max_count.

The `view_desc` function is a function that returns the material enhancement description text. ingredient is the material to which reinforcement is applied, now is the current level, and nxt is the next level. For now and nxt, the value ranges from 0 to max_count. In reinforcement selection, now and nxt are given different values (now = current reinforcement level, nxt = level when reinforcement is selected), and in the simple explanation screen, they are given the same value.

The `max_count` function is a function that returns the maximum upgrade level of the corresponding material enhancement.

The `run_upgrade_first` function is called when the material is upgraded for the first time. `ingredient` refers to the material to which the material enhancement is applied.

The `run_upgrade` function is called every time the material is strengthened. `ingredient` refers to the material to which the material enhancement is applied, and `level` is a value in the range of 1 to max_count. When upgrading for the first time, the `run_upgrade_first` and `run_upgrade` functions are called in that order, and after that, only the `run_upgrade` function is called.