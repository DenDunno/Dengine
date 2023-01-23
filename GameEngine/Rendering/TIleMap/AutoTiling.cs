
public class AutoTiling
{
    public static int GetBitmapIndex(ref TileNeighbours neighbours)
    {
        int result = 0;
        
        TryEraseCorner(ref neighbours.TopLeft, neighbours.Top, neighbours.Left);
        TryEraseCorner(ref neighbours.TopRight, neighbours.Top, neighbours.Right);
        TryEraseCorner(ref neighbours.BottomLeft, neighbours.Bottom, neighbours.Left);
        TryEraseCorner(ref neighbours.BottomRight, neighbours.Bottom, neighbours.Right);

        result += GetSideValue(neighbours.Top, 0);
        result += GetSideValue(neighbours.TopRight, 1);
        result += GetSideValue(neighbours.Right, 2);
        result += GetSideValue(neighbours.BottomRight, 3);
        result += GetSideValue(neighbours.Bottom, 4);
        result += GetSideValue(neighbours.BottomLeft, 5);
        result += GetSideValue(neighbours.Left, 6);
        result += GetSideValue(neighbours.TopLeft, 7);

        return result;
    }

    private static int GetSideValue(bool side, int mask)
    {
        int result = 0;
        
        if (side)
        {
            result += (1 << mask);
        }

        return result;
    }

    private static void TryEraseCorner(ref bool corner, bool firstSide, bool secondSide)
    {
        if (!(firstSide && secondSide))
        {
            corner = false;
        }
    }
}