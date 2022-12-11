
public static class GameObjectId
{
    private static int _id;

    public static int Evaluate() => ++_id;
}