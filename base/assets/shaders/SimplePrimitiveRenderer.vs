#version 440 core

// vertex attributes
in vec3 attr_position;
in vec3 attr_normal;


// uniforms
uniform PrimitiveVsUniformBlock
{
    mat4    modelView;
    mat4    modelViewInvTranspose;
};

uniform GlobalVsUniformBlock
{
    mat4    projection;
};


// output
out vec3 pos;
out vec3 normal;


void main()
{
    gl_Position = projection * modelView * vec4(attr_position, 1.0);
    pos = vec3(modelView * vec4(attr_position, 1.0));
    normal = vec3(modelViewInvTranspose * vec4(attr_normal, 0.0));
}