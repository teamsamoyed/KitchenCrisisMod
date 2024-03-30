## 몬스터

게임에 추가할 몬스터의 unique ID를 `CustomMonster`라고 합시다. 몬스터를 추가하기 위해서는 아래의 파일들이 필요합니다.

- `assets/sprites/monster/MonsterView.png` : 몬스터의 애니메이션 스프라이트 시트 이미지 파일입니다. 어떤 시트 이미지를 사용할지 `monster.json`에서 설정할 수 있습니다.
- `assets/sprites/monster/MonsterView.anim` : 몬스터의 애니메이션 정보를 지정하는 파일입니다.
- `assets/settings/monster.json` : 몬스터와 관련한 수치 정보를 기록합니다. json 파일의 양식은 아래에서 다시 설명합니다.
- `assets/settings/i18n.json` 게임 내에서 나올 몬스터의 이름, 설명 정보입니다. 양식은 아래에서 다시 설명합니다.


게임에 추가할 캐릭터의 unique ID를 `CustomCharacter`이라고 합시다. 캐릭터를 추가하기 위해서는 아래의 파일들이 필요합니다.

- `assets/sprites/character/customcharacter.png` :  캐릭터의 애니메이션 스프라이트 시트 이미지 파일입니다. unique ID를 전부 소문자로 변환한 이름이어야합니다. 대소문자에 주의해주세요.
- `assets/sprites/character/customcharacter.anim` : 캐릭터의 애니메이션 정보를 지정하는 파일입니다. unique ID를 전부 소문자로 변환한 이름이어야합니다. 대소문자에 주의해주세요.
- `assets/settings/character.json` : 캐릭터와 관련한 수치 정보를 기록합니다. json 파일의 양식은 아래에서 다시 설명합니다.
- `assets/settings/i18n.json` 게임 내에서 나올 캐릭터의 이름, 설명 정보입니다. 양식은 아래에서 다시 설명합니다.

### animation

몬스터 애니메이션 정보는 아래 애니메이션을 포함하고 있어야합니다.

- idle, idle_back : 가만히 멈춰 서 있는 애니메이션(앞/뒤)입니다.
- run, run_back : 이동하는 애니메이션(앞/뒤)입니다.
- eat, eat_back : 음식을 섭취하는 애니메이션(앞/뒤)입니다.
- split, split_back: 둘로 분할되는 애니메이션(앞/뒤)입니다. 몬스터의 종류가 `Split` 인 경우 필요합니다.
- idle_nude, idle_nude_back, run_nude, run_nude_back, eat_nude, eat_nude_back : 슬로우 상태에서의 애니메이션(앞/뒤)입니다. 몬스터의 종류가 `Turtle` 인 경우 필요합니다.
- summon, summon_back : 몬스터를 소환하는/소환되는 애니메이션(앞/뒤)입니다. 몬스터의 종류가 `Undead`, `UndeadSpawn`인 경우 필요합니다.

### monster.json

```json
{
  "CustomMonster": {
    "Type": "FourLegs",
    "HP": 150,
    "Attack": 1,
    "MoveSpeed": 1.1,
    "Gold": 100,
    "Y": 0,
    "FaceX": 0,
    "FaceY": 0,
    "View": "MonsterView",
    "IsBoss": false
  }
}
```

모든 몬스터가 공통으로 가지는 속성값의 목록입니다.

- Type : 몬스터의 종류입니다. FourLegs, Ogre, Slime, Mosquito, Golem, Split, Angel, Undead, UndeadSpawn, Turtle, Reptile 이 기본적으로 제공되는 값입니다. 몬스터의 종류에 따라 추가적으로 필요한 속성이나 애니메이션이 달라질 수 있습니다.
- HP : 몬스터의 체력입니다.
- Attack : 몬스터의 공격력입니다.
- MoveSpeed : 몬스터의 이동속도입니다.
- Gold : 몬스터가 주는 골드의 양입니다.
- Y : 렌더링시 지면에서 떨어진 높이를 정의합니다.
- FaceX, FaceY : 몬스터의 얼굴이 위치하는 좌표를 정의합니다.
- View : 몬스터의 렌더링에 쓸 애니메이션 시트의 이름입니다. `assets/sprites/monster/(View).png`, `assets/sprites/monster/(View).anim` 을 사용해서 렌더링합니다.
- IsBoss : 보스 몬스터로 취급할지 여부입니다. 보스 몬스터인 경우 해당 웨이브 시작 시점에 warning 연출이 들어갑니다.

아래는 몬스터 종류 별로 추가적으로 필요한 속성 목록입니다.

- Slime

```json
{
  "HPIncreasePerSecond": 1
}
```

초당 체력 상승량입니다.

- Split

Split의 경우, 쪼개진 결과로 만들어지는 몬스터 정보가 추가로 필요합니다. 이름이 `Name`인 몬스터는 `NameA`, `NameB`의 두 몬스터로 쪼개집니다.

- Angel

```json
{
  "TierBonus": [ -20, -10, 0, 10, 20 ]
}
```

섭취한 음식으로부터 받는 포만감 조정(%) 수치 입니다. 각각 1,2,3,4,5 티어에 대응됩니다.

- Undead

```json
{
  "Summon": "SummonName",
  "SummonTerm": 5
}
```

`SummonTerm` 초마다 `Summon`에 해당하는 몬스터를 소환합니다. 소환되는 몬스터는 `UndeadSpawn` 타입이어야합니다.

- Turtle

```json
{
  "CCBonus": 50
}
```

이동제어 상태에 있을 때 섭취한 음식으로부터 받는 포만감 조정(%) 수치입니다.

- Reptile

```json
{
  "DamageMax": 100
}
```

한번에 섭취하는 포만감 수치 최대치입니다.


### i18n.json

```json
{
  "en": {
    "monster": {
      "CustomMonster": {
        "name": "Name",
        "desc": "Desc"
      }
    }
  }
}
```

각각 해당 몬스터의 이름, 설명에 대응되는 텍스트입니다.

### Custom Monster Type

위의 기본적인 몬스터 타입 외에도 새로운 몬스터 타입을 추가할 수 있습니다. 새롭게 추가할 몬스터 타입을 `CustomMonsterType` 이라고 합시다.

```lua
kitchen_crisis.monster.register_type("CustomMonsterType");

kitchen_crisis.monster.CustomMonsterType = {
  attack_priority = function(setting, monster_id, dist)
    return dist;
  end
  damage_postprocess = function(setting, monster_id, damage, food)
    return damage;
  end
  anim = function(setting, monster_id)
    return "idle";
  end
  on_update = function(setting, monster_id, dt)
  end
}

```

`kitchen_crisis.monster.register_type`을 통해 새로운 몬스터 타입을 추가할 수 있습니다.

`attack_priority, damage_postprocess, anim, on_update` 함수의 인자인 `setting`은 위의 `monster.json`에서 정의한 값이 table 형태로 전달됩니다.

`attack_priority` 함수는 공격 우선순위를 정의합니다. 반환값이 작을 수록 먼저 공격됩니다. 인자로 들어오는 `dist`는 목적 지점(몬스터가 나가는 포탈)까지 남은 거리를 뜻합니다. `monster_id`는 해당 몬스터를 가리키는 정수 ID 입니다. 따로 정의하지 않을 경우 dist 값을 반환하는 것으로 설정됩니다.

`damage_postprocess` 함수는 몬스터가 피해를 입은 시점에 호출되며, 필요하다면 입을 데미지 수치를 수정하여 반환할 수 있습니다. 인자로 들어오는 `monster_id`는 해당 몬스터를 가리키는 정수 ID 입니다. `damage`, `food` 는 각각 실수형, 문자열 타입이며 `food` 요리로 `damage` 만큼의 피해를 입었음을 뜻합니다. 따로 정의하지 않을 경우 인자로 들어온 `damage`를 그대로 반환합니다.

`anim` 함수는 몬스터 렌더링 과정에서 보여줄 애니메이션 태그를 반환하는 함수입니다. 인자로 들어오는 `monster_id`는 해당 몬스터를 가리키는 정수 ID 입니다. 따로 정의하지 않을 경우 기본적인 규칙에 맞춰 렌더링합니다. 방향에 맞춰 `_back`을 알아서 붙여주기 때문에 기본 애니메이션 태그만 반환하면 됩니다.

`on_update` 함수는 매 프레임마다 호출됩니다. 인자로 들어오는 `monster_id`는 해당 몬스터를 가리키는 정수 ID 이며, `dt`는 해당 프레임의 델타 타임(초 단위) 입니다.
