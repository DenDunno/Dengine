#version 330
layout(location = 0) in vec3 vertexPosition;

smooth out vec3 textureCoordinates;

layout (std140) uniform CameraData
{ 
    mat4 viewMatrix;
    mat4 projectionMatrix;
    vec4 position;
};

void main()
{       
    textureCoordinates = vertexPosition;    
    mat4 modelMatrix = mat4(10000, 0, 0, 0,
                            0, 10000, 0, 0,
                            0, 0, 10000, 0,
                            position.x, position.y, position.z, 1);
                            
    gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(vertexPosition, 1.0);
}