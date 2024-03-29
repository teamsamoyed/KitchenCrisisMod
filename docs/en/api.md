#API

Here is the full list of APIs available in the mod

```lua
kitchen_crisis.log(message)
-- message: String
-- return: void
```

Output logs to the log.log file.

```lua
kitchen_crisis.i18n(key)
-- message: String
-- return: String
```

Returns a multilingual string corresponding to the key value according to the game's internal language settings.

```lua
kitchen_crisis.i18n_bind(key, map)
-- message: String
-- map: (key: String, value: String) table
```

Returns a multilingual string, but returns a string in which all `{Key}` parts in the string are replaced with the Value corresponding to the key.

##session

This is an API table that manages in-game information.

```lua
kitchen_crisis.session.add_limited_object(name, count)
-- name: String
-- count: int
```

Allows use of `count` additional cooking utensils.

```lua
kitchen_crisis.session.gold
```

```lua
kitchen_crisis.session.add_gold
```

```lua
kitchen_crisis.session.tool_upgrade_level
```

### event

###event_value

### map

## character

## consumable

## save_data

## upgrade

## relic

## global_event

## render

## module

## ui