﻿
public class FPSCounter
{
    private MeanValue _meanValue;
    
    private int _fps;
    private float _clock;
    public int Value { get; private set; }
    
    public void Update(float deltaTime)
    {
        _fps++;
    }

    public void UpdateValue()
    {
        int temp = _fps;
        float coolDown = Clock.Time - _clock;
        _clock = Clock.Time;
        _fps = 0;

        Value = (int) (temp / coolDown);
    }
}