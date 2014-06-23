namespace PacmanGame
{
  public class Board
  {
    public int Columns
    {
      get;
      private set;
    }

    public int Rows
    {
      get;
      private set;
    }

    public Board(int columns, int rows)
    {
      Columns = columns;
      Rows = rows;
    }
  }
}