
public class Genom
{
    public readonly byte[] Data;
    public readonly float Error;

    public Genom(byte[] data, float error)
    {
        Data = data;
        Error = error;
    }
}