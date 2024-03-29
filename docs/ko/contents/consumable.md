
## 소모품

게임에 추가할 소모품의 unique ID를 `CustomConsumable` 이라고 합시다. 소모품을 추가하기 위해서는 아래의 파일들이 필요합니다.

- `assets/sprites/consumable/CustomConsumable.png` : 해당 소모품의 인게임 아이콘 이미지입니다. 16x16 사이즈의 png 이미지여야합니다.
- `assets/settings/consumable.json` : 소모품과 관련한 수치 정보를 기록합니다. json 파일의 양식은 아래에서 다시 설명합니다.
- `assets/settings/i18n.json` : 게임 내에서 나올 소모품의 이름, 설명 정보입니다. 양식은 아래에서 다시 설명합니다.

### consumable.json

```json
{
  "CustomConsumable": {
    "Value": 5
  }
}
```

위와 같은 형태로 각 소모품이 사용할 세팅 값을 기록할 수 있습니다. 한 모드에서 여러 개의 소모품을 추가할 경우 각 소모품의 unique ID를 키로해서 위의 consumable.json에 내용을 추가하면 됩니다.

### i18n.json

```json
{
  "en": {
    "consumable": {
      "CustomConsumable": {
        "name": "CustomConsumable Name",
        "desc": "CustomConsumable Desc, Value: {Value}"
      }
    }
  } 
}
```

위와 같은 형태로 각 소모품의 이름 / 설명을 기록할 수 있습니다. 한 모드에서 여러 개의 소모품을 추가할 경우 각 소모품의 unique ID를 키값으로, `lang/consumable/key` 아래에 필요한 내용을 추가하면 됩니다.

### scripting

각 소모품의 동작을 정의하기 위해 필요한 lua 스크립트입니다.

```lua
kitchen_crisis.consumable.register("CustomConsumable")

kitchen_crisis.consumable.CustomConsumable = {
  desc = function (setting)
    return kitchen_crisis.i18n_bind("relic.CustomConsumable.desc", {
      Value = tostring(setting.Value)
    });
  end
  on_get = function (setting)
  end
  run = function (setting)
  end
}
```

`kitchen_crisis.consumable.register`를 통해 만들고자 하는 소모품의 정보를 게임에 등록할 수 있습니다.

`desc, on_get, run` 함수의 인자인 `setting`은 위의 `consumable.json`에서 정의한 값이 table형태로 전달됩니다.

`desc` 함수는 해당 소모품의 설명 텍스트를 반환하는 함수입니다. 위의 코드에서 처럼, `i18n_bind` 함수를 이용해 `1i8n.json` 에서 정의한 desc 값의 `{Value}`를 소모품의 세팅 값(`consumable.json`에 정의된)에서의 `Value` 인 `5` 로 변경할 수 있습니다.

`on_get` 함수는 게임 내에서 해당 소모품을 처음 획득했을 때 호출됩니다.

`run` 함수는 게임 내에서 해당 소모품을 사용했을 때 호출됩니다.
