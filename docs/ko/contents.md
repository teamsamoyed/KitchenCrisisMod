# 컨텐츠 확장

kitchen crisis 내부의 각 컨텐츠를 확장 및 수정하는 방법에 대해 다룹니다.

## 보물

게임 내에서 추가할 유물의 unique ID를 `CustomRelic` 이라고 합시다. 보물을 추가하기 위해서는 아래의 파일들을 필수적으로 추가해야합니다.

- `assets/sprites/relics/CustomRelic.png` : 해당 보물의 인게임 아이콘 이미지입니다. 16x16 사이즈의 png 이미지여야합니다.
- `assets/settings/relic.json` : 보물과 관련한 수치 정보를 기록합니다. json 파일의 양식에 관해서는 아래에서 다시 설명합니다.
- `assets/settings/i18n.json` : 게임 내에서 나올 보물의 이름, 설명 정보입니다. 양식에 관해서는 아래에서 다시 설명합니다.

### relic.json

```json
{
  "CustomRelic": {
    "Value": 5
  }
}
```

위와 같은 형태로 각 보물이 사용할 세팅 값을 기록할 수 있습니다. 한 모드에서 여러 개의 보물을 추가할 경우 각 보물의 unique ID를 키로해서 위의 relic.json에 내용을 추가하면 됩니다.

### i18n.json

```json
{
  "en": {
    "relic": {
      "CustomRelic": {
        "name": "CustomRelic Name",
        "desc": "CustomRelic Desc, Value: {Value}"
      }
    }
  } 
}
```

위와 같은 형태로 각 보물의 이름 / 설명을 기록할 수 있습니다. 마찬가지로 한 모드에서 여러 개의 보물을 추가할 경우 각 보물의 unique ID를 키값으로, `lang/relic/key` 아래에 필요한 내용을 추가하면 됩니다.

### scripting

각 보물의 동작을 정의하기 위해 필요한 lua 스크립트입니다.

```lua
kitchen_crisis.relic.register("CustomRelic")

kitchen_crisis.relic.CustomRelic = {
  desc = function (setting)
    return kitchen_crisis.i18n_bind("relic.CustomRelic.desc", {
      Value = tostring(setting.Value)
    });
  end,
  prob = function (setting)
    return 1;
  end,
  on_get = function (setting)
  end
}
```

`desc, prob, on_get` 함수의 인자인 `setting`은 위의 `relic.json`에서 정의한 값이 table형태로 전달됩니다.

`desc` 함수는 해당 보물의 설명 텍스트를 반환하는 함수입니다. 위의 코드에서 처럼, `i18n_bind` 함수를 이용해 `1i8n.json` 에서 정의한 desc 값의 `{Value}`를 보물의 세팅 값(`relic.json`에 정의된)에서의 `Value` 인 `5` 로 변경할 수 있습니다.

`prob` 함수는 해당 보물이 보물 선택 과정에서 등장할 확률을 결정합니다. 게임의 기본 보물들의 등장 확률값은 1입니다.

`on_get` 함수는 게임 내에서 해당 보물을 처음 획득했을 때 호출됩니다. 여기서 보물의 효과를 정의할 수 있습니다.

## 소모품

## 재료

## 레시피

## 도구 강화

## 재료 강화

## 맵

## 캐릭터

## 몬스터

## 요리 시뮬레이션
