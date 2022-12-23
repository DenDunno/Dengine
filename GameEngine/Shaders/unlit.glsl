#version 330

in vec2 textureCoordinates;
out vec4 outputColor;
uniform vec3 baseColor;
//uniform sampler2D tex;
uniform int hasTexture = 1;

void main()
{
    vec4 result = vec4(baseColor, 1);        
    
    if (hasTexture == 1)
    {
        //result *= vec3(texture(tex, textureCoordinates));  
    }
    
    outputColor = result;
}