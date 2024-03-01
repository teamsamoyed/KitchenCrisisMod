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

## character

## consumable

## save_data

## upgrade

## relic

## global_event

## render

## module

## ui