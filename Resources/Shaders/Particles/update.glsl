#version 430 core
layout(local_size_x = 32, local_size_y = 1, local_size_z = 1) in;

uniform int colorsSize;
uniform vec4[30] colors;

uniform int sizeArrayLength;
uniform float[30] sizes;

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
 
vec4 getColor(float lerp)
{
    float scale = 1 / float(colorsSize);
    int firstIndex = int(lerp / scale);
    int secondIndex = firstIndex + 1;
    lerp = smoothstep(firstIndex * scale, secondIndex * scale, lerp);
    
    return mix(colors[firstIndex], colors[secondIndex], lerp);       
}

float getSize(float lerp)
{
    float scale = 1 / float(sizeArrayLength);
    int firstIndex = int(lerp / scale);
    int secondIndex = firstIndex + 1;
    lerp = smoothstep(firstIndex * scale, secondIndex * scale, lerp);
    
    return mix(sizes[firstIndex], sizes[secondIndex], lerp);       
}
 
void update(inout Particle particle)
{ 
    particle.position += particle.velocity * deltaTime * speed;             
    particle.rotation.z += deltaTime * 4;
    
    float lerp = particle.elapsedTime / lifeTime;
       
    particle.scale = getSize(lerp);     
    particle.color = getColor(lerp);    
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