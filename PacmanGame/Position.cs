using System;

namespace PacmanGame
{
  public struct Position : IEquatable<Position>
  {
    public bool Equals(Position other)
    {
      return Row == other.Row && Column == other.Column;
    }

    public override int GetHashCode()
    {
      unchecked
      {
        return (Row * 397) ^ Column;
      }
    }

    public readonly int Row;
    public readonly int Column;

    public Position(int column, int row)
        : this()
    {
      Row = row;
      Column = column;
    }

    public override string ToString()
    {
      return String.Format("({0},{1})", Column, Row);
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj))
      {
        return false;
      }
      return obj is Position && Equals((Position)obj);
    }
  }
}