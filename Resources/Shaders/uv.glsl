#version 330

in vec3 normal;
out vec4 outputColor;

void main()
{
    vec4 result = vec4(normal, 1);               
    outputColor = result;
}