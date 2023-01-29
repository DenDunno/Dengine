#version 330 core

flat in int dataIndex;

uniform vec4 color[100];

out vec4 outputColor;

void main(void)
{ 
    vec4 result = color[dataIndex];
    
    if (dataIndex > 100)
    {
        result = vec4(1,0,0,1);
    }      
    
    outputColor = result;         
}