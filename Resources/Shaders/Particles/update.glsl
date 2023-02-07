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
 
bool needToUpdate(inout Particle particle)
{       
    if (particle.enabled == 1)
    {
        particle.elapsedTime += deltaTime;
        
        if (particle.elapsedTime > lifeTime)
        {
            particle.enabled = 0;                            
        }
    }
        
    return particle.enabled == 1;
}
 
void update(inout Particle particle)
{ 
    particle.position += particle.velocity * deltaTime * speed;             
    particle.rotation.z += deltaTime * 4;
    
    float lerp = particle.elapsedTime / lifeTime;
    particle.scale = mix(1, 0, lerp);
    particle.color = mix(vec4(1, 0, 0, 1), vec4(0, 0, 1, 0), lerp);          
}

void main()
{
    Particle particle = Particles[gl_GlobalInvocationID.x];
    
    if (needToUpdate(particle))
    {
        update(particle);
        Particles[gl_GlobalInvocationID.x] = particle;
    }      
}