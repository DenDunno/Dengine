#version 330 core

uniform sampler2D[] textures;

in vec3 normal;
in vec3 fragmentPosition; 
in vec2 textureCoordinates;
flat in float textureId;

out vec4 outputColor;

void main()
{
    vec4 result = vec4(1,1,1,1);
    
    if (textureId == 0)
        result = vec4(1,0,0,1);
        
    if (textureId == 1)
        result = vec4(0,1,0,1);
    
    if (textureId == 2)
        result = vec4(0,0,1,1);
                   
    outputColor = result;     
}