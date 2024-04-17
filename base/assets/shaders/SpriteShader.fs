#version 440 core

// input
in vec3 pos;
in vec2 texCoord;

uniform SpriteFsUniformTintBlock
{
    vec4 tintColor;
};

uniform SpriteFsUniformCircleBlock
{
    float circleAmount;
};

uniform SpriteFsUniformGrayscaleBlock
{
    float grayscaleAmount;
};

uniform SpriteFsUniformFlashBlock
{
    float flashAmount;
};

uniform SpriteFsUniformSplashBlock
{
    float splashFrom;
    float splashTo;
    float splashWidth;
    float splashHeight;
};

uniform SpriteFsUniformCircleMaskBlock
{
    float circleMask;
};

uniform SpriteFsUniformCutBlock
{
    float cutAlpha;
};

// uniforms
uniform sampler2D samp;

// output
out vec4 color;

void main()
{
    vec2 center = vec2(0.5, 0.5);
    float rad = atan(texCoord.y - center.y, -(texCoord.x - center.x));
    rad = fract((-rad / 3.1415926535897932384626433832795 + 1.0) * 0.5 + 0.25);
    float radMask = step(rad, circleAmount);
    float circleMaskCheck = 1 - step(0.5, circleMask) * step(0.25, (texCoord.x - center.x) * (texCoord.x - center.x) + (texCoord.y - center.y) * (texCoord.y - center.y));

    vec4 subColor = texture(samp, texCoord) * tintColor;
    float gray = dot(subColor.rgb, vec3(0.299, 0.587, 0.114));
    subColor.rgb = mix(subColor.rgb, vec3(gray), grayscaleAmount);
    subColor.rgb = mix(subColor.rgb, vec3(tintColor), flashAmount);
    float r = (texCoord.x * splashWidth + texCoord.y * splashHeight) / (splashWidth + splashHeight);

    vec3 white = mix(subColor.rgb, vec3(1.0, 1.0, 1.0), 0.7);
    float range = step(splashFrom, r) * step(r, splashTo);
    subColor.rgb = mix(subColor.rgb, white, range);
    subColor.a *= radMask * circleMaskCheck;
    
    if (subColor.a < cutAlpha)
        discard;

    color = subColor;
}