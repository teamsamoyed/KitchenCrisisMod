## 요리 도구

게임에 추가할 요리 도구의 unique ID를 `CustomMapObject`라고 합시다. 요리 도구를 추가하기 위해서는 아래의 파일들이 필요합니다.

- `assets/sprites/map_object/custommapobject.png`: 요리 도구의 이미지 파일입니다. unique ID를 전부 소문자로 변환한 이름이어야합니다. 대소문자에 주의해주세요.
- `assets/sprites/map_object/custommapobject_use.png` : 실제 요리 과정에 사용되는 도구인 경우, 도구 사용중 상태에 대응하는 이미지입니다. 포탈 등의 오브젝트처럼 실제 요리 과정에 사용하는 도구가 아니라면 없어도 괜찮습니다.
- `assets/sprites/map_object/custommapobject_max.png` : `CustMapObjectUpgrade` 라는 도구 강화가 존재하며, 해당 도구 강화를 최대 업그레이드했을 경우 mapobject의 표시에 사용할 이미지입니다. 대응하는 도구 강화가 없다면 없어도 괜찮습니다.
- `assets/sprites/map_object/custommapobject_max_use.png` : 최대 업그레이드했을 때의 사용 이미지입니다. 마찬가지로 해당하는 케이스가 없다면 존재하지 않아도 됩니다.

- `assets/settings/map_object.json` : 해당 요리 도구의 속성을 정의합니다. 양식은 아래에서 다시 설명합니다.

- `assets/settings/i18n.json` : 게임 내에서 나올 요리 도구의 이름 정보입니다. 양식은 아래에서 다시 설명합니다.

## map_object.json

```json
{
  "CustomMapObject": {
    "IsBlock": true,
    "CanRemove": true,
    "AllocLimit": 1,
    "Modifier": {
      "Attack": 1.1,
      "CookTime": 1
    },
    "IgnoreFilter": true,
    "IgnoreWarn": true
  }
}
```

- `IsBlock` : 해당 오브젝트 위로 지나다닐 수 있는지 여부입니다.
- `CanRemove` : 플레이어가 배치 단계에서 배치 / 삭제를 자유롭게 할 수 있는지 여부입니다.
- `AllocLimit` : 요리 과정에 사용되는 도구인 경우, 동시에 사용 가능한 클론의 수를 나타냅니다. 요리 과정에 사용되는 도구가 아니라면 생략해도 됩니다.
- `Modifier` : 요리 과정에 사용되는 도구인 경우, 레시피에 포함됐을 때 레시피의 사양을 정하는 인자입니다. `Attack` 배율만큼 레시피의 공격력이 증가하며, `CookTime`은 해당 도구를 사용 완료하는데까지 걸리는 시간을 뜻합니다. 요리 과정에 사용되는 도구가 아니라면 생략해도 됩니다.
- `IgnoreFilter` : 레시피 창의 요리 도구 목록에 보이는지 여부를 결정합니다.
- `IgnoreWarn` : 경고에 표시될지 여부를 결정합니다. false인 경우 해당 도구를 사용하는 레시피가 존재하지 않는데 배치되어있다면 경고를 표시합니다.

## i18n.json

```json
{
  "en": {
    "map_object": {
      "CustomMapObject": "CustomMapObject"
    }
  }
}
```

요리도구의 이름을 표시하는 텍스트를 정의합니다.
