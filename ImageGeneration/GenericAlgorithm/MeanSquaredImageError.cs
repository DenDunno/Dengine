using OpenTK.Mathematics;

public static class MeanSquaredImageError
{
    private static readonly float _maxEuclideanDistance = 658.40964f;

    public static float Evaluate(byte[] image, byte[] target, Vector2i dimensions)
    {
        float mse = 0.0f;
        
        for (int y = 0; y < dimensions.Y; ++y)
        {
            for (int x = 0; x < dimensions.X; ++x)
            {
                int pixelIndex = (y * dimensions.X + x) * 4;

                float deltaR = target[pixelIndex + 0] - image[pixelIndex + 0];
                float deltaG = target[pixelIndex + 1] - image[pixelIndex + 1];
                float deltaB = target[pixelIndex + 2] - image[pixelIndex + 2];
                float deltaA = target[pixelIndex + 3] - image[pixelIndex + 3];
                float delta = (deltaR * deltaR) + (deltaG * deltaG) + (deltaB * deltaB) + (deltaA * deltaA);
                
                mse += delta / _maxEuclideanDistance;
            }
        }

        return mse;
    }
}