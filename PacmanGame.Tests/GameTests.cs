using NUnit.Framework;
using Should;

namespace PacmanGame.Tests
{
  [TestFixture]
  public class GameTests
  {

    [TestCase(3, 4, 1, 2)]
    [TestCase(6, 6, 3, 3)]
    public void GivenTheInitialBoard_PacmanShouldBeInTheMiddleOfTheBoard(int columns, int rows, int expectedColumn, int expectedRow)
    {
      var board = new Game(columns, rows);

      board.Pacman.Position.ShouldEqual(new Position(expectedColumn, expectedRow));
    }

    public class GivenABoard
    {
      private Game mGame;

      [SetUp]
      public void Setup()
      {
        mGame = new Game(3, 4);
      }

      [Test]
      public void PacmanShouldBeLookingUp()
      {
        mGame.Pacman.Orientation.ShouldEqual(Orientation.Up);
      }

      [TestCase(Orientation.Left)]
      [TestCase(Orientation.Right)]
      [TestCase(Orientation.Up)]
      [TestCase(Orientation.Down)]
      public void WhenPlayerSendsTurn_PacmanShouldBeLookingInTheSpecifiedDirection(Orientation orientation)
      {
        mGame.TurnPacman(orientation);

        mGame.Pacman.Orientation.ShouldEqual(orientation);
      }

      [TestCase(1, 2, Orientation.Up, 1, 1)]
      [TestCase(1, 2, Orientation.Left, 0, 2)]
      [TestCase(1, 2, Orientation.Right, 2, 2)]
      [TestCase(1, 2, Orientation.Down, 1, 3)]

      public void WhenPacmanTurnsAndTickHappens_ThenPacmanMoves(
          int initialColumn, int initialRow,
          Orientation newOrientation,
          int expectedColumn, int expectedRow)
      {
        TestPacmanMovement(initialColumn, initialRow, newOrientation, expectedColumn, expectedRow);
      }

      [TestCase(1, 0, Orientation.Up, 1, 3)]
      [TestCase(0, 1, Orientation.Left, 2, 1)]
      [TestCase(2, 2, Orientation.Right, 0, 2)]
      [TestCase(1, 3, Orientation.Down, 1, 0)]
      public void WhenPacmanTurnsAndTickHappens_ThenPacmanWrapsAround(
          int initialColumn, int initialRow,
          Orientation newOrientation,
          int expectedColumn, int expectedRow)
      {
        TestPacmanMovement(initialColumn, initialRow, newOrientation, expectedColumn, expectedRow);
      }

      private void TestPacmanMovement(int initialColumn, int initialRow, Orientation newOrientation, int expectedColumn, int expectedRow)
      {
        mGame.Pacman.Position = new Position(initialColumn, initialRow);
        mGame.Pacman.Orientation = Orientation.Right;
        
        mGame.TurnPacman(newOrientation);
        mGame.Tick();

        mGame.Pacman.Position.ShouldEqual(new Position(expectedColumn, expectedRow));
      }


      [TestCase(1, 2, Orientation.Up, 1, 1)]
      public void WhenAHalfOfSecondPasses_ThenPacmanMoves(
          int initialColumn, int initialRow,
          Orientation newOrientation,
          int expectedColumn, int expectedRow)
      {
        mGame.Pacman.Position = new Position(initialColumn, initialRow);

        mGame.TurnPacman(newOrientation);
        mGame.HalfASecondPassed(1);

        mGame.Pacman.Position.ShouldEqual(new Position(expectedColumn, expectedRow));
      }


      [TestCase(1, 2, @"
...
...
.P.
...")]
      public void WhenGameStarts_ThenBoardIsDisplayed(int initialColumn, int initialRow, string expectedOutput)
      {
        mGame.Pacman.Position = new Position(initialColumn, initialRow);
        mGame.Representation.ShouldEqual(expectedOutput);
      }
    }
  }
}