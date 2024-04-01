## monster

Let's call the unique ID of the monster to be added to the game `CustomMonster`. To add monsters, you need the files below.

- `assets/sprites/monster/MonsterView.png`: Monster animation sprite sheet image file. You can set which sheet image to use in `monster.json`.
- `assets/sprites/monster/MonsterView.anim`: A file that specifies the monster’s animation information.
- `assets/settings/monster.json`: Records numerical information related to monsters. The format of the json file is explained again below.
- `assets/settings/i18n.json` This is the name and description information of the monster that will appear in the game. The form is discussed again below.


Let's call the unique ID of the character to be added to the game `CustomCharacter`. To add a character, you need the files below.

- `assets/sprites/character/customcharacter.png`: The character's animation sprite sheet image file. The name must be the unique ID converted to all lowercase letters. Please pay attention to capitalization.
- `assets/sprites/character/customcharacter.anim`: A file that specifies the character's animation information. The name must be the unique ID converted to all lowercase letters. Please pay attention to capitalization.
- `assets/settings/character.json`: Records numerical information related to the character. The format of the json file is explained again below.
- `assets/settings/i18n.json` This is the name and description information of the character that will appear in the game. The form is discussed again below.

### animation

Monster animation information must include the animation below.

- idle, idle_back: An animation that stands still (forward/backward).
- run, run_back: Moving animation (forward/backward).
- eat, eat_back: Animation of eating food (front/back).
- split, split_back: An animation that is split into two (front/back). Required if the monster type is `Split`.
- idle_nude, idle_nude_back, run_nude, run_nude_back, eat_nude, eat_nude_back: Animation (forward/backward) in slow state. Required if the monster type is `Turtle`.
- summon, summon_back: An animation (forward/backward) that summons/summons a monster. Required if the monster type is `Undead` or `UndeadSpawn`.

### monster.json

```json
{
   "CustomMonster": {
     "Type": "FourLegs",
     "HP": 150,
     "Attack": 1,
     "MoveSpeed": 1.1,
     “Gold”: 100,
     "Y": 0;
     "FaceX": 0,
     "FaceY": 0;
     "View": "MonsterView",
     "IsBoss": false
   }
}
```

This is a list of attribute values that all monsters have in common.

- Type: The type of monster. FourLegs, Ogre, Slime, Mosquito, Golem, Split, Angel, Undead, UndeadSpawn, Turtle, and Reptile are the default values provided. Additional attributes or animations required may vary depending on the type of monster.
- HP: The monster's physical strength.
- Attack: The attack power of the monster.
- MoveSpeed: The monster’s movement speed.
- Gold: The amount of gold given by the monster.
- Y: Defines the height off the ground when rendering.
- FaceX, FaceY: Define the coordinates where the monster's face is located.
- View: The name of the animation sheet to be used for rendering the monster. Render using `assets/sprites/monster/(View).png` and `assets/sprites/monster/(View).anim`.
- IsBoss: Whether to treat it as a boss monster. In the case of a boss monster, a warning appears at the start of the wave.

Below is a list of additional attributes required for each monster type.

- Slime

```json
{
   "HPIncreasePerSecond": 1
}
```

This is the amount of stamina increase per second.

-Split

In the case of Split, additional information on the monster created as a result of the split is required. The monster with the name `Name` is split into two monsters, `NameA` and `NameB`.

- Angel

```json
{
   "TierBonus": [ -20, -10, 0, 10, 20 ]
}
```

This is the adjusted satiety (%) value received from the food consumed. They correspond to tiers 1, 2, 3, 4, and 5 respectively.

-Undead

```json
{
   "Summon": "SummonName",
   “SummonTerm”: 5
}
```

Summons a monster corresponding to `Summon` every `SummonTerm` seconds. The monster being summoned must be of type `UndeadSpawn`.

-Turtle

```json
{
   “CCBonus”: 50
}
```

This is the satiety adjustment (%) value received from the food consumed while in the movement control state.

- Reptile

```json
{
   "DamageMax": 100
}
```

This is the maximum satiety level you can consume at one time.


### i18n.json

```json
{
   "en": {
     "monster": {
       "CustomMonster": {
         "name": "Name",
         "desc": "Desc"
       }
     }
   }
}
```

This is text corresponding to the name and description of each monster.

### Custom Monster Type

In addition to the basic monster types above, new monster types can be added. Let's call the new monster type to be added `CustomMonsterType`.

```lua
kitchen_crisis.monster.register_type("CustomMonsterType");

kitchen_crisis.monster.CustomMonsterType = {
   attack_priority = function(setting, monster_id, dist)
     return dist;
   end
   damage_postprocess = function(setting, monster_id, damage, food)
     return damage;
   end
   anim = function(setting, monster_id)
     return "idle";
   end
   on_update = function(setting, monster_id, dt)
   end
}

```

You can add new monster types through `kitchen_crisis.monster.register_type`.

`setting`, the argument of the `attack_priority, damage_postprocess, anim, on_update` function, is the value defined in `monster.json` above and is delivered in table format.

The `attack_priority` function defines the attack priority. Smaller return values are attacked first. `dist`, which comes as an argument, means the remaining distance to the destination point (the portal where the monster exits). `monster_id` is an integer ID indicating the monster. If not defined separately, it is set to return the dist value.

The `damage_postprocess` function is called when a monster takes damage, and if necessary, it can return a modified damage value. The `monster_id` that comes as an argument is an integer ID that points to the monster. `damage` and `food` are real number and string types, respectively, and mean that damage equal to `damage` was suffered by cooking `food`. If not defined separately, `damage` entered as an argument is returned as is.

The `anim` function is a function that returns an animation tag to be displayed during the monster rendering process. The `monster_id` that comes as an argument is an integer ID that points to the monster. If not defined separately, it is rendered according to the basic rules. Since `_back` is automatically added according to the direction, you only need to return the basic animation tag.

The `on_update` function is called every frame. `monster_id`, which comes as an argument, is an integer ID indicating the monster, and `dt` is the delta time (in seconds) of the frame.