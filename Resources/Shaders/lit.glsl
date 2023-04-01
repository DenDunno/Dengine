#version 330 core
uniform vec4 baseColor;
uniform vec4 lightColor;
uniform vec3 lightPosition;  
uniform float specularValue; 
uniform float diffuseValue; 
uniform float ambientValue; 
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

void main()
{        
    vec3 fragmentNormal = normalize(normal);
    vec3 lightDirection = normalize(lightPosition - fragmentPosition);
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