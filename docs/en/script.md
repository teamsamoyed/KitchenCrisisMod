# script

After kitchen crisis loads a mod, it runs the script if the mod's `assets/scripts/mod.lua` file exists.

If a `mod.lua` file requires other `.lua` files, all of those files are also loaded.

Asset loading rules are not applied on `require` in a script. Therefore, when referencing a file using `require`, it must be referenced in the form `require(./mods/(mod name)/assets/scripts/(script name).lua)`.

A list of kitchen crisis's internal APIs can be found at [api](api.md).

## structure

All APIs provided by kitchen crisis are defined in the `kitchen_crisis` table. APIs are further classified into sub-tables according to their respective purposes in that table. At a larger scale, the important subtables are:

- module: Provides an API to implement frame-by-frame operations, custom rendering, UI, etc. in each mode.
- save_data: Provides API related to game save data.
- global_event: Provides an API for subscribing to and publishing multiple events that occur in the entire game unit.
- session: Provides an API that starts game play and then manages the actual play internal state.
- render: Provides APIs related to various drawing operations.
- ui: Provides an API to create and manage UI.

Detailed content expansion information, such as strengthening tools used within the game, strengthening materials, treasures, and characters, can be found in [Content Expansion](contents.md).

###module

You can register your own module via `kitchen_crisis.module.register`. register receives (module name) and (module table) as arguments. At this time, the `update` function of the module table is executed every frame. Similarly, the `render` function is executed every frame, and if you need any drawing behavior, you can call the drawing function from this function.

If you need to provide your own UI, you can define an `init_ui` function in the table and create and return a custom UI from it. The created UI is set as the ui member value of the table, and can be referenced as `self.ui` in the update function and render function.

Below is an example of a simple module.

```lua
kitchen_crisis.module.register("TestModule", {
   init_ui = function()
     local ui = kitchen_crisis.ui.node("ui_test")
     ui:image("sprites/ui/test.png")
     ui:pos(300, 300)
     ui:size(kitchen_crisis.ui.length_px(100), kitchen_crisis.ui.length_px(100))
    
     return ui
   end
   update = function(self, dt)
     if self.ui:focus():type() ~= "normal" then
       self.ui:image("sprites/ui/test_hover.png")
     else
       self.ui:image("sprites/ui/test.png")
     end
   end,
   render = function(self)
     kitchen_crisis.render.draw_sprite("sprites/ui/test.png", 0, 0, 0, kitchen_crisis.render.layer.FRONT)
   end,
})
```

Create an image node named `ui_test` in `init_ui` and place it at the location (300, 300) with a size of 100x100. In the `update` function, you can see that the image changes depending on whether `ui` is in focus or not.

In the `render` function, the image is drawn at position 0,0,0 of the FRONT layer using draw_sprite.

Detailed API configuration can be found in [api](api.md).