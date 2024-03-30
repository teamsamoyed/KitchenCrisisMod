# API

모드에서 사용할 수 있는 전체 API 목록입니다

```lua
kitchen_crisis.log(message)
-- message: String
-- return: void
```

log.log 파일에 로그를 출력합니다.

```lua
kitchen_crisis.i18n(key)
-- message: String
-- return: String
```

게임 내부 언어 설정에 맞춰서 key 값에 대응되는 다국어 문자열을 반환합니다.

```lua
kitchen_crisis.i18n_bind(key, map)
-- message: String
-- map: (key: String, value: String) table
```

다국어 문자열을 반환하되, 문자열 내의 `{Key}` 부분을 모두 해당 키에 대응하는 Value로 치환한 문자열을 반환합니다.

## session

인게임 정보를 관리하는 API 테이블입니다.

```lua
kitchen_crisis.session.add_limited_object(name, count)
-- name: String
-- count: int
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

### event

event는 kitchen crisis의 게임 내부에서 특정한 상황이 발생했을 때의 동작을 정의합니다. `add_listener`를 통해 해당 이벤트가 발생했을 때 수행할 동작을 정의할 수 있고, `trigger`를 통해 해당 이벤트를 발생시켜서 `add_listener`를 통해 등록된 콜백 함수들을 호출할 수 있습니다. `add_listener_with_end` 함수는 `end_func` 함수가 true를 반환하면 더이상 해당 이벤트가 발생했을 때에도 호출되지 않고 콜백 목록에서 제거됩니다. `end_func` 함수는 별개의 인자를 받지 않으며, `func` 함수는 `trigger`의 인자와 동일한 인자를 받는 함수여야 합니다.

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

```lua
kitchen_crisis.session.event_value.alloc_limit.add_listener(func)
kitchen_crisis.session.event_value.alloc_limit.add_listener_with_end(func)
kitchen_crisis.session.event_value.alloc_limit.trigger(limit, map_object)
```

```lua
kitchen_crisis.session.event_value.stack.add_listener(func)
kitchen_crisis.session.event_value.stack.add_listener_with_end(func)
kitchen_crisis.session.event_value.stack.trigger(value, recipe, is_view)
```

```lua
kitchen_crisis.session.event_value.cook_time.add_listener(func)
kitchen_crisis.session.event_value.cook_time.add_listener_with_end(func)
kitchen_crisis.session.event_value.cook_time.trigger(time, job)
```

```lua
kitchen_crisis.session.event_value.cook_time_view.add_listener(func)
kitchen_crisis.session.event_value.cook_time_view.add_listener_with_end(func)
kitchen_crisis.session.event_value.cook_time_view.trigger(time, map_object)
```

```lua
kitchen_crisis.session.event_value.serve_time_base.add_listener(func)
kitchen_crisis.session.event_value.serve_time_base.add_listener_with_end(func)
kitchen_crisis.session.event_value.serve_time_base.trigger(time, recipe)
```

```lua
kitchen_crisis.session.event_value.serve_time_mult_fast.add_listener(func)
kitchen_crisis.session.event_value.serve_time_mult_fast.add_listener_with_end(func)
kitchen_crisis.session.event_value.serve_time_mult_fast.trigger(mult, recipe)
```

```lua
kitchen_crisis.session.event_value.serve_time_mult_slow.add_listener(func)
kitchen_crisis.session.event_value.serve_time_mult_slow.add_listener_with_end(func)
kitchen_crisis.session.event_value.serve_time_mult_slow.trigger(mult, recipe)
```

```lua
kitchen_crisis.session.event_value.attack_range.add_listener(func)
kitchen_crisis.session.event_value.attack_range.add_listener_with_end(func)
kitchen_crisis.session.event_value.attack_range.trigger(range, recipe)
```

```lua
kitchen_crisis.session.event_value.attack_range_mult.add_listener(func)
kitchen_crisis.session.event_value.attack_range_mult.add_listener_with_end(func)
kitchen_crisis.session.event_value.attack_range_mult.trigger(mult, serve_id)
```

### map

## save_data

## global_event

## render

## ui

## types

kitchen crisis 내부 값을 표현하는 커스텀 타입들입니다.
