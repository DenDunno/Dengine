using OpenTK.Windowing.GraphicsLibraryFramework;

public class PlayerInput
{
    public readonly MouseState Mouse;
    public readonly KeyboardState Keyboard;

    public PlayerInput(MouseState mouseState, KeyboardState keyboardState)
    {
        Mouse = mouseState;
        Keyboard = keyboardState;
    }
}