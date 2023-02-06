#version 430 core
layout(local_size_x = 32, local_size_y = 1, local_size_z = 1) in;

uniform float deltaTime;
uniform float lifeTime;
uniform float speed;

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
 
bool needToUpdate(uint id)
{       
    if (Particles[id].enabled == 1)
    {
        Particles[id].elapsedTime += deltaTime;
        
        if (Particles[id].elapsedTime > lifeTime)
        {
            Particles[id].enabled = 0;            
        }
    }
        
    return Particles[id].enabled == 1;
}
 
void update(uint id)
{ 
    Particles[id].position += Particles[id].velocity * deltaTime * speed;             
    Particles[id].rotation.z += deltaTime * 4;
    
    float lerp = Particles[id].elapsedTime / lifeTime;
    Particles[id].scale = mix(1, 0, lerp);
    Particles[id].color = mix(vec4(1, 0, 0, 1), vec4(0, 0, 1, 0), lerp);          
}

void main()
{
    uint particleId = gl_GlobalInvocationID.x;
    
    if (needToUpdate(particleId))
    {
        update(particleId);
    }    
}