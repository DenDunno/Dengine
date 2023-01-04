#version 330
smooth in vec3 textureCoordinates;
out vec4 outputColor;
uniform samplerCube tex;

void main()
{	
    outputColor = texture(tex, textureCoordinates);
}