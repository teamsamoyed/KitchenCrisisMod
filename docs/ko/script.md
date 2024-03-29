# 스크립트

kitchen crisis는 모드를 불러오고 난 후, 해당 모드의 `assets/scripts/mod.lua` 파일이 있다면 해당 스크립트를 실행합니다.

`mod.lua` 파일이 다른 `.lua` 파일을 require한다면, 해당 파일도 모두 불러옵니다.

스크립트의 `require`에서는 에셋 로딩 규칙이 적용되지 않습니다. 따라서, `require`를 이용해 파일을 참조할 때에는 `require(./mods/(mod name)/assets/scripts/(script name).lua)` 형태로 참조해야합니다.

kitchen crisis의 내부 API 목록은 [api](api.md) 에서 확인할 수 있습니다.

## 구조

kitchen crisis에서 제공하는 API는 모두 `kitchen_crisis` 테이블에 정의됩니다. API는 해당 테이블에서 다시 각 목적에 따라 하위 테이블로 분류됩니다. 큰 범위에서 중요한 하위 테이블은 다음과 같습니다.

- module : 모드 단위에서 프레임 단위의 동작, 커스텀한 렌더링, UI 등을 구현하기 위한 API를 제공합니다.
- save_data : 게임의 세이브 데이터와 관련된 API를 제공합니다.
- global_event : 전체 게임 단위에서 발생하는 여러 이벤트를 구독하고 발행하기 위한 API를 제공합니다.
- session : 게임 플레이를 시작한 다음, 실제 플레이 내부 상태를 관리하는 API를 제공합니다.
- render : 각종 그리기 동작과 관련한 API를 제공합니다.
- ui : UI를 생성하고 관리하는 API를 제공합니다.

게임 플레이 내부에서 사용하는 도구 강화, 재료 강화, 보물, 캐릭터 등의 상세한 컨텐츠 확장에 관한 내용은 [컨텐츠 확장](contents.md) 에서 확인할 수 있습니다.

### module

`kitchen_crisis.module.register` 를 통해 자체 모듈을 등록할 수 있습니다. register는 (모듈의 이름)과 (모듈 테이블)을 인자로 받습니다. 이 때 모듈 테이블의 `update` 함수는 매 프레임마다 실행됩니다. 마찬가지로 `render` 함수도 매 프레임 실행되며, 그리기 동작이 필요한 경우 이 함수에서 그리기 함수를 호출하면 됩니다.

만약 자체 UI를 제공해야한다면, 해당 테이블에 `init_ui` 함수를 정의하고 여기서 커스텀 UI를 생성해서 반환하면 됩니다. 생성한 UI는 해당 테이블의 ui 멤버값으로 세팅되며, update 함수와 render 함수에서 `self.ui` 로 참조 가능합니다.

아래는 간단한 모듈의 예시입니다.

```lua
kitchen_crisis.module.register("TestModule", {
  init_ui = function()
    local ui = kitchen_crisis.ui.node("ui_test")
    ui:image("sprites/ui/test.png")
    ui:pos(300, 300)
    ui:size(kitchen_crisis.ui.length_px(100), kitchen_crisis.ui.length_px(100))
    
    return ui
  end
  update = function(self, dt)
    if self.ui:focus():type() ~= "normal" then
      self.ui:image("sprites/ui/test_hover.png")
    else
      self.ui:image("sprites/ui/test.png")
    end
  end,
  render = function(self)
    kitchen_crisis.render.draw_sprite("sprites/ui/test.png", 0, 0, 0, kitchen_crisis.render.layer.FRONT)
  end,
})
```

`init_ui`에서 `ui_test`라는 이름의 이미지 노드를 생성하고, (300, 300)위치에 100x100 크기로 위치시킵니다. `update` 함수에서는 `ui`에 포커스가 가 있을 경우와 그렇지 않은 경우에 맞춰서 이미지를 바꾸는 것을 확인할 수 있습니다.

`render` 함수에서는 draw_sprite를 이용해 FRONT layer의 0,0,0 위치에 이미지를 그립니다.

상세한 API 구성에 대해서는 [api](api.md)에서 확인할 수 있습니다.

