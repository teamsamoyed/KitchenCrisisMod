# 컨텐츠 확장

kitchen crisis 내부의 각 컨텐츠를 확장 및 수정하는 방법에 대해 다룹니다.

## 보물

게임 내에서 추가할 유물의 unique ID를 `CustomRelic` 이라고 합시다. 보물을 추가하기 위해서는 아래의 파일들이 필요합니다.

- `assets/sprites/relics/CustomRelic.png` : 해당 보물의 인게임 아이콘 이미지입니다. 16x16 사이즈의 png 이미지여야합니다.
- `assets/settings/relic.json` : 보물과 관련한 수치 정보를 기록합니다. json 파일의 양식은 아래에서 다시 설명합니다.
- `assets/settings/i18n.json` : 게임 내에서 나올 보물의 이름, 설명 정보입니다. 양식은 아래에서 다시 설명합니다.

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

`kitchen_crisis.relic.register`를 통해 만들고자 하는 보물의 정보를 게임에 등록할 수 있습니다.

`desc, prob, on_get` 함수의 인자인 `setting`은 위의 `relic.json`에서 정의한 값이 table형태로 전달됩니다.

`desc` 함수는 해당 보물의 설명 텍스트를 반환하는 함수입니다. 위의 코드에서 처럼, `i18n_bind` 함수를 이용해 `1i8n.json` 에서 정의한 desc 값의 `{Value}`를 보물의 세팅 값(`relic.json`에 정의된)에서의 `Value` 인 `5` 로 변경할 수 있습니다.

`prob` 함수는 해당 보물이 보물 선택 과정에서 등장할 확률을 결정합니다. 게임의 기본 보물들의 등장 확률값은 1입니다.

`on_get` 함수는 게임 내에서 해당 보물을 처음 획득했을 때 호출됩니다. 여기서 보물의 효과를 정의할 수 있습니다.

## 소모품

게임 내에서 추가할 소모품의 unique ID를 `CustomConsumable` 이라고 합시다. 소모품을 추가하기 위해서는 아래의 파일들이 필요합니다.

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

## 재료

게임 내에서 추가할 재료의 unique ID 를 `CustomIngredient`라고 합시다. 재료를 추가하기 위해서는 아래의 파일들이 필요합니다.

- `assets/sprites/food/CustomIngredient.png` : 해당 재료의 인게임 아이콘 이미지입니다. 16x16 사이즈의 png 이미지여야합니다.
- `assets/settings/i18n.json` : 게임 내에서 나올 재료의 이름, 설명 정보입니다. 양식은 아래에서 다시 설명합니다.


### i18n.json

```json
{
  "en": {
    "ingredient": {
      "CustomIngredient": "CustomIngredient Name",
      "desc": {
        "CustomIngredient": "CustomIngredient Desc",
      }
    }
  } 
}
```

위와 같은 형태로 각 소모품의 이름 / 설명을 기록할 수 있습니다. 한 모드에서 여러 개의 재료를 추가할 경우 각 재료의 unique ID를 키값으로, `lang/ingredient/key`, `lang/ingredient/desc/key` 아래에 필요한 내용을 추가하면 됩니다.

## 레시피

추가하고자하는 레시피의 이름을 `CustomRecipe.json`이라고 합시다. 레시피를 추가하기 위해서는 아래의 파일들이 필요합니다.

- `assets/sprite/food/CustomRecipe.json` : 해당 레시피의 인게임 아이콘 이미지입니다. 16x16 사이즈의 png 이미지여야합니다.
- `assets/recipe.json` : 레시피의 요리 과정을 정의합니다. 양식은 아래에서 다시 설명합니다.
- `assets/settings/i18n.json` : 게임 내에서 나올 요리의 이름 정보입니다. 양식은 아래에서 다시 설명합니다.

### recipe.json

```json
{
  "CustomRecipe": {
    "Required": [
    ],
    "Process": "Pan",
    "Result": "CustomRecipe",
    "IsMenu": true
  }
}
```

`Required` 는 해당 레시피를 만들기 위해 필요한 이전 단계 레시피 목록입니다. `Process`는 요리를 진행하기 위해 필요한 도구를 의미합니다. 도구별 키값은 다음과 같습니다.

- Store : 재료 상자. 재료 상자의 경우 반드시 Required는 빈 배열이어야합니다.
- Board : 도마
- Pan : 프라이팬
- Fryer : 튀김기
- Oven : 오븐
- Pot : 냄비
- Empty : 조리대

`Result`는 키 값과 동일한 값이어야 합니다. `IsMenu`는 메뉴로 사용할 레시피의 경우 true, 중간 단계로 이용되는 레시피이지만 메뉴는 아닌 경우 false입니다.

### i18n.json

```json
{
  "en": {
    "ingredient": {
      "CustomRecipe": "CustomRecipe Name"
    }
  }
}
```

위와 같은 형태로 각 레시피의 이름을 기록할 수 있습니다. 한 모드에서 여러 개의 레시피를 추가할 경우 각 보물의 unique ID를 키값으로, `lang/ingredient/key` 아래에 필요한 내용을 추가하면 됩니다.

## 도구 강화

게임 내에서 추가할 도구 강화의 unique ID를 `CustomToolUpgrade` 라고 합시다. 도구 강화를 추가하기 위해서는 아래의 파일들이 필요합니다.
- `assets/sprites/tool_upgrades/CustomToolUpgrade.png` : 해당 도구 강화의 인게임 아이콘 이미지입니다. 16x16 사이즈의 png 이미지여야합니다.
- `assets/sprites/tool_upgrades/CustomToolUpgradeMain.png` : 해당 도구 강화를 최대 강화했을 때의 인게임 아이콘 이미지입니다. 16x16 사이즈의 png 이미지여야합니다.
- `assets/settings/tool_upgrade.json` : 도구 강화와 관련한 수치 정보를 기록합니다. json 파일의 양식은 아래에서 다시 설명합니다.
- `assets/settings/i18n.json` : 게임 내에서 나올 도구 강화의 이름, 설명 정보입니다. 양식은 아래에서 다시 설명합니다.

### tool_upgrade.json

```json
{
  "CustomToolUpgrade": [
    "Value": [
      1,
      2,
      3,
      4,
      5,
      6,
      7,
      8,
      9,
      10
    ]
  ]
}
```

위와 같은 형태로 각 도구강화가 사용할 세팅 값을 기록할 수 있습니다. 한 모드에서 여러 개의 도구 강화를 추가할 경우 각 도구 강화의 unique ID를 키로해서 위의 tool_upgrade.json에 내용을 추가하면 됩니다.

### i18n.json

```json
{
  "en": {
    "CustomToolUpgrade": {
      "name": "CustomTool Name",
      "desc": "CustomTool Desc {Value}",
      "main_name": "CustomTool MainName",
      "main_desc": "CustomTool MainDesc {Value}",
      "guide_desc": "CustomTool Guide Desc",
      "main_guide_desc": "CustomTool MainGuide Desc"
    }
  }
}
```

`name, desc`는 각각 도구 강화의 이름, 설명, `main_name, main_desc`는 최대 강화시의 이름, 설명, `guide_desc`와 `main_guide_desc`는 타이틀 화면의 도감 창에서 보여주는 기본/ 최대 도구 강화의 설명 텍스트입니다.

### scripting

도구 강화의 동작을 정의하기 위해 필요한 lua 스크립트입니다.

```lua

kitchen_crisis.upgrade.tool.register("CustomToolUpgrade")
kitchen_crisis.save_data.unlock_tool_upgrade("CustomToolUpgrade")

kitchen_crisis.upgrade.tool.CustomToolUpgrade = {
  view_desc = function(setting, now, nxt)
    return kitchen_crisis.i18n_bind("upgrade.tool.CustomToolUpgrade.desc", {
      Value = tostring(setting.Value[now + 1].Value)
    })
  end,
  max_count = function(setting)
    return #setting.Value
  end,
  run_upgrade_first = function(setting)
  end,
  run_upgrade = function(setting, level)
  end
}
```

`kitchen_crisis.tool_upgrade.register`를 통해 만들고자 하는 도구 강화의 정보를 게임에 등록할 수 있습니다. `kitchen_crisis.save_data.unlock_tool_upgrade`를 통해 도구 강화를 해금할 수 있습니다. 등록을 하더라도 해금하지 않는다면 게임 내에서 선택지에 등장하지 않습니다.

`view_desc, max_count, run_upgrade_first, run_upgrade` 함수의 인자인 `setting`은 위의 `tool_upgrade.json`에서 정의한 값이 table형태로 전달됩니다.

`view_desc` 함수는 도구 강화 설명 텍스트를 반환하는 함수입니다. now는 현재 레벨, nxt는 다음 레벨입니다. now, nxt의 경우 0 이상 max_count 이하 범위의 값입니다. 강화 선택에서는 now, nxt가 서로 다른 값으로 주어지고(now = 현재 강화 레벨, nxt = 강화를 골랐을 경우의 레벨), 단순 설명 화면에서는 동일한 값으로 주어집니다.

`max_count` 함수는 해당 도구 강화의 최대 업그레이드 레벨을 반환하는 함수입니다.

`run_upgrade_first` 함수는 맨 처음 해당 도구 강화를 진행했을 때 호출되는 함수입니다.

`run_upgrade` 함수는 해당 도구 강화를 진행할 때마다 호출되는 함수입니다. `level`은 1 이상 max_count 이하 범위의 값입니다. 맨 처음 강화시 `run_upgrade_first`, `run_upgrade` 함수가 순서대로 호출되며 그 이후에는 `run_upgrade` 함수만 호출됩니다.

## 재료 강화

## 요리 도구

## 캐릭터

## 몬스터
