#version 330

in vec3 normal;
out vec4 outputColor;

void main()
{       
    outputColor = vec4(normal, 1); 
}