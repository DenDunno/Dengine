using System.Drawing;

public class PlayButton : Button
{
    public PlayButton() : base(new NGonView(30, Color.FromArgb(255, 167, 32), 3, "PlayButton"))
    {
    }
}