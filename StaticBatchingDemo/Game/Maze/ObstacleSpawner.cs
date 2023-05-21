using OpenTK.Mathematics;

public class ObstacleSpawner
{
    private readonly int _tileSize = 32;
    private readonly Vector2i _textureSize = new(160, 128);
    private readonly IReadOnlyDictionary<int, int> _bitmapToSpriteIndex = new Dictionary<int, int>()
    {
        {05, 11}, {68, 02}, {17, 05}, {00, 15}, {16, 00}, {64, 03},
        {01, 10}, {04, 01}, {65, 12}, {193, 12}, {23, 08}, {29, 08}, 
        {80, 07}, {112, 07}, {20, 06}, {28, 06}, {85, 16}, {07, 11}, 
        {71, 13}, {197, 13}, {199, 13}, {124, 09}, {92, 09}, {116, 09}, 
        {69, 13}, {21, 08}, {31, 08}, {84, 09}, {209, 14}, {113, 14},
        {255, 16}, {241, 14}, {215, 16}, {247, 16}, {253, 16}, {127, 16}, 
        {223, 16}, {246, 16}, {81, 14}, {125, 16}, {245, 16}, {221, 16}, 
        {93, 16}, {95, 16}, {213, 16}, {117, 16}, {119, 16}, {87, 16},
    };

    public Mesh Create(Vector2i position, TileNeighbours tileNeighbours)
    {
        int bitmapIndex = AutoTiling.GetBitmapIndex(ref tileNeighbours);
        int spriteSheetIndex = _bitmapToSpriteIndex[bitmapIndex];
        
        int xLocation = (spriteSheetIndex * _tileSize) % _textureSize.X;
        int yLocation = (spriteSheetIndex * _tileSize - xLocation) / _textureSize.X * _tileSize;
        Vector2 location = new Vector2i(xLocation, yLocation);
        Vector2[] texCoord = SubTexture.FromLocationSize(_textureSize, location, _tileSize);
        
        Mesh mesh = new QuadMeshData(1, position.ToVector3()).Build();
        mesh.Attributes["TexCoord"].Data = new[]
        {
            texCoord[0].X, texCoord[0].Y, 
            texCoord[1].X, texCoord[1].Y, 
            texCoord[2].X, texCoord[2].Y, 
            texCoord[3].X, texCoord[3].Y, 
        };

        return mesh;
    }
}