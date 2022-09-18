﻿
public class World : IUpdatable, IInitializable
{
    private readonly IReadOnlyCollection<GameObject> _gameObjects;
    private readonly Camera _camera;

    public World(Camera camera, IReadOnlyCollection<GameObject> gameObjects)
    {
        _gameObjects = gameObjects;
        _camera = camera;
    }

    public void Initialize()
    {
        _gameObjects.ForEach(gameObject => gameObject.Initialize());
    }
    
    public void Update(float deltaTime)
    {
        _gameObjects.ForEach(gameObject => gameObject.Update(deltaTime));
    }

    public void Draw()
    {
        _gameObjects.ForEach(gameObject => gameObject.Draw(_camera.ProjectionMatrix, _camera.ViewMatrix));
    }
}