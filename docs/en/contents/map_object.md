## Cooking tools

Let's call the unique ID of the cooking tool to be added to the game `CustomMapObject`. The files below are required to add cooking tools.

- `assets/sprites/map_object/custommapobject.png`: Image file of the cooking tool. The name must be the unique ID converted to all lowercase letters. Please pay attention to capitalization.
- `assets/sprites/map_object/custommapobject_use.png`: If it is a tool used in the actual cooking process, this is an image corresponding to the state in which the tool is being used. Unless it is a tool used in the actual cooking process, such as an object such as a portal, it is okay to not have it.
- `assets/sprites/map_object/custommapobject_max.png`: There is a tool enhancement called `CustMapObjectUpgrade`, and this is the image to be used to display the mapobject when the tool enhancement has been upgraded to the maximum. If you don't have a corresponding tool enhancement, you can do without it.
- `assets/sprites/map_object/custommapobject_max_use.png`: This is the image used when max upgraded. Similarly, if there is no applicable case, it does not need to exist.

- `assets/settings/map_object.json`: Defines the properties of the corresponding cooking tool. The form is discussed again below.

- `assets/settings/i18n.json`: Information on the name of the cooking tool that will appear in the game. The form is discussed again below.

## map_object.json

```json
{
   "CustomMapObject": {
     "IsBlock": true,
     "CanRemove": true,
     "AllocLimit": 1,
     "Modifier": {
       "Attack": 1.1,
       "CookTime": 1
     },
     "IgnoreFilter": true,
     "IgnoreWarn": true
   }
}
```

- `IsBlock`: Whether it is possible to pass over the object.
- `CanRemove`: Whether the player can freely place/remove during the placement phase.
- `AllocLimit`: For tools used in the cooking process, indicates the number of clones that can be used simultaneously. If it is not a tool used in the cooking process, it can be omitted.
- `Modifier`: If it is a tool used in the cooking process, it is a factor that determines the specifications of the recipe when included in the recipe. The attack power of the recipe increases by the `Attack` multiplier, and `CookTime` refers to the time it takes to complete using the tool. If it is not a tool used in the cooking process, it can be omitted.
- `IgnoreFilter`: Determines whether it is visible in the cooking tool list in the recipe window.
- `IgnoreWarn`: Determines whether a warning will be displayed or not. If false, a warning will be displayed if a recipe using the tool is placed when it does not exist.

## i18n.json

```json
{
   "en": {
     "map_object": {
       "CustomMapObject": "CustomMapObject"
     }
   }
}
```

Defines text that displays the name of the cooker.