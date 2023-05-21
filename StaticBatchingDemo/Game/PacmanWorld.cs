
public class PacmanWorld : IWorldFactory
{
    public List<GameObject> CreateGameObjects()
    {
        Transform mazeTransform = new();
        Transform cherryTransform = new();
        Transform characterTransform = new();
        
        Maze maze = new(mazeTransform);
        Cherry cherry = new(cherryTransform);
        Character character = new(cherry, maze, characterTransform);
        PacmanGame pacmanGame = new(character, cherry, maze);

        return new List<GameObject>()
        {
            GameObjectFactory.Point(pacmanGame),
            GameObjectFactory.Point(maze, mazeTransform),
            CreateCharacter(character, characterTransform),
            GameObjectFactory.CreateCamera(new OrthographicProjection()),
            GameObjectFactory.CreateLight(new LightData() {Ambient = 1f}),
            GameObjectFactory.Sprite(cherry, Paths.GetTexture("Cherry.png"), cherryTransform),
        };
    }

    private GameObject CreateCharacter(Character character, Transform transform)
    {
        GameObject view = GameObjectFactory.Sprite(character, Paths.GetTexture("Pacman/pac_man_0.png"), transform);
        Material material = ((Model)view.Data.Drawable).Data.Material;
        SpriteAnimation animation = new(Paths.GetTexturesInFolder("Pacman"), 0.15f, material);
        
        view.Data.Components.Add(animation);

        return view;
    }
}