using AdventureGame.Core;

public class Program
{
    public static void Main()
    {
        Game game = new Game();
        game.GameLoop();
        Console.WriteLine(game.gameMessage);
    }
}