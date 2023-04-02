#version 430

layout(location = 0) in vec3 vertexPosition;
uniform vec3 rotationVector;
uniform float angle;

layout (binding = 0, std140) uniform CameraData
{ 
    mat4 viewMatrix;
    mat4 projectionMatrix;
    vec4 position;
};

smooth out vec3 textureCoordinates;

mat4 rotation3d(vec3 axis, float angle) 
{
  axis = normalize(axis);
  float s = sin(angle);
  float c = cos(angle);
  float oc = 1.0 - c;

  return mat4(
    oc * axis.x * axis.x + c,           oc * axis.x * axis.y - axis.z * s,  oc * axis.z * axis.x + axis.y * s,  0.0,
    oc * axis.x * axis.y + axis.z * s,  oc * axis.y * axis.y + c,           oc * axis.y * axis.z - axis.x * s,  0.0,
    oc * axis.z * axis.x - axis.y * s,  oc * axis.y * axis.z + axis.x * s,  oc * axis.z * axis.z + c,           0.0,
    0.0,                                0.0,                                0.0,                                1.0);
}

void main()
{       
    textureCoordinates = vertexPosition;    
    
    mat4 modelMatrix = mat4(10000, 0, 0, 0,
                            0, 10000, 0, 0,
                            0, 0, 10000, 0,
                            position.x, position.y, position.z, 1);
                            
    modelMatrix *= rotation3d(rotationVector, angle);
                                         
    gl_Position = projectionMatrix * viewMatrix * modelMatrix * vec4(vertexPosition, 1.0);
}