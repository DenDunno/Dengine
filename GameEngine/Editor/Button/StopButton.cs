using System.Drawing;

public class StopButton : Button
{
    public StopButton() : base(new RectFilledView(25, Color.FromArgb(194, 0, 0), "StopButton"))
    {
        Enabled = false;
    }
}