## character

Let's call the unique ID of the character to be added to the game `CustomCharacter`. To add a character, you need the files below.

- `assets/sprites/character/customcharacter.png`: The character's animation sprite sheet image file. The name must be the unique ID converted to all lowercase letters. Please pay attention to capitalization.
- `assets/sprites/character/customcharacter.anim`: A file that specifies the character's animation information. The name must be the unique ID converted to all lowercase letters. Please pay attention to capitalization.
- `assets/settings/character.json`: Records numerical information related to the character. The format of the json file is explained again below.
- `assets/settings/i18n.json` This is the name and description information of the character that will appear in the game. The form is discussed again below.

### animation

Character animation information must include the animation below.

- idle, idle_back: An animation that stands still (forward/backward).
- run, run_back: Moving animation (forward/backward).
- slicing, slicing_back: Slicing animation (front/back).
- working, working_back: Animation (forward/backward) using the toolbox.
- pan, pan_back: Animation (forward/backward) using a frying pan.
- cook_waiting, cook_waiting_back: Animation (forward/backward) using other cooking tools.
- game_over: Game over state animation.
- angry: An animation that makes you angry.
- cry: A crying animation.

### character.json

```json
{
   "CustomCharacter": {
     "CookSpeed": 1,
     "MoveSpeed": 1,
     "Value": 10
   }
}
```

`CookSpeed` and `MoveSpeed` are values that determine the character's basic cooking speed and movement speed and must be included.

Other than that, just add the necessary attribute values during the character implementation process.

### i18n.json

```json
{
   "en": {
     "character": {
       "CustomCharacter": {
         "name": "Name",
         "desc": "Desc, {Value}"
       }
     },
     "unlock": {
       "character": {
         "CustomCharacter": "unlock"
       }
     }
   }
}
```

Define text corresponding to the name, description, and unlock conditions for each character.

### Scripting

This is a lua script needed to define the character's behavior.

```lua
kitchen_crisis.character.register("CustomCharacter");

kitchen_crisis.save_data.unlock_character("CustomCharacter");

kitchen_crisis.character.CustomCharacter = {
   desc = function(setting)
     return kitchen_crisis.i18n_bind("character.CustomCharacter.desc", {
       Value = tostring(setting.Value)
     })
   end
   base_count = function(setting)
     return 1
   end
   blocked_tool_upgrade = function(setting)
     return ["BlockedToolUpgrade"]
   end
   start = function(setting)
   end
   on_wave_end = function(setting)
   end
}

```

You can register the information of the character you want to create in the game through `kitchen_crisis.character.register`.

`setting`, an argument of the `desc, base_count, blocked_tool_upgrade, start, on_wave_end` function, is the value defined in `character.json` above and is delivered in table form.

The `desc` function is a function that returns descriptive text for a character in a new game screen.

`base_count` means the base number of clones when the game starts. If not defined, the game's default values will be used.

`blocked_tool_upgrade` defines a list of upgrades that will block tool upgrades when the character is selected. If you don't need that functionality, you don't need to define it.

`start` defines what to do at the beginning of the game after choosing that character.

`on_wave_end` defines what to do at the end of each wave.