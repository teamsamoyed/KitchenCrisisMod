## Tool Enhancement

Let's call the unique ID of the tool upgrade to be added to the game `CustomToolUpgrade`. The files below are required to add tool enhancements.
- `assets/sprites/tool_upgrades/CustomToolUpgrade.png`: This is the in-game icon image for the corresponding tool upgrade. It must be a png image of 16x16 size.
- `assets/sprites/tool_upgrades/CustomToolUpgradeMain.png`: This is the in-game icon image when the tool enhancement is maximally enhanced. It must be a png image of 16x16 size.
- `assets/settings/tool_upgrade.json`: Records numerical information related to tool upgrades. The format of the json file is explained again below.
- `assets/settings/i18n.json`: Name and description information for tool enhancements that will appear in the game. The form is discussed again below.

### tool_upgrade.json

```json
{
   "CustomToolUpgrade": {
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

You can record the setting values to be used for each tool enhancement in the form above. When adding multiple tool enhancements in one mode, add content to tool_upgrade.json above using the unique ID of each tool enhancement as the key.

### i18n.json

```json
{
   "en": {
     "upgrade": {
       "tool": {
         "CustomToolUpgrade": {
           "name": "CustomTool Name",
           "desc": "CustomTool Desc {Value}",
           "main_name": "CustomTool MainName",
           "main_desc": "CustomTool MainDesc {Value}",
           "guide_desc": "CustomTool Guide Desc",
           "main_guide_desc": "CustomTool MainGuide Desc"
         }
       }
     },
     "unlock": {
       "tool": {
         "CustomToolUpgrade": ""
       }
     }
   }
}
```

`name, desc` are the name and description of the tool enhancement, `main_name, main_desc` are the name and description of the maximum enhancement, and `guide_desc` and `main_guide_desc` are the description of the basic/maximum tool enhancement shown in the encyclopedia window of the title screen. Text. The text under `unlock` is text that explains the conditions for unlocking the enhancement.

### scripting

Lua script required to define the behavior of tool enhancements.

```lua

kitchen_crisis.upgrade.tool.register("CustomToolUpgrade")
kitchen_crisis.save_data.unlock_tool_upgrade("CustomToolUpgrade")

kitchen_crisis.upgrade.tool.CustomToolUpgrade = {
   view_desc = function(setting, now, nxt)
     return kitchen_crisis.i18n_bind("upgrade.tool.CustomToolUpgrade.desc", {
       Value = tostring(setting.Value[now + 1].Value)
     })
   end,
   max_count = function(setting)
     return #setting.Value
   end,
   run_upgrade_first = function(setting)
   end,
   run_upgrade = function(setting, level)
   end
}
```

You can register information about tool enhancements you want to make in the game through `kitchen_crisis.tool_upgrade.register`. You can unlock tool upgrades with `kitchen_crisis.save_data.unlock_tool_upgrade`. Even if you register, if you do not unlock it, it will not appear as an option in the game.

`setting`, the argument of the `view_desc, max_count, run_upgrade_first, run_upgrade` function, is the value defined in `tool_upgrade.json` above and is delivered in table format.

The `view_desc` function is a function that returns tool-enhanced description text. now is the current level and nxt is the next level. For now and nxt, the value ranges from 0 to max_count. In reinforcement selection, now and nxt are given different values (now = current reinforcement level, nxt = level when reinforcement is selected), and in the simple explanation screen, they are given the same value.

The `max_count` function is a function that returns the maximum upgrade level of the corresponding tool enhancement.

The `run_upgrade_first` function is called when the tool is upgraded for the first time.

The `run_upgrade` function is called each time the tool is upgraded. `level` is a value in the range of 1 to max_count. When upgrading for the first time, the `run_upgrade_first` and `run_upgrade` functions are called in that order, and after that, only the `run_upgrade` function is called.