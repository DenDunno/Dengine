#version 330
in vec3 InPosition;

smooth out vec3 textureCoordinates;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

void main()
{
    vec4 position = vec4(InPosition, 1.0) * model * view * projection;
    gl_Position = position;
    textureCoordinates = InPosition;
}