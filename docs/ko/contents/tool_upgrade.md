
## 도구 강화

게임 내에서 추가할 도구 강화의 unique ID를 `CustomToolUpgrade` 라고 합시다. 도구 강화를 추가하기 위해서는 아래의 파일들이 필요합니다.
- `assets/sprites/tool_upgrades/CustomToolUpgrade.png` : 해당 도구 강화의 인게임 아이콘 이미지입니다. 16x16 사이즈의 png 이미지여야합니다.
- `assets/sprites/tool_upgrades/CustomToolUpgradeMain.png` : 해당 도구 강화를 최대 강화했을 때의 인게임 아이콘 이미지입니다. 16x16 사이즈의 png 이미지여야합니다.
- `assets/settings/tool_upgrade.json` : 도구 강화와 관련한 수치 정보를 기록합니다. json 파일의 양식은 아래에서 다시 설명합니다.
- `assets/settings/i18n.json` : 게임 내에서 나올 도구 강화의 이름, 설명 정보입니다. 양식은 아래에서 다시 설명합니다.

### tool_upgrade.json

```json
{
  "CustomToolUpgrade": {
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

위와 같은 형태로 각 도구강화가 사용할 세팅 값을 기록할 수 있습니다. 한 모드에서 여러 개의 도구 강화를 추가할 경우 각 도구 강화의 unique ID를 키로해서 위의 tool_upgrade.json에 내용을 추가하면 됩니다.

### i18n.json

```json
{
  "en": {
    "upgrade": {
      "tool": {
        "CustomToolUpgrade": {
          "name": "CustomTool Name",
          "desc": "CustomTool Desc {Value}",
          "main_name": "CustomTool MainName",
          "main_desc": "CustomTool MainDesc {Value}",
          "guide_desc": "CustomTool Guide Desc",
          "main_guide_desc": "CustomTool MainGuide Desc"
        }
      }
    },
    "unlock": {
      "tool": {
        "CustomToolUpgrade": ""
      }
    }
  }
}
```

`name, desc`는 각각 도구 강화의 이름, 설명, `main_name, main_desc`는 최대 강화시의 이름, 설명, `guide_desc`와 `main_guide_desc`는 타이틀 화면의 도감 창에서 보여주는 기본/ 최대 도구 강화의 설명 텍스트입니다. `unlock` 하위의 텍스트는 강화의 해금 조건을 설명하는 텍스트입니다.

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
