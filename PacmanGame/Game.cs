using System;
using System.Text;

namespace PacmanGame
{
  public class Game
  {
    private Board board;

    public Pacman Pacman
    {
      get;
      private set;
    }

    public string Representation
    {
      get
      {
        var representation = new StringBuilder();

        for (int row = 0; row < board.Rows; row++)
        {
          representation.AppendLine();

          for (int col = 0; col < board.Columns; col++)
            representation.Append(new Position(col, row).Equals(Pacman.Position)
                ? 'P'
                : '.');
        }
        return representation.ToString();
      }


    }

    public Game(int columns, int rows)
    {
      board = new Board(columns, rows);
      Pacman = new Pacman
      {
        Position = new Position(board.Columns / 2, board.Rows / 2)
      };
    }

    public void TurnPacman(Orientation orientation)
    {
      Pacman.Orientation = orientation;
    }

    public void Tick()
    {
      switch (Pacman.Orientation)
      {
        case Orientation.Up:
          Pacman.Position = Pacman.Position.Row == 0
              ? new Position(Pacman.Position.Column, board.Rows - 1)
              : new Position(Pacman.Position.Column, Pacman.Position.Row - 1);
          break;
        case Orientation.Left:
          Pacman.Position = Pacman.Position.Column == 0
             ? new Position(board.Columns - 1, Pacman.Position.Row)
             : new Position(Pacman.Position.Column - 1, Pacman.Position.Row);
          break;
        case Orientation.Right:
          Pacman.Position = Pacman.Position.Column == board.Columns - 1
             ? new Position(0, Pacman.Position.Row)
             : new Position(Pacman.Position.Column + 1, Pacman.Position.Row);
          break;
        case Orientation.Down:
          Pacman.Position = Pacman.Position.Row == board.Rows - 1
             ? new Position(Pacman.Position.Column, 0)
             : new Position(Pacman.Position.Column, Pacman.Position.Row + 1);
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    public void HalfASecondPassed(int howemanytimes)
    {
      for (int i = 0; i < howemanytimes; i++)
        Tick();
    }
  }
}