#version 330

in vec2 textureCoordinates;
in vec3 normal;
uniform sampler2D tex;
out vec4 outputColor;

void main()
{ 
    outputColor = texture(tex, textureCoordinates); 
}