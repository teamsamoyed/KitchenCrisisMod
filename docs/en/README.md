The English guide document was created using machine translation. There may be ambiguous or strange expressions.

# Guide

In Kitchen Crisis, most of the content in the game can be modified and expanded through modding.

## Custom Mod

All mods for Kitchen Crisis are placed in the mods/ subdirectory of the folder where the game is installed. mods/base is a mod that stores the game's base assets.

When creating a new mod, create a folder with `mods/(mod name)` according to the name of the mode you want to create. Mods for Kitchen Crisis have the following file structure by default under `mods/(mod name)`:

- info.json: A file that defines mode information.
- assets/: A folder that manages the list of assets included in the mode.

The `info.json` file has the following format:

```json
{
   "name": "test",
   "i18n_name": {
     "en": "test",
     "en": "test"
   },
   "description": {
     "en": "test mod",
     "en": "Mode Description"
   },
   "author": "kitchen crisis",
   "version": "0.1.0",
   "enabled": true,
   "dependency": {
     "test2": "0.2.0"
   }
}
```

- name: This is the unique ID of the mod. We recommend using the same value as the folder name. The name must not overlap with other modes.
- i18n_name: This is the name that appears in the mode management window within the game. Set a value for how it will look based on the country code set in the game. Supported language codes are as follows: If not set, it is displayed in English by default according to the 'en' key, so the English name must exist.
   - ko : Korean
   -en: English
   - jp: Japanese
   - cn: Simplified Chinese
   - cn_cht: Traditional Chinese
- description: This is the mode description text that appears in the mode management window within the game. Likewise, set the value according to your country code. If it is not set, it will be displayed in English according to the 'en' key, so the English description must exist.
- author: Mode author information.
- version: Mode version.
- enabled: If false, the mode will not be loaded when the game runs.
- dependency: Information about other mods required by this mod. All mods are loaded in the order that they satisfy their dependencies. The required version information can be expressed in the form of "major", "major.minor", "major.minor.patch", and if the installed mod does not meet the version, the mod is automatically disabled during the loading process. major, minor, and patch must be integers greater than or equal to 0. You can also use "!" in the version information, which means that you can't use that mod with this one.

## Asset Management

In Kitchen Crisis' modding system, each asset is referenced by a path relative to `mod/(mod name)/assets/`. This means that the assets are read without distinction by the name of the mod. Using this, you can replace the basic assets within the base or assets from other modes.

For example, in kitchen crisis, the image of the cutting board is referenced by the path `sprites/map_object/board.png`. By default this file is located in `mods/base/assets/sprites/map_object/board.png`. If you create a new mode, `mod1`, and that mode includes an image file in the location `mod/mod1/assets/sprites/map_object/board.png`, the cutting board image will be overwritten with the cutting board image under `mod1`. It is covered.

In Kitchen Crisis, each asset is classified based on its extension. The types of assets available in Kitchen Crisis mode are as follows:

- .png: Image file.
- .anim: A file that defines how to play animation from a sprite sheet. It must have the same file name as the sprite sheet. The format of the anim file has the same form as the animation exported in Array format in aseprite.
- .wav: Sound file.
- .map: Saves map information.

A list of default built-in assets for the Kitchen Crisis game can be found in [Assets](assets.md).

###Settings

Files ending with the `.json` extension under `assets/settings/` are treated specially.

- `settings/character.json`: Responsible for character information. Internally, if the key values overlap, the existing character information is overwritten, and if the keys do not overlap, new character information is added. The following settings files also work in the same way.
- `settings/consumable.json`: Responsible for consumable information.
- `settings/ingredient_upgrade.json`: Responsible for material enhancement information.
- `settings/map_object.json`: Responsible for information on tools placed in the kitchen.
- `settings/mastery.json`: Responsible for characteristic information.
- `settings/monster.json`: Responsible for monster information.
- `settings/receipe.json`: Responsible for recipe information.
- `settings/relic.json`: Responsible for treasure information.
- `settings/setting.json`: Responsible for basic setting value information. It is possible to overwrite all settings, but we recommend leaving them untouched if possible.
- `settings/stage.json`: Responsible for stage information.
- `settings/tool_upgrade.json`: Responsible for tool enhancement information.
- `settings/i18n.json`: Responsible for i18n information.

The format and usage of each `json` file is covered in detail in [Content Extension](contents.md).

## Scripts

You can extend the game logic using scripts written in lua. More information about how to write a script can be found in [Script](script.md).

## Upload

Please refer to the [Mod Upload](upload.md) document for the process of uploading your created mod to the Steam Creative Commons.