## Consumables

Let's call the unique ID of the consumable to be added to the game `CustomConsumable`. The files below are required to add consumables.

- `assets/sprites/consumable/CustomConsumable.png`: This is the in-game icon image for the consumable. It must be a png image of 16x16 size.
- `assets/settings/consumable.json`: Records numerical information related to consumables. The format of the json file is explained again below.
- `assets/settings/i18n.json`: Name and description information of consumables that will appear in the game. The form is discussed again below.

### consumable.json

```json
{
   "CustomConsumable": {
     "Value": 5
   }
}
```

You can record the setting values to be used for each consumable in the form above. When adding multiple consumables in one mode, just add the contents to consumable.json above using the unique ID of each consumable as the key.

### i18n.json

```json
{
   "en": {
     "consumable": {
       "CustomConsumable": {
         "name": "CustomConsumable Name",
         "desc": "CustomConsumable Desc, Value: {Value}"
       }
     }
   }
}
```

You can record the name/description of each consumable in the format shown above. When adding multiple consumables in one mode, use the unique ID of each consumable as the key value and add the necessary information under `lang/consumable/key`.

### scripting

This is a lua script needed to define the behavior of each consumable.

```lua
kitchen_crisis.consumable.register("CustomConsumable")

kitchen_crisis.consumable.CustomConsumable = {
   desc = function (setting)
     return kitchen_crisis.i18n_bind("relic.CustomConsumable.desc", {
       Value = tostring(setting.Value)
     });
   end
   on_get = function (setting)
   end
   run = function (setting)
   end
}
```

You can register information about consumables you want to make in the game through `kitchen_crisis.consumable.register`.

`setting`, an argument of `desc, on_get, run` function, is the value defined in `consumable.json` above and is delivered in table format.

The `desc` function is a function that returns the description text of the corresponding consumable. As in the code above, use the `i18n_bind` function to change `{Value}` of the desc value defined in `1i8n.json` to `5, which is the `Value` of the consumable setting value (defined in `consumable.json`). You can change it to `.

The `on_get` function is called when the consumable is first acquired in the game.

The `run` function is called when the corresponding consumable is used in the game.