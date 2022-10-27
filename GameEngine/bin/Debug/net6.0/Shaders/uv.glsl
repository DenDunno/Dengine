#version 330

in vec2 textureCoordinates;
out vec4 outputColor;

void main()
{       
    outputColor = vec4(textureCoordinates.x, textureCoordinates.y, 0, 1); 
}