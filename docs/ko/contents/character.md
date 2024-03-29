## 캐릭터

게임에 추가할 캐릭터의 unique ID를 `CustomCharacter`이라고 합시다. 캐릭터를 추가하기 위해서는 아래의 파일들이 필요합니다.

- `assets/sprites/character/customcharacter.png` :  캐릭터의 애니메이션 스프라이트 시트 이미지 파일입니다. unique ID를 전부 소문자로 변환한 이름이어야합니다. 대소문자에 주의해주세요.
- `assets/sprites/character/customcharacter.anim` : 캐릭터의 애니메이션 정보를 지정하는 파일입니다. unique ID를 전부 소문자로 변환한 이름이어야합니다. 대소문자에 주의해주세요.
- `assets/settings/character.json` : 캐릭터와 관련한 수치 정보를 기록합니다. json 파일의 양식은 아래에서 다시 설명합니다.
- `assets/settings/i18n.json` 게임 내에서 나올 캐릭터의 이름, 설명 정보입니다. 양식은 아래에서 다시 설명합니다.

### animation

캐릭터 애니메이션 정보는 아래 애니메이션을 포함하고 있어야합니다.

- idle, idle_back : 가만히 멈춰 서 있는 애니메이션(앞/뒤)입니다.
- run, run_back: 이동하는 애니메이션(앞/뒤)입니다.
- slicing, slicing_back: 칼질하는 애니메이션(앞/뒤)입니다.
- working, working_back : 도구 상자를 사용하는 애니메이션(앞/뒤)입니다.
- pan, pan_back : 프라이팬을 사용하는 애니메이션(앞/뒤)입니다.
- cook_waiting, cook_waiting_back : 여타 요리 도구를 사용하는 애니메이션(앞/뒤)입니다.
- game_over : 게임 오버 상태 애니메이션입니다.
- angry : 분노하는 애니메이션입니다.
- cry : 우는 애니메이션입니다.

### character.json

```json
{
  "CustomCharacter": {
    "CookSpeed": 1,
    "MoveSpeed": 1,
    "Value": 10
  }
}
```

`CookSpeed`, `MoveSpeed`는 해당 캐릭터의 기본 요리 속도, 이동 속도를 결정하는 값으로 반드시 포함되어야 합니다.

그 외에는 캐릭터 구현 과정에서 필요한 속성 값을 추가하면 됩니다.

### i18n.json

```json
{
  "en": {
    "character": {
      "CustomCharacter": {
        "name": "Name",
        "desc": "Desc, {Value}"
      }
    },
    "unlock": {
      "character": {
        "CustomCharacter": "unlock"
      }
    }
  }
}
```

각각 해당 캐릭터의 이름, 설명, 해금 조건에 대응되는 텍스트를 정의합니다.

### Scripting

캐릭터의 동작을 정의하기 위해 필요한 lua 스크립트입니다.

```lua
kitchen_crisis.character.register("CustomCharacter");

kitchen_crisis.save_data.unlock_character("CustomCharacter");

kitchen_crisis.character.CustomCharacter = {
  desc = function(setting)
    return kitchen_crisis.i18n_bind("character.CustomCharacter.desc", {
      Value = tostring(setting.Value)
    })
  end
  base_count = function(setting)
    return 1
  end
  blocked_tool_upgrade = function(setting)
    return ["BlockedToolUpgrade"]
  end
  start = function(setting)
  end
  on_wave_end = function(setting)
  end
}

```

`kitchen_crisis.character.register`를 통해 만들고자 하는 캐릭터의 정보를 게임에 등록할 수 있습니다.

`desc, base_count, blocked_tool_upgrade, start, on_wave_end` 함수의 인자인 `setting`은 위의 `character.json`에서 정의한 값이 table 형태로 전달됩니다.

`desc` 함수는 새 게임 화면에서 캐릭터의 설명 텍스트를 반환하는 함수입니다.

`base_count`는 게임 시작시 기본 클론 수를 의미합니다. 정의하지 않을 경우 게임의 기본 값을 따라갑니다.

`blocked_tool_upgrade`는 해당 캐릭터를 골랐을 때 도구 강화에서 나오지 않게 막을 강화의 목록을 정의합니다. 해당 기능이 필요하지 않다면 정의하지 않아도 됩니다.

`start`는 해당 캐릭터를 고른 후 게임 시작 단계에서 수행할 작업을 정의합니다.

`on_wave_end`는 매 웨이브 종료 시점에서 수행할 작업을 정의합니다.
