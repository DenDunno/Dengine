#version 330 core

layout(location = 0) in vec3 vertexPosition;
layout (location = 1) in vec3 vertexNormal;
uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;
out vec3 normal;

void main(void)
{            
    normal = vertexNormal * mat3(transpose(inverse(model)));
    
    gl_Position = vec4(vertexPosition, 1.0) * model * view * projection;
}