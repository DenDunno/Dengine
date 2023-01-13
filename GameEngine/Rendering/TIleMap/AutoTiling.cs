
public class AutoTiling
{
    private readonly Dictionary<int, UnlitMaterial> _tiles = new();
    private int _result;
    
    public AutoTiling(Dictionary<int, Texture> tiles)
    {
        foreach (KeyValuePair<int,Texture> valuePair in tiles)
        {
            _tiles[valuePair.Key] = new UnlitMaterial(new LitMaterialData()
            {
                Base = valuePair.Value
            });
        }
    }

    public void Initialize()
    {
    }

    public UnlitMaterial GetMaterial(TileNeighbours neighbours)
    {
        return _tiles[GetIndex(neighbours)];
    }

    public int GetIndex(TileNeighbours neighbours)
    {
        _result = 0;
        
        TryEraseCorner(ref neighbours.TopLeft, neighbours.Top, neighbours.Left);
        TryEraseCorner(ref neighbours.TopRight, neighbours.Top, neighbours.Right);
        TryEraseCorner(ref neighbours.BottomLeft, neighbours.Bottom, neighbours.Left);
        TryEraseCorner(ref neighbours.BottomRight, neighbours.Bottom, neighbours.Right);

        TryAdd(neighbours.Top, 0);
        TryAdd(neighbours.TopRight, 1);
        TryAdd(neighbours.Right, 2);
        TryAdd(neighbours.BottomRight, 3);
        
        TryAdd(neighbours.Bottom, 4);
        TryAdd(neighbours.BottomLeft, 5);
        TryAdd(neighbours.Left, 6);
        TryAdd(neighbours.TopLeft, 7);

        return _result;
    }

    private void TryAdd(bool side, int mask)
    {
        if (side)
        {
            _result += (1 << mask);
        }
    }

    private void TryEraseCorner(ref bool corner, bool firstSide, bool secondSide)
    {
        if (!(firstSide && secondSide))
        {
            corner = false;
        }
    }
}