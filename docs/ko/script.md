# 스크립트

kitchen crisis는 모드를 불러오고 난 후, 해당 모드의 `assets/scripts/mod.lua` 파일이 있다면 해당 스크립트를 실행합니다.

`mod.lua` 파일이 다른 `.lua` 파일을 require한다면, 해당 파일도 모두 불러옵니다.

스크립트의 `require`에서는 에셋 로딩 규칙이 적용되지 않습니다. 따라서, `require`를 이용해 파일을 참조할 때에는 `require(mods/(mod name)/assets/scripts/(script name).lua)` 형태로 참조해야합니다.

kitchen crisis의 내부 API 목록은 [api](api.md) 에서 확인할 수 있습니다.

## 구조

