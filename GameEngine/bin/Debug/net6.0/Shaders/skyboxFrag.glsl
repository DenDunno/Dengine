#version 330
smooth in vec3 TexCoord;

out vec4 FragColor;

uniform samplerCube Texture;

void main()
{	
    FragColor = textureCube(Texture, TexCoord);
}   