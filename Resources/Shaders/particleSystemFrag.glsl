#version 330 core

flat in int dataIndex;

uniform vec4 color[100];

out vec4 outputColor;

void main(void)
{ 
    vec4 result = color[dataIndex];      
    
    if (result.w < 0.001)
    {
        discard;
    }
    
    outputColor = result;         
}