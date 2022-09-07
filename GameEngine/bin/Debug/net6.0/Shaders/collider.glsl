#version 330

in vec2 textureCoordinates;
uniform sampler2D tex;
out vec4 outputColor;

void main()
{
    outputColor = vec4(0.0f, 1.0, 0.0f, 0.5f); 
}