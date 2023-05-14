#version 330

uniform vec2 gridValue;
uniform vec4 quadColor;
uniform vec4 voidColor;
in vec2 textureCoordinates;

out vec4 outputColor;

float grid(vec2 st, float res)
{
    vec2 grid = fract(st*res);
    return (step(res,grid.x) * step(res,grid.y));
}

void main()
{
    vec2 grid_uv = textureCoordinates.xy * gridValue.x; 
    float x = grid(grid_uv, gridValue.y);
         
    outputColor = x == 0 ? voidColor : quadColor;
}