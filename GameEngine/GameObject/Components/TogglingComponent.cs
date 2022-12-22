﻿
public abstract class TogglingComponent : IGameComponent
{
    [EditorField] public bool Enabled = true;

    void IGameComponent.Update(float deltaTime)
    {
        if (Enabled)
        {
            OnUpdate(deltaTime);
        }
    }

    protected abstract void OnUpdate(float deltaTime);
}