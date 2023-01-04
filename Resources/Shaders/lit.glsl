#version 330 core
uniform vec3 baseColor;
uniform vec3 lightColor;
uniform vec3 lightPosition; 
uniform vec3 viewPosition; 
uniform float specularValue; 
uniform float diffuseValue; 
uniform float ambientValue; 
uniform int hasTexture = 1;
uniform sampler2D tex;
in vec3 normal;
in vec3 fragmentPosition; 
in vec2 textureCoordinates;

out vec4 outputColor;

void main()
{        
    vec3 fragmentNormal = normalize(normal);
    vec3 lightDirection = normalize(lightPosition - fragmentPosition);
    vec3 viewDirection = normalize(viewPosition - fragmentPosition);
    vec3 reflectDirection = reflect(-lightDirection, fragmentNormal);
    
    float diffuseDot = max(dot(fragmentNormal, lightDirection), 0.0);
    float specularDot = pow(max(dot(viewDirection, reflectDirection), 0.0), 32);
    
    vec3 ambient = ambientValue * lightColor;
    vec3 diffuse = diffuseDot * lightColor * diffuseValue;  
    vec3 specular = specularDot * lightColor * specularValue;

    vec3 base = baseColor;
     
    if (hasTexture == 1)
    {
        base *= vec3(texture(tex, textureCoordinates));
    }
    
    vec3 result = (ambient + diffuse + specular) * base;
    outputColor = vec4(result, 1.0);      
}