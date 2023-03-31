#version 330
layout(location = 0) in vec3 vertexPosition;

smooth out vec3 textureCoordinates;

uniform mat4 model;

layout (std140) uniform MyUniformBlock
{ 
    mat4[] matrices; 
};

void main()
{       
    textureCoordinates = vertexPosition;
    gl_Position = matrices[1] * matrices[0] * model * vec4(vertexPosition, 1.0);
}