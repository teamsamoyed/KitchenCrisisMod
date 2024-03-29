## treasure

Let's call the unique ID of the treasure to be added to the game `CustomRelic`. To add treasure, you need the files below.

- `assets/sprites/relics/CustomRelic.png`: This is the in-game icon image of the treasure. It must be a png image of 16x16 size.
- `assets/settings/relic.json`: Records numerical information related to treasure. The format of the json file is explained again below.
- `assets/settings/i18n.json`: Name and description information of the treasure that will appear in the game. The form is discussed again below.

### relic.json

```json
{
   "CustomRelic": {
     "Value": 5
   }
}
```

You can record the setting values to be used for each treasure in the form above. If you add multiple treasures in one mode, just add the contents to relic.json above using the unique ID of each treasure as the key.

### i18n.json

```json
{
   "en": {
     "relic": {
       "CustomRelic": {
         "name": "CustomRelic Name",
         "desc": "CustomRelic Desc, Value: {Value}"
       }
     }
   }
}
```

You can record the name/description of each treasure in the form above. Similarly, when adding multiple treasures in one mode, use the unique ID of each treasure as the key value and add the necessary information under `lang/relic/key`.

### scripting

This is the lua script needed to define the behavior of each treasure.

```lua
kitchen_crisis.relic.register("CustomRelic")

kitchen_crisis.relic.CustomRelic = {
   desc = function (setting)
     return kitchen_crisis.i18n_bind("relic.CustomRelic.desc", {
       Value = tostring(setting.Value)
     });
   end,
   prob = function (setting)
     return 1;
   end,
   on_get = function (setting)
   end
}
```

You can register the information of the treasure you want to make in the game through `kitchen_crisis.relic.register`.

`setting`, the argument of `desc, prob, on_get` function, is the value defined in `relic.json` above and is delivered in table format.

The `desc` function is a function that returns the description text of the treasure. As in the code above, use the `i18n_bind` function to change `{Value}` of the desc value defined in `1i8n.json` to `5, the `Value` of the treasure's setting value (defined in `relic.json`). You can change it to `.

The `prob` function determines the probability that the corresponding treasure will appear in the treasure selection process. The probability of appearance of the game's basic treasures is 1.

The `on_get` function is called when the treasure is first acquired in the game. Here you can define the effect of the treasure.