#version 330 core
uniform vec4 baseColor;

uniform int hasTexture = 1;
uniform sampler2D tex;
in vec3 normal;
in vec3 fragmentPosition; 
in vec2 textureCoordinates;

out vec4 outputColor;

layout (std140) uniform CameraData
{ 
    mat4 viewMatrix;
    mat4 projectionMatrix;
    vec4 position;
};

layout (std140) uniform LightData
{ 
    vec4 lightColor;
    vec4 lightPosition;
    float specularValue; 
    float diffuseValue; 
    float ambientValue;   
};

void main()
{        
    vec3 fragmentNormal = normalize(normal);
    vec3 lightDirection = normalize(vec3(lightPosition.x, lightPosition.y, lightPosition.z) - fragmentPosition);
    vec3 viewDirection = normalize(vec3(position) - fragmentPosition);
    vec3 reflectDirection = reflect(-lightDirection, fragmentNormal);
    
    float diffuseDot = max(dot(fragmentNormal, lightDirection), 0.0);
    float specularDot = pow(max(dot(viewDirection, reflectDirection), 0.0), 32);
    
    vec4 ambient = ambientValue * vec4(1);
    vec4 diffuse = diffuseDot * lightColor * diffuseValue;  
    vec4 specular = specularDot * lightColor * specularValue;

    vec4 base = baseColor;
     
    if (hasTexture == 1)
    {
        base *= vec4(texture(tex, textureCoordinates));
    }

    vec4 light = ambient + diffuse + specular;
    light.w = 1;
          
    outputColor = light * base;      
}