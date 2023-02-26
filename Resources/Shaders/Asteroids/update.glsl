#version 430 core
layout(local_size_x = 32, local_size_y = 1, local_size_z = 1) in;

uniform float deltaTime;
uniform float rotationSpeed;

layout (binding = 1, std430) buffer Data
{ 
    mat4[] modelMatrices; 
};

layout (binding = 2, std430) buffer UpdateData
{ 
    vec4[] rotationVectors; 
};


mat4 rotation3d(vec4 axis, float angle) {
  axis = normalize(axis);
  float s = sin(angle);
  float c = cos(angle);
  float oc = 1.0 - c;

  return mat4(
    oc * axis.x * axis.x + c,           oc * axis.x * axis.y - axis.z * s,  oc * axis.z * axis.x + axis.y * s,  0.0,
    oc * axis.x * axis.y + axis.z * s,  oc * axis.y * axis.y + c,           oc * axis.y * axis.z - axis.x * s,  0.0,
    oc * axis.z * axis.x - axis.y * s,  oc * axis.y * axis.z + axis.x * s,  oc * axis.z * axis.z + c,           0.0,
    0.0,                                0.0,                                0.0,                                1.0
  );
}

void main()
{
    uint id = gl_GlobalInvocationID.x;
    
    modelMatrices[id] *= rotation3d(rotationVectors[id], deltaTime * rotationSpeed);                                                   
}