#version 440 core

// vertex attributes
in vec3 attr_position;


// uniforms
uniform SpriteVsUniformBlock
{
    mat4    modelView;
    mat4    modelViewInvTranspose;
    vec4    uv01;
    vec4    uv23;
};

// output
out vec3 pos;
out vec2 texCoord;

void main()
{
    gl_Position = modelView * vec4(attr_position, 1.0);
    pos = vec3(modelView * vec4(attr_position, 1.0));
    float px = 1 - step(attr_position.x, 0.);
    float py = 1 - step(attr_position.y, 0.);

    texCoord = vec2(uv01.x * px * py + uv01.z * px * (1 - py) + uv23.x * (1 - px) * (1 - py) + uv23.z * (1 - px) * py,
                    uv01.y * px * py + uv01.w * px * (1 - py) + uv23.y * (1 - px) * (1 - py) + uv23.w * (1 - px) * py);
}