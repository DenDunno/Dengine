#version 430 core

layout(location = 0) in vec3 vertexPosition;
uniform int verticesCount;

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

layout (binding = 0, std140) uniform CameraData
{ 
    mat4 viewMatrix;
    mat4 projectionMatrix;
    vec4 position;
};

out vec4 inputColor;

mat4 build_transform(vec4 position, vec4 angles, float scale) 
{
    float cosA = cos(angles.x);
    float cosB = cos(angles.y);
    float cosC = cos(angles.z);
    float sinA = sin(angles.x);
    float sinB = sin(angles.y);
    float sinC = sin(angles.z);
       
      
    return mat4(scale, 0.0, 0.0, 0,  
                0.0, scale, 0.0, 0, 
                0.0, 0.0, scale, 0, 
                0.0, 0.0, 0.0, 1.0) * 
                
                mat4(cosB * cosC, -cosB * sinC, sinB, 0,  
                sinA * sinB * cosC + cosA * sinC, -sinA * sinB * sinC + cosA * cosC, -sinA * cosB, 0, 
                -cosA * sinB * cosC + sinA * sinC, cosA * sinB * sinC + sinA * cosC, cosA * cosB, 0, 
                0.0, 0.0, 0.0, 1.0) *
                
                mat4(1.0, 0.0, 0.0, position.x,  
                0.0, 1.0, 0.0, position.y, 
                0.0, 0.0, 1.0, position.z, 
                0.0, 0.0, 0.0, 1.0);
}
 
void main(void)
{       
    Particle particle = Particles[gl_InstanceID];     
    
    mat4 model = build_transform(particle.position, particle.rotation, particle.scale);
    inputColor = particle.color;
    
    model = transpose(model);
    gl_Position = projectionMatrix * viewMatrix * model * vec4(vertexPosition, particle.enabled);
}