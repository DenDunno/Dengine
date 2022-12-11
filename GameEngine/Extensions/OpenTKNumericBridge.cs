using OpenTKVector = OpenTK.Mathematics.Vector3;
using NumericVector = System.Numerics.Vector3;

public static class OpenTKNumericBridge
{
    public static OpenTKVector NumericToOpenTk(NumericVector numeric)
    {
        return new OpenTKVector(numeric.X, numeric.Y, numeric.Z);
    }
}