#version 330

in vec2 textureCoordinates;

uniform vec4 baseColor;
//uniform sampler2D tex;
uniform int hasTexture = 1;

out vec4 outputColor;

void main()
{
    vec4 result = baseColor;
    
    if (hasTexture == 1)
    {
        //result *= vec3(texture(tex, textureCoordinates));  
    }
    
    outputColor = result;
}