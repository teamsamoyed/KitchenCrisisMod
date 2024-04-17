#version 440 core

// input
in vec3 pos;
in vec3 normal;


// data structures
struct Material
{
    vec4    ambient;
    vec4    diffuse;
    vec4    specular;
    vec4    emission;
    float   specularExp;
};

struct PointLight
{
    bool    enabled;
    vec3    pos;
    vec4    diffuse;
    vec4    specular;
    float   attenuation;
};


// uniforms
uniform PrimitiveFsUniformBlock
{
    Material    material;     
};

uniform GlobalFsUniformBlock
{
    vec4        ambient;
    PointLight  pointLights[2];
};


// output
out vec4 color;


void main()
{
    vec4 ambientTerm = material.ambient * ambient;
    
    vec3 normalDir = normalize(normal);
    vec4 diffuseTerm = vec4(0, 0, 0, 0);
    vec4 specularTerm = vec4(0, 0, 0, 0);

    for (int i = 0; i < 2; i++)
    {
        if (pointLights[i].enabled)
        {
            vec3 lightVec = pointLights[i].pos - pos;
            vec3 lightDir = normalize(lightVec);
            float nDotL = dot(normalDir, lightDir);

            float attenuation = 1.0 / (1.0 + pointLights[i].attenuation * pow(length(lightVec), 2));

            if (nDotL > 0)
            {
                diffuseTerm += ((nDotL * material.diffuse * pointLights[i].diffuse) * attenuation);
            }

            vec3 reflectionDir = normalize((2 * nDotL * normalDir) - lightDir);
            vec3 viewDir = normalize(-pos);
            float rDotV = dot(reflectionDir, viewDir);

            if (rDotV > 0)
            {                
                specularTerm += ((pow(rDotV, material.specularExp) * material.specular * pointLights[i].specular) * attenuation);
            }
        }
    }

    color = ambientTerm + diffuseTerm + specularTerm + material.emission;
}