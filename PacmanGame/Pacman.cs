namespace PacmanGame
{
  public class Pacman
  {
    public Position Position
    {
      get;
      set;
    }

    public Orientation Orientation
    {
      get;
      set;
    }

    public Pacman()
    {
      Orientation = Orientation.Up;
    }
  }
}