#version 330

uniform sampler2D texture1;
uniform sampler2D texture2;
uniform sampler2D texture3;
uniform sampler2D texture4;
uniform sampler2D texture5;
uniform sampler2D texture6;
in vec2 textureCoordinates;
out vec4 outputColor;

void main()
{
    outputColor = texture(tex, textureCoordinates);
}