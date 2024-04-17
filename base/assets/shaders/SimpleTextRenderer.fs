#version 440 core

// input
in vec2 texCoord;
in vec4 textColorFromVs;


// uniforms
uniform sampler2D samp;


// output
out vec4 color;


void main()
{
    color = texture(samp, texCoord).r * textColorFromVs;
}