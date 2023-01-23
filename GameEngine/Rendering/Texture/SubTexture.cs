using OpenTK.Mathematics;

public static class SubTexture
{
    public static Vector2[] FromLocationSize(Texture texture, Vector2 location, Vector2 size)
    {
        location = MapCoordinatesToTexels(texture, location);
        size = MapCoordinatesToTexels(texture, size);
        
        return new[]
        {
            new(location.X + size.X, location.Y),
            location + size,
            new(location.X, location.Y + size.Y),
            location
        };
    }

    private static Vector2 MapCoordinatesToTexels(Texture texture, Vector2 coordinates)
    {
        return new Vector2(coordinates.X / texture.Width, coordinates.Y / texture.Height);
    }
    
    public static Vector2[] FromLocationSize(Texture texture, Vector2 location, float size)
    {
        return FromLocationSize(texture, location, Vector2.One * size);
    }
}