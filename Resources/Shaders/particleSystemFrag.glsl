#version 330 core

flat in int dataIndex;

uniform vec4 color[10];

out vec4 outputColor;

void main(void)
{       
    outputColor = color[dataIndex];         
}