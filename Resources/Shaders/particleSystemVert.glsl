#version 330 core

layout(location = 0) in vec3 vertexPosition;

uniform mat4 models[100];
uniform mat4 view;
uniform mat4 projection;
uniform int verticesCount;

flat out int dataIndex;

void main(void)
{
    dataIndex = (gl_VertexID) / verticesCount;
    mat4 model = models[dataIndex];
    
    if (dataIndex > 99)
    {
        model = mat4(1.0, 0.0, 0.0, 0.0,  // 1. column
                  0.0, 1.0, 0.0, 0.0,  // 2. column
                  0.0, 0.0, 1.0, 0.0,  // 3. column
                  0.0, 0.0, 0.0, 1.0);
    }
    
    gl_Position = vec4(vertexPosition, 1.0) * model * view * projection;
}