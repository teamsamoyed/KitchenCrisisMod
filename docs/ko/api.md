# API

모드에서 사용할 수 있는 전체 API 목록입니다. 편의상, 넘겨 받는 인자의 타입을 `name: Type` 형태로 표시합니다.

```lua
kitchen_crisis.log(message: String): Void
```

log.log 파일에 로그를 출력합니다.

```lua
kitchen_crisis.i18n(key: String): String
```

게임 내부 언어 설정에 맞춰서 key 값에 대응되는 다국어 문자열을 반환합니다.

```lua
kitchen_crisis.i18n_bind(key: String, map: {String: String}): String
```

다국어 문자열을 반환하되, 문자열 내의 `{Value}` 부분을 모두 해당 키에 대응하는 Value로 치환한 문자열을 반환합니다.

```lua
kitchen_crisis.value_modifier(value)
```

## session

인게임 정보를 관리하는 API 테이블입니다.

```lua
kitchen_crisis.session.add_limited_object(name: String, count: Number)
```

`name` 요리 도구를 `count` 개 추가로 사용할 수 있게 합니다.

```lua
kitchen_crisis.session.gold()
```

```lua
kitchen_crisis.session.add_gold(added)
```

```lua
kitchen_crisis.session.tool_upgrade_level(name)
```

```lua
kitchen_crisis.session.play_speed()
```

```lua
kitchen_crisis.session.set_play_speed(speed)
```

### event

event는 kitchen crisis의 게임 내부에서 특정한 상황이 발생했을 때의 동작을 정의합니다. `add_listener`를 통해 해당 이벤트가 발생했을 때 수행할 동작을 정의할 수 있고, `trigger`를 통해 해당 이벤트를 발생시켜서 `add_listener`를 통해 등록된 콜백 함수들을 호출할 수 있습니다. `add_listener_with_end` 함수는 `end_func` 함수가 true를 반환하면 더이상 해당 이벤트가 발생했을 때에도 호출되지 않고 콜백 목록에서 제거됩니다. `end_func` 함수는 별개의 인자를 받지 않으며, `func` 함수는 `trigger`의 인자와 동일한 인자를 받는 함수여야 합니다.

각 상황에서 사용할 함수는 `kitchen_crisis.register_function(name, func)` 을 통해 등록할 수 있으며, 이렇게 등록한 함수의 이름을 각각 add_listener, add_listener_with_end의 인자로 넘기면 됩니다.

```lua
kitchen_crisis.session.event.on_open_wave.add_listener(func)
kitchen_crisis.session.event.on_open_wave.add_listener_with_end(func, end_func)
kitchen_crisis.session.event.on_open_wave.trigger()
```

```lua
kitchen_crisis.session.event.on_close_wave.add_listener(func)
kitchen_crisis.session.event.on_close_wave.add_listener_with_end(func, end_func)
kitchen_crisis.session.event.on_close_wave.trigger()
```

```lua
kitchen_crisis.session.event.on_start.add_listener(func)
kitchen_crisis.session.event.on_start.add_listener_with_end(func, end_func)
kitchen_crisis.session.event.on_start.trigger()
```

```lua
kitchen_crisis.session.event.on_die_monster.add_listener(func)
kitchen_crisis.session.event.on_die_monster.add_listener_with_end(func, end_func)
kitchen_crisis.session.event.on_die_monster.trigger(monster_id)
```

```lua
kitchen_crisis.session.event.on_add_gold.add_listener(func)
kitchen_crisis.session.event.on_add_gold.add_listener_with_end(func, end_func)
kitchen_crisis.session.event.on_add_gold.trigger(added)
```

```lua
kitchen_crisis.session.event.on_use_complete_object.add_listener(func)
kitchen_crisis.session.event.on_use_complete_object.add_listener_with_end(func, end_func)
kitchen_crisis.session.event.on_use_complete_object.trigger(object_name, worker)
```

```lua
kitchen_crisis.session.event.on_cook_complete.add_listener(func)
kitchen_crisis.session.event.on_cook_complete.add_listener_with_end(func, end_func)
kitchen_crisis.session.event.on_cook_complete.trigger(serve_id)
```

```lua
kitchen_crisis.session.event.on_session_wait_end.add_listener(func)
kitchen_crisis.session.event.on_session_wait_end.add_listener_with_end(func, end_func)
kitchen_crisis.session.event.on_session_wait_end.trigger()
```

```lua
kitchen_crisis.session.event.on_update_frame.add_listener(func)
kitchen_crisis.session.event.on_update_frame.add_listener_with_end(func, end_func)
kitchen_crisis.session.event.on_update_frame.trigger(dt)
```

```lua
kitchen_crisis.session.event.on_buy_worker.add_listener(func)
kitchen_crisis.session.event.on_buy_worker.add_listener_with_end(func, end_func)
kitchen_crisis.session.event.on_buy_worker.trigger()
```

```lua
kitchen_crisis.session.event.on_tool_upgrade.add_listener(func)
kitchen_crisis.session.event.on_tool_upgrade.add_listener_with_end(func, end_func)
kitchen_crisis.session.event.on_tool_upgrade.trigger()
```

```lua
kitchen_crisis.session.event.on_ingredient_upgrade.add_listener(func)
kitchen_crisis.session.event.on_ingredient_upgrade.add_listener_with_end(func, end_func)
kitchen_crisis.session.event.on_ingredient_upgrade.trigger()
```

```lua
kitchen_crisis.session.event.on_relic.add_listener(func)
kitchen_crisis.session.event.on_relic.add_listener_with_end(func, end_func)
kitchen_crisis.session.event.on_relic.trigger()
```

```lua
kitchen_crisis.session.event.on_damaged.add_listener(func)
kitchen_crisis.session.event.on_damaged.add_listener_with_end(func, end_func)
kitchen_crisis.session.event.on_damaged.trigger(damage, monster)
```

```lua
kitchen_crisis.session.event.on_get_menu.add_listener(func)
kitchen_crisis.session.event.on_get_menu.add_listener_with_end(func, end_func)
kitchen_crisis.session.event.on_get_menu.trigger(menu)
```

### event_value

event_value는 event와 유사하게 동작하나, 반환값을 통해 특정 수치를 나타내는 값을 변조하는데 쓰입니다. `add_listener`를 통해 해당 event value를 평가할 때 수행할 동작을 정의할 수 있고, `eval`을 통해 해당 event value에 대응되는 값을 평가할 수 있습니다. `eval`의 첫번째 인자는 평가하고자 하는 값의 기본 수치이며, `add_listener`를 통해 등록된 값은 넘어온 첫번째 인자값을 적절히 수정하여 반환해야합니다. 첫번째 인자를 제외한 나머지 인자는 동일한 값이 이후 `add_listener`에도 동일하게 전달되며, 첫번째 인자는 앞선 `add_listener` 호출을 통해 변환된 값이 전달됩니다. `fold`, `aggregate`의 동작과 유사한 방식이라고 생각하시면 편합니다.

`add_listener_with_end` 함수는 `end_func` 함수가 true를 반환하면 더이상 해당 이벤트가 발생했을 때에도 호출되지 않고 콜백 목록에서 제거됩니다. `end_func` 함수는 별개의 인자를 받지 않으며, `func` 함수는 `eval`의 인자와 동일한 인자를 받는 함수여야 합니다.

각 상황에서 사용할 함수는 `kitchen_crisis.register_function(name, func)` 을 통해 등록할 수 있으며, 이렇게 등록한 함수의 이름을 각각 add_listener, add_listener_with_end의 인자로 넘기면 됩니다.

```lua
kitchen_crisis.session.event_value.alloc_limit.add_listener(func)
kitchen_crisis.session.event_value.alloc_limit.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.alloc_limit.eval(limit, map_object)
```

```lua
kitchen_crisis.session.event_value.stack.add_listener(func)
kitchen_crisis.session.event_value.stack.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.stack.eval(value, recipe, is_view)
```

```lua
kitchen_crisis.session.event_value.cook_time.add_listener(func)
kitchen_crisis.session.event_value.cook_time.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.cook_time.eval(time, job)
```

```lua
kitchen_crisis.session.event_value.cook_time_view.add_listener(func)
kitchen_crisis.session.event_value.cook_time_view.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.cook_time_view.eval(time, map_object)
```

```lua
kitchen_crisis.session.event_value.serve_time_base.add_listener(func)
kitchen_crisis.session.event_value.serve_time_base.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.serve_time_base.eval(time, recipe)
```

```lua
kitchen_crisis.session.event_value.serve_time_mult_fast.add_listener(func)
kitchen_crisis.session.event_value.serve_time_mult_fast.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.serve_time_mult_fast.eval(mult, recipe)
```

```lua
kitchen_crisis.session.event_value.serve_time_mult_slow.add_listener(func)
kitchen_crisis.session.event_value.serve_time_mult_slow.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.serve_time_mult_slow.eval(mult, recipe)
```

```lua
kitchen_crisis.session.event_value.attack_range.add_listener(func)
kitchen_crisis.session.event_value.attack_range.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.attack_range.eval(range, recipe)
```

```lua
kitchen_crisis.session.event_value.attack_range_mult.add_listener(func)
kitchen_crisis.session.event_value.attack_range_mult.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.attack_range_mult.eval(mult, serve_id)
```

```lua
kitchen_crisis.session.event_value.cook_bullet.add_listener(func)
kitchen_crisis.session.event_value.cook_bullet.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.cook_bullet.eval(bullets)
```

```lua
kitchen_crisis.session.event_value.cook_base_ratio.add_listener(func)
kitchen_crisis.session.event_value.cook_base_ratio.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.cook_base_ratio.eval(ratio, monster, recipe)
```

```lua
kitchen_crisis.session.event_value.cook_result.add_listener(func)
kitchen_crisis.session.event_value.cook_result.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.cook_result.eval(result, recipe)
```

```lua
kitchen_crisis.session.event_value.cook_after_eat_count.add_listener(func)
kitchen_crisis.session.event_value.cook_after_eat_count.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.cook_after_eat_count.eval(count, recipe)
```

```lua
kitchen_crisis.session.event_value.cook_lock.add_listener(func)
kitchen_crisis.session.event_value.cook_lock.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.cook_lock.eval(lock_type, job_work)
```

```lua
kitchen_crisis.session.event_value.cook_next_stack.add_listener(func)
kitchen_crisis.session.event_value.cook_next_stack.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.cook_next_stack.eval(lock_type, job_work)
```

```lua
kitchen_crisis.session.event_value.after_eat.add_listener(func)
kitchen_crisis.session.event_value.after_eat.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.after_eat.eval(cook_result, cook_bullet, depth, order)
```

```lua
kitchen_crisis.session.event_value.worker_cook_stat.add_listener(func)
kitchen_crisis.session.event_value.worker_cook_stat.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.worker_cook_stat.eval(stat, worker, conditional)
```

```lua
kitchen_crisis.session.event_value.worker_move_stat.add_listener(func)
kitchen_crisis.session.event_value.worker_move_stat.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.worker_move_stat.eval(stat, worker, conditional)
```

```lua
kitchen_crisis.session.event_value.robot_move_stat.add_listener(func)
kitchen_crisis.session.event_value.robot_move_stat.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.robot_move_stat.eval(stat, worker, conditional)
```

```lua
kitchen_crisis.session.event_value.worker_cook_speed.add_listener(func)
kitchen_crisis.session.event_value.worker_cook_speed.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.worker_cook_speed.eval(speed, worker)
```

```lua
kitchen_crisis.session.event_value.worker_cook_mult.add_listener(func)
kitchen_crisis.session.event_value.worker_cook_mult.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.worker_cook_mult.eval(mult, worker)
```

```lua
kitchen_crisis.session.event_value.worker_move_speed.add_listener(func)
kitchen_crisis.session.event_value.worker_move_speed.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.worker_move_speed.eval(speed, worker)
```

```lua
kitchen_crisis.session.event_value.worker_move_mult.add_listener(func)
kitchen_crisis.session.event_value.worker_move_mult.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.worker_move_mult.eval(mult, worker)
```

```lua
kitchen_crisis.session.event_value.is_worker_move_buff.add_listener(func)
kitchen_crisis.session.event_value.is_worker_move_buff.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.is_worker_move_buff.eval(is_buff, worker)
```

```lua
kitchen_crisis.session.event_value.jump_range.add_listener(func)
kitchen_crisis.session.event_value.jump_range.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.jump_range.eval(range)
```

```lua
kitchen_crisis.session.event_value.job_cook_speed.add_listener(func)
kitchen_crisis.session.event_value.job_cook_speed.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.job_cook_speed.eval(speed, recipe, to, result, worker)
```

```lua
kitchen_crisis.session.event_value.eat_data.add_listener(func)
kitchen_crisis.session.event_value.eat_data.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.eat_data.eval(cook_result, monster, cook_bullet)
```

```lua
kitchen_crisis.session.event_value.eat_data_last_effect.add_listener(func)
kitchen_crisis.session.event_value.eat_data_last_effect.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.eat_data_last_effect.eval(cook_result, monster, cook_bullet)
```

```lua
kitchen_crisis.session.event_value.gold_bonus.add_listener(func)
kitchen_crisis.session.event_value.gold_bonus.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.gold_bonus.eval(bonus)
```

```lua
kitchen_crisis.session.event_value.recipe_overlap_prob.add_listener(func)
kitchen_crisis.session.event_value.recipe_overlap_prob.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.recipe_overlap_prob.eval(prob)
```

```lua
kitchen_crisis.session.event_value.upgrade_cost.add_listener(func)
kitchen_crisis.session.event_value.upgrade_cost.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.upgrade_cost.eval(cost, upgrade_type)
```

```lua
kitchen_crisis.session.event_value.monster_cc_time_multiply.add_listener(func)
kitchen_crisis.session.event_value.monster_cc_time_multiply.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.monster_cc_time_multiply.eval(mult, monster)
```

```lua
kitchen_crisis.session.event_value.monster_reverse_move.add_listener(func)
kitchen_crisis.session.event_value.monster_reverse_move.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.monster_reverse_move.eval(is_reverse, monster)
```

```lua
kitchen_crisis.session.event_value.monster_move_speed.add_listener(func)
kitchen_crisis.session.event_value.monster_move_speed.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.monster_move_speed.eval(speed, monster)
```

```lua
kitchen_crisis.session.event_value.monster_move_speed_mult.add_listener(func)
kitchen_crisis.session.event_value.monster_move_speed_mult.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.monster_move_speed_mult.eval(mult, monster)
```

```lua
kitchen_crisis.session.event_value.monster_in_time.add_listener(func)
kitchen_crisis.session.event_value.monster_in_time.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.monster_in_time.eval(in_time)
```

```lua
kitchen_crisis.session.event_value.monster_hp_mult.add_listener(func)
kitchen_crisis.session.event_value.monster_hp_mult.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.monster_hp_mult.eval(mult)
```

```lua
kitchen_crisis.session.event_value.damage_mult.add_listener(func)
kitchen_crisis.session.event_value.damage_mult.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.damage_mult.eval(mult, monster)
```

```lua
kitchen_crisis.session.event_value.max_menu_count.add_listener(func)
kitchen_crisis.session.event_value.max_menu_count.add_listener_with_end(func, end_func)
kitchen_crisis.session.event_value.max_menu_count.eval(cnt)
```

### map

```lua
kitchen_crisis.map.get_object(x, y)
```

## save_data

```lua
kitchen_crisis.save_data.unlock_tool_upgrade(upgrade)
```

```lua
kitchen_crisis.save_data.unlock_character(character)
```

```lua
kitchen_crisis.save_data.unlock_ingredient(ingredient)
```

## global_event

```lua
kitchen_crisis.global_event.on_start_game.add_listener(func)
kitchen_crisis.global_event.on_start_game.add_listener_with_end(func, end_func)
kitchen_crisis.global_event.on_start_game.trigger(character, stage_index, chaos_level)
```

## render

```lua
kitchen_crisis.render.draw_sprite(name, x, y, z, layer)
```

```lua
kitchen_crisis.render.draw_sprite_ex(name, x, y, z, layer, rotate, anchor_x, anchor_y, color, flip_x, flip_y)
```

```lua
kitchen_crisis.render.draw_animation(name, tag, x, y, z, layer)
```

```lua
kitchen_crisis.render.draw_animation_ex(name, tag, x, y, z, layer, anim_time, rotate, anchor_x, anchor_y, color, flip_x, flip_y,)
```

## ui

```lua
kitchen_crisis.ui.node(id)
```

```lua
kitchen_crisis.ui.length_px(value)
kitchen_crisis.ui.length_percent(value)
kitchen_crisis.ui.length_auto()
```

```lua
kitchen_crisis.ui.child_type_free()
kitchen_crisis.ui.child_type_left_to_right(margin)
kitchen_crisis.ui.child_type_top_to_bottom(margin)
kitchen_crisis.ui.child_type_table(margin_x, margin_y)
```

```lua
kitchen_crisis.ui.pos_type_relative()
kitchen_crisis.ui.pos_type_screen_absolute()
```

```lua
kitchen_crisis.ui.normal_button(id, text, text_size)
```

## client

### event_value

```lua
kitchen_crisis.client.event_value.supported_language.add_listener(func)
kitchen_crisis.client.event_value.supported_language.add_listener_with_end(func, end_func)
kitchen_crisis.client.event_value.supported_language.eval(languages)
```

```lua
kitchen_crisis.client.event_value.font_name.add_listener(func)
kitchen_crisis.client.event_value.font_name.add_listener_with_end(func, end_func)
kitchen_crisis.client.event_value.font_name.eval(font_name, lang)
```

## types

kitchen crisis 내부 값을 표현하는 커스텀 타입들입니다.

### Pos3

```lua
this.x
this.y
this.z
this:round_to_int() : Pos3Int
this:distance(p)
this:move_towards(goal, dist)
this:normalize()
this:dot(p)
this:size()
```

### Pos3Int

```lua
this.x
this.y
this.z
this:distance(p)
```

### MapObjectConfig

```lua
this.is_block
this.can_remove
this.alloc_limit
this.modifier
this.ignore_filter
this:need_ingredients(in_place)
this:tool_name(parent)
this:need_stores(to_process)
this:process_id(parent)
this:need_process()
this:need_tool_names()
this:need_process_count()
this:tier()
this:stack_ignore_upgrade()
this:stack(view)
this:step()
this:attack_ignore_upgrade()
this:attack()
this:serve_time_ignore_upgrade()
this:serve_time()
this:attack_range_ignore_upgrade()
this:attack_range()
this:cook_result_ignore_upgrade()
this:cook_result()
```

### MapObjectModifierConfig

```lua
this.attack
this.cook_time
```

### ToolNameType

```lua
this:place_count()
this:id()
this:to_process()
this:is_box()
```

### Recipe

```lua
this.required
this.process
this.result
this.is_menu
```

### StageIndexType

```lua
this:category()
this:header()
this:index()
```

### CookBullet

```lua
this.menu
this.target_monster_id
this.pos
this.from_obj_id
this.ratio
this.range
this.make_time
this.is_after_attack
this.can_return
this.is_in_return

this:recipe()
this:clone()
```

### CookResult

```lua
this.attack
this.attack_critical_prob
this.attack_critical
this.ratio
this.effects

this:add_attack_const(added)
this:add_attack_mult(added)
this:mult_attack_value(mult)
```

### MapObject

```lua
this:can_alloc()
this:is_normal_tool()
this:is_block_object()
this:obj_id()
this:set_obj_id(id)
this:clear_obj_id()
this:is_same_obj(obj)
this:is_box()
this:is_box_with(ingredient)
this:is_set_serve()
this:is_non_empty_serve()
this:next_serve_time()
this:is_wall()
this:is_portal()
this:alloc_limit()
this:interactions()
this:interaction_tiles()
this:is_working()
this:range(obj_id)
this:name()
```

### Monster

```lua
this:id()
this:name()
this:pos()
```

### LockType

```lua
this:is_locked()
this:need_touch()
this:auto()
this:need_touch_or_locked()
```

### JobWork

```lua
this.id
this.required
this.process
this.result
this.menu
this.report_id
this.allocated_object
this.allocated_worker
this.serve
this.stage
this.overlap_order
this.run_shadow_check
this.throw_length
this.last_alloc_check
this.failed_allocs
```

### Element

```lua
this:name()
this:enabled()
this:is_same_type(other)
this:is_slider()
this:is_image()
this:is_none()
this:is_label()
this:is_canvas()
this:is_scroll()
```

### PosType

```lua
this:is_relative()
this:is_screen_absolute()
```

### ChildType

### Length

### FocusState

```lua
this:type()
```

### Node

```lua
this:image(path)
this:label(text)
this:element()
this:pos(x, y)
this:size(w, h)
this:child_type(child_type)
this:anchor(x, y)
this:pivot(x, y)
this:pos_type(pos_type)
this:focus()
this:is_clicked()
this:set_children(children)
this:add_child(child)
this:child(id)
```

### Value
