
# Introduction

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
  - zh-chs : 중국어 간체
  - zh-cht : 중국어 번체
- description : 게임 내부의 모드 관리 창에서 보이는 모드 설명 텍스트입니다. 마찬가지로 국가 코드에 맞춰 값을 설정합니다.
- author : 모드 작성자 정보입니다.
- version : 모드 버전입니다.
- enabled : false인 경우 게임 실행시 해당 모드를 불러오지 않습니다.
- dependency : 이 모드가 요구하는 다른 모드 정보입니다. 모든 모드는 dependency를 만족하는 순서로 로딩됩니다. 요구하는 버전 정보는 "major", "major.minor", "major.minor.patch" 와 같은 형태로 표현할 수 있으며 깔려있는 모드가 버전을 만족하지 않을 경우 해당 모드는 로딩 과정에서 자동으로 비활성화됩니다. major, minor, patch는 0 이상의 정수여야합니다. 그리고 버전 정보에 "!"를 사용할 수 있는데, 이 경우 해당 모드와 이 모드를 같이 사용할 수 없음을 의미합니다.

## Guides

- [에셋 덮어쓰기]()
- [스크립팅]()
- [렌더링]()
- [UI]()
- [컨텐츠 확장]()
- [Script API List]()
