
public class UpdateObjects
{
    public readonly IReadOnlyCollection<GameObject> GameObjects;
    public readonly Rigidbody[] Rigidbodies;

    public UpdateObjects(IReadOnlyCollection<GameObject> gameObjects, Rigidbody[] rigidbodies)
    {
        GameObjects = gameObjects;
        Rigidbodies = rigidbodies;
    }
}