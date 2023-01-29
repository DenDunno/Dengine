#version 330 core

layout(location = 0) in vec3 vertexPosition;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;
uniform int verticesCount;

flat out int dataIndex;

void main(void)
{
    dataIndex = (gl_VertexID - 1) / verticesCount;
    
    gl_Position = vec4(vertexPosition, 1.0) * model * view * projection;
}