#version 330

in vec2 textureCoordinates;
uniform sampler2D tex;
out vec4 outputColor;

void main()
{
    outputColor = vec4(0.0f, 0.7f, 0.0f, 0.4f); 
}