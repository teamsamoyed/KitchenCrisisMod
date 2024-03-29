
## 재료

게임에 추가할 재료의 unique ID 를 `CustomIngredient`라고 합시다. 재료를 추가하기 위해서는 아래의 파일들이 필요합니다.

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
