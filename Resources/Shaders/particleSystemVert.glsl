#version 330 core

void main(void)
{            
    gl_Position = vec4(vertexPosition, 1.0) * model * view * projection;
}