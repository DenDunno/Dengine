using OpenTK.Mathematics;

public static class SubTexture
{
    public static Vector2[] FromLocationSize(Vector2i textureSize, Vector2 location, Vector2 size)
    {
        location = MapCoordinatesToTexels(textureSize, location);
        size = MapCoordinatesToTexels(textureSize, size);
        
        return new[]
        {
            new(location.X + size.X, location.Y),
            location + size,
            new(location.X, location.Y + size.Y),
            location
        };
    }

    public static Vector2[] FromLocationSize(Texture2D texture, Vector2 location, Vector2 size)
    {
        return FromLocationSize(new Vector2i(texture.Data.Size.X, texture.Data.Size.Y), location, size);
    }

    public static Vector2[] FromLocationSize(Vector2i textureSize, Vector2 location, float size)
    {
        return FromLocationSize(textureSize, location, Vector2.One * size);
    }

    private static Vector2 MapCoordinatesToTexels(Vector2i textureSize, Vector2 coordinates)
    {
        return new Vector2(coordinates.X / textureSize.X, coordinates.Y / textureSize.Y);
    }
}