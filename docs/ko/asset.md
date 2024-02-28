# 에셋 관리


Kitchen Crisis의 모드 시스템에서, 각 에셋은 `mod/(mod name)/assets/` 를 기준으로 한 상대 경로로 참조됩니다. 즉, 모드의 이름을 구분하지 않고 에 셋을 읽습니다. 이를 이용해서 base 내부에 존재하는 기본 에셋 혹은 다른 모드의 에셋을 바꿔치기 할 수 있습니다.

예를 들어, kitchen crisis에서 도마의 이미지는 `sprites/map_object/board.png` 라는 경로로 참조합니다. 기본적으로 이 파일은 `mods/base/assets/sprites/map_object/board.png`에 위치해 있습니다. 만약 새로운 모드 `mod1` 을 만들어, 해당 모드가 `mod/mod1/assets/sprites/map_object/board.png` 위치에 이미지 파일을 포함하게 만든다면 도마의 이미지는 `mod1` 하위에 있는 도마 이미지로 덮어씌워집니다.

kitchen crisis에서 각 에셋은 확장자를 기반으로 구분합니다. kitchen crisis의 모드에서 사용가능한 에셋 종류는 다음과 같습니다.

- .png : 이미지 파일입니다.
- .anim : 스프라이트 시트로부터 애니메이션을 재생하는 방식을 정의하는 파일입니다. 스프라이트 시트와 동일한 파일명을 가져야합니다. anim 파일의 포맷은 aseprite에서 애니메이션을 Array 방식으로 export한 것과 동일한 양식을 가집니다.
- .wav : 사운드 파일입니다.
- .map : 맵 정보를 저장합니다.

## Settings

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

각 `json` 파일의 포맷 및 사용 방법은 [컨텐츠 확장](/contents.md) 에서 자세히 다룹니다.
