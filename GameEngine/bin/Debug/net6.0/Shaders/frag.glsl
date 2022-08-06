#version 330

in vec2 textureCoordinates;
in vec3 normal;
uniform sampler2D tex;
uniform vec3 lightPosition;
out vec4 outputColor;

void main()
{
    vec3 lightToPlane = lightPosition - normal;
    vec3 f = lightPosition;
    vec3 diffuseColor = vec3(0.1f, 0.1f, 0.1f);
    
    outputColor = texture(tex, textureCoordinates) + vec4(normal, 1); 
}