
## 재료 강화

게임 내에서 추가할 재료 강화의 unique ID를 `CustomIngredientUpgrade` 라고 합시다. 재료 강화를 추가하기 위해서는 아래의 파일들이 필요합니다.
- `assets/settings/ingredient_upgrade.json` : 재료 강화와 관련한 수치 정보를 기록합니다. json 파일의 양식은 아래에서 다시 설명합니다.
- `assets/settings/i18n.json` : 게임 내에서 나올 재료 강화의 이름, 설명 정보입니다. 양식은 아래에서 다시 설명합니다.

### ingredient_upgrade.json

```json
{
  "CustomIngredientUpgrade": {
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
  }
}
```

위와 같은 형태로 각 재료강화가 사용할 세팅 값을 기록할 수 있습니다. 한 모드에서 여러 개의 재료 강화를 추가할 경우 각 재료 강화의 unique ID를 키로해서 위의 ingredient_upgrade.json에 내용을 추가하면 됩니다.

### i18n.json

```json
{
  "en": {
    "upgrade": {
      "ingredient": {
        "CustomIngredientUpgrade": {
          "name": "CustomIngredient Name",
          "desc": "CustomIngredient Desc {Ingredient} {Value}",
          "simple_desc": "CustomIngredient simple desc {Value}",
          "guide_desc": "CustomIngredient Guide Desc"
        }
      }
    }
  }
}
```

`name, desc`는 각각 재료 강화의 이름, 설명입니다. `simple_desc`는 레시피 정보 팝업에서 재료 강화 적용 상황을 보여주는 텍스트입니다(공간의 여유가 작기 때문에, `desc`에 비해 짧게 적는 편이 좋습니다). `guide_desc`는 도감 창에서 확인할 수 있는 설명 텍스트입니다.

### scripting

재료 강화의 동작을 정의하기 위해 필요한 lua 스크립트입니다.

```lua

kitchen_crisis.upgrade.ingredient.register("CustomIngredientUpgrade")

kitchen_crisis.upgrade.ingredient.CustomIngredientUpgrade = {
  simple_desc = function (setting, level)
    return kitchen_crisis.i18n_bind("upgrade.tool.CustomIngredientUpgrade.simple_desc", {
      Value = tostring(setting.Value[now + 1].Value)
    })
  end,
  view_desc = function (setting, ingredient, now, nxt)
    return kitchen_crisis.i18n_bind("upgrade.tool.CustomIngredientUpgrade.desc", {
      Ingredient = ingredient,
      Value = tostring(setting.Value[now + 1].Value)
    })
  end,
  max_count = function (setting)
    #setting.Value
  end,
  run_upgrade_first = function (setting, ingredient)
  end,
  run_upgrade = function(setting, ingredient, level)
  end
}
```

`kitchen_crisis.ingredient_upgrade.register`를 통해 만들고자 하는 재료 강화의 정보를 게임에 등록할 수 있습니다.

`simple_desc, iew_desc, max_count, run_upgrade_first, run_upgrade` 함수의 인자인 `setting`은 위의 `tool_upgrade.json`에서 정의한 값이 table형태로 전달됩니다.

`simple_desc` 함수는 재료 강화의 레시피 팝업시 설명 텍스트를 반환하는 함수입니다. level은 현재 레벨로 1 이상 max_count 이하 범위의 값입니다.

`view_desc` 함수는 재료 강화 설명 텍스트를 반환하는 함수입니다. ingredient는 강화가 적용되는 재료, now는 현재 레벨, nxt는 다음 레벨입니다. now, nxt의 경우 0 이상 max_count 이하 범위의 값입니다. 강화 선택에서는 now, nxt가 서로 다른 값으로 주어지고(now = 현재 강화 레벨, nxt = 강화를 골랐을 경우의 레벨), 단순 설명 화면에서는 동일한 값으로 주어집니다.

`max_count` 함수는 해당 재료 강화의 최대 업그레이드 레벨을 반환하는 함수입니다.

`run_upgrade_first` 함수는 맨 처음 해당 재료 강화를 진행했을 때 호출되는 함수입니다. `ingredient`는 해당 재료 강화가 적용되는 재료를 뜻합니다.

`run_upgrade` 함수는 해당 재료 강화를 진행할 때마다 호출되는 함수입니다. `ingredient`는 해당 재료 강화가 적용되는 재료를 뜻하며, `level`은 1 이상 max_count 이하 범위의 값입니다. 맨 처음 강화시 `run_upgrade_first`, `run_upgrade` 함수가 순서대로 호출되며 그 이후에는 `run_upgrade` 함수만 호출됩니다.
