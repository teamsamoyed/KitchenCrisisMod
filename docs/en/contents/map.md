# map

You can distribute the custom map you created using the mod.

When you create a map using the game's map editor tool, a map file corresponding to the created map is created in the custom_maps/ folder in the folder where the game is installed.

If you copy this file under `assets/maps/` of the mod you want to distribute, the custom map will be distributed together with the mod. At this time, if you specify the `"custom_map_name"` field in the `info.json` of the mode you are distributing, the maps will be displayed with that name in a new game window within the game. For example, let's say you set `"custom_map_name"` to `"test"` and put `map1.map` and `map2.map` under `assets/maps/`.

In this case, within the new game you will be able to select maps `test 1` and `test 2` at the bottom of the window. Index numbers are assigned by reading the maps existing under the `maps` folder in alphabetical order.
