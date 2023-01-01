using System.Drawing;

public class PlayButton : Button
{
    public PlayButton() : base(new NGonView(50, Color.FromArgb(255, 167, 32), 3, "PlayButton"))
    {
    }

    protected override void OnClick()
    {
        Console.WriteLine("Play");
    }
}