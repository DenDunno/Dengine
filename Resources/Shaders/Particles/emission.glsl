#version 430 core
layout(local_size_x = 1, local_size_y = 1, local_size_z = 1) in;

uniform int pool;
uniform int index;
uniform vec4 position;

struct Particle
{
    vec4 position;  
    vec4 rotation;
    vec4 velocity;
    vec4 color;    
    float scale;
    float elapsedTime;
    int enabled;    
};

layout (binding = 0, std430) buffer ParticlesData
{ 
    Particle[] Particles; 
};

uint getIndex()
{    
    int result = int(index - gl_GlobalInvocationID.x);
    
    if (result < 0)
    {
        result = pool - 1;
    }
    
    return uint(result);
}

void main()
{
    uint id = getIndex();
    
    Particles[id].position = position;
    Particles[id].enabled = 1;
    Particles[id].elapsedTime = 0;
    Particles[id].color = vec4(1, 0, 0, 1);
    Particles[id].rotation.z = 0;
    Particles[id].scale = 0;         
}