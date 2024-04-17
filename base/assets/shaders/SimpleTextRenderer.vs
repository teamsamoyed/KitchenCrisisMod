#version 440 core

// vertex attributes
in vec2 attr_position;
in vec2 attr_uv;


// uniforms
uniform TextRendererUniforms
{
    vec2    dimensions;
    vec2    offset;
    vec4    textColor;
};


// output
out vec2 texCoord;
out vec4 textColorFromVs;


void main()
{
    vec2 pos = attr_position * dimensions + offset;
    gl_Position = vec4(pos.x, pos.y, 0, 1);
    texCoord = attr_uv;
    textColorFromVs = textColor;
}