#version 330
in vec3 InPosition;

smooth out vec3 textureCoordinates;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

void main()
{
    vec4 position = vec4(InPosition, 1.0) * model * view * projection;
	// setting the z coordinate to w forces the position to be on the far clipping-plane
	// because after perspective divide, which is a division by w, the result is 1
    gl_Position = position;
	// interpolate the positions between the vertices
	// after rasterization we in fact get the position on the cubes surface for each fragment
    textureCoordinates = InPosition;
}