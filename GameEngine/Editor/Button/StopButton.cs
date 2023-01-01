using System.Drawing;

public class StopButton : Button
{
    public StopButton() : base(new RectFilledView(50, Color.FromArgb(194, 0, 0), "StopButton"))
    {
    }

    protected override void OnClick()
    {
        Console.WriteLine("Pause");
    }
}