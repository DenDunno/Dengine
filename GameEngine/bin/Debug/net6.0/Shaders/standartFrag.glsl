#version 330 core
out vec4 outputColor;

uniform vec3 baseColor;
uniform vec3 lightColor;
uniform vec3 lightPosition; 
uniform vec3 viewPosition; 
uniform int hasTexture = 1;
uniform sampler2D tex;
in vec3 normal;
in vec3 fragmentPosition; 
in vec2 textureCoordinates;

void main()
{    
    float ambientStrength = 0.1;
    vec3 ambient = ambientStrength * lightColor;

    vec3 norm = normalize(normal);
    vec3 lightDir = normalize(lightPosition - fragmentPosition);

    float diff = max(dot(norm, lightDir), 0.0) + 0.2f; 
    vec3 diffuse = diff * lightColor * 1.3f;

    float specularStrength = 0.8;
    vec3 viewDir = normalize(viewPosition - fragmentPosition);
    vec3 reflectDir = reflect(-lightDir, norm);
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), 32);
    vec3 specular = specularStrength * spec * lightColor;

    vec3 base = baseColor;
     
    if (hasTexture == 1)
    {
        base *= vec3(texture(tex, textureCoordinates));
    }
    
    vec3 result = (ambient + diffuse + specular) * base;
    outputColor = vec4(result, 1.0);      
}