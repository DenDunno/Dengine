
public class UpdateObjects
{
    public readonly IReadOnlyCollection<GameObject> GameObjects;
    public readonly IReadOnlyCollection<Rigidbody> Rigidbodies;

    public UpdateObjects(IReadOnlyCollection<GameObject> gameObjects, IReadOnlyCollection<Rigidbody> rigidbodies)
    {
        GameObjects = gameObjects;
        Rigidbodies = rigidbodies;
    }
}