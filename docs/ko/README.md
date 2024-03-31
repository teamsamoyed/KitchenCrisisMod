
# Guide

Kitchen crisis에서는 모딩을 통해 게임 내에 등장하는 대부분의 컨텐츠를 수정하고 확장할 수 있습니다.

## Custom Mod

Kitchen Crisis의 모든 모드는 게임이 설치된 폴더의 mods/ 하위에 들어가게 됩니다. mods/base는 게임의 기본 에셋을 저장하는 모드입니다.

새로운 모드를 작성할 때에는 만들고자 하는 모드의 이름에 맞춰 `mods/(mod name)`으로 폴더를 만듭니다. Kitchen Crisis의 모드는 `mods/(mod name)` 아래에 기본적으로 다음과 같은 파일 구성을 가집니다.

- info.json : 모드의 정보를 정의하는 파일입니다.
- assets/ : 해당 모드가 포함하는 에셋 목록을 관리하는 폴더입니다.

`info.json` 파일은 다음과 같은 형식을 가집니다.

```json
{
  "name": "test",
  "i18n_name": {
    "en": "test",
    "ko": "테스트"
  },
  "description": {
    "en": "test mod",
    "ko": "모드 설명"
  },
  "author": "kitchen crisis",
  "version": "0.1.0",
  "enabled": true,
  "dependency": {
    "test2": "0.2.0"
  }
}
```

- name : mod의 유니크 아이디입니다. 폴더 이름과 동일한 값을 쓰는 것을 권장합니다. 다른 모드와 이름이 중복되어서는 안 됩니다.
- i18n_name : 게임 내부의 모드 관리 창에서 보이는 명칭입니다. 게임에서 설정된 국가 코드에 따라 어떻게 보일지 값을 설정합니다. 지원하는 언어 코드는 다음과 같습니다. 설정되어 있지 않을 경우 기본적으로 'en' 키에 따라 영어로 표시하므로 영어 명칭은 반드시 존재해야 합니다.
  - ko : 한국어
  - en : 영어
  - jp : 일본어
  - cn : 중국어 간체
  - cn_cht : 중국어 번체
- description : 게임 내부의 모드 관리 창에서 보이는 모드 설명 텍스트입니다. 마찬가지로 국가 코드에 맞춰 값을 설정합니다. 설정되어 있지 않을 경우 'en' 키에 따라 영어로 표시하므로 영어 설명은 반드시 존재해야 합니다.
- author : 모드 작성자 정보입니다.
- version : 모드 버전입니다.
- enabled : false인 경우 게임 실행시 해당 모드를 불러오지 않습니다.
- dependency : 이 모드가 요구하는 다른 모드 정보입니다. 모든 모드는 dependency를 만족하는 순서로 로딩됩니다. 요구하는 버전 정보는 "major", "major.minor", "major.minor.patch" 와 같은 형태로 표현할 수 있으며 깔려있는 모드가 버전을 만족하지 않을 경우 해당 모드는 로딩 과정에서 자동으로 비활성화됩니다. major, minor, patch는 0 이상의 정수여야합니다. 그리고 버전 정보에 "!"를 사용할 수 있는데, 이 경우 해당 모드와 이 모드를 같이 사용할 수 없음을 의미합니다.

## 에셋 관리

Kitchen Crisis의 모드 시스템에서, 각 에셋은 `mod/(mod name)/assets/` 를 기준으로 한 상대 경로로 참조됩니다. 즉, 모드의 이름을 구분하지 않고 에셋을 읽습니다. 이를 이용해서 base 내부에 존재하는 기본 에셋 혹은 다른 모드의 에셋을 바꿔치기 할 수 있습니다.

예를 들어, kitchen crisis에서 도마의 이미지는 `sprites/map_object/board.png` 라는 경로로 참조합니다. 기본적으로 이 파일은 `mods/base/assets/sprites/map_object/board.png`에 위치해 있습니다. 만약 새로운 모드 `mod1` 을 만들어, 해당 모드가 `mod/mod1/assets/sprites/map_object/board.png` 위치에 이미지 파일을 포함하게 만든다면 도마의 이미지는 `mod1` 하위에 있는 도마 이미지로 덮어씌워집니다.

kitchen crisis에서 각 에셋은 확장자를 기반으로 구분합니다. kitchen crisis의 모드에서 사용가능한 에셋 종류는 다음과 같습니다.

- .png : 이미지 파일입니다.
- .anim : 스프라이트 시트로부터 애니메이션을 재생하는 방식을 정의하는 파일입니다. 스프라이트 시트와 동일한 파일명을 가져야합니다. anim 파일의 포맷은 aseprite에서 애니메이션을 Array 방식으로 export한 것과 동일한 양식을 가집니다.
- .wav : 사운드 파일입니다.
- .map : 맵 정보를 저장합니다.
- .ttf : 폰트 파일입니다.

키친 크라이시스 게임의 기본 내장 에셋 목록은 [Assets](assets.md)에서 확인할 수 있습니다.

### Settings

`assets/settings/` 하위의 `.json` 확장자로 끝나는 파일들은 특수하게 취급됩니다.

- `settings/character.json` : 캐릭터 정보를 담당합니다. 내부에서 키값이 겹칠 경우 기존 캐릭터의 정보를 덮어쓰기하며, 키가 겹치지 않는 경우 새로운 캐릭터 정보를 추가하는 방식으로 동작합니다. 이하 세팅 파일들 역시 마찬가지 방식으로 동작합니다.
- `settings/consumable.json` : 소모품 정보를 담당합니다.
- `settings/ingredient_upgrade.json` : 재료 강화 정보를 담당합니다.
- `settings/map_object.json` : 주방에 배치되는 도구들의 정보를 담당합니다.
- `settings/mastery.json` : 특성 정보를 담당합니다.
- `settings/monster.json` : 몬스터 정보를 담당합니다.
- `settings/receipe.json` : 레시피 정보를 담당합니다.
- `settings/relic.json` : 보물 정보를 담당합니다.
- `settings/setting.json` : 기본 세팅 값 정보를 담당합니다. 모든 세팅을 덮어쓰기하는 것이 가능하나, 되도록이면 건드리지 않는 것을 권장합니다.
- `settings/stage.json` : 스테이지 정보를 담당합니다.
- `settings/tool_upgrade.json` : 도구 강화 정보를 담당합니다.
- `settings/i18n.json` : i18n 정보를 담당합니다.

각 `json` 파일의 포맷 및 사용 방법은 [컨텐츠 확장](contents.md) 에서 자세히 다룹니다.

## Scripts

lua로 작성된 스크립트를 이용하여 게임 로직을 확장할 수 있습니다. 스크립트를 작성하는 방법에 대한 자세한 내용은 [스크립트](script.md)에서 확인할 수 있습니다.

## Upload

제작한 모드를 스팀 창작 마당에 업로드하는 과정에 대해서는 [모드 업로드](upload.md) 문서를 참조해주세요.
