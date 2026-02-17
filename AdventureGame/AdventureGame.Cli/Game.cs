using AdventureGame.Core;

public class Game ()
{
    // initializes classes required for game logic.

    private Maze maze;
    private Player player;
    private Monster monster;
    private Potion potion;
    private Weapon weapon;
    private bool GameOver = false;
    public string gameMessage = string.Empty;

    // actual algorithm for game: first, sets the size of the maze and creates required objects.
    public void GameLoop ()
    {
        maze = new Maze(10, 10);
        player = new Player();
        monster = new Monster();
        potion = new Potion();
        weapon = new Weapon(5);

        maze.PlacePlayer(player);
        maze.PlaceExit();
        maze.PlaceMonster();
        maze.PlacePotion();
        maze.PlaceWeapon();
        maze.PlaceInsideWalls();

        // Actual game loop
        // Console output: prints the maze on a clear console, asks for user key input, and makes sure the game is still running.

        while (true)
        {
            Console.Clear();
            PrintMaze();
            Console.WriteLine(gameMessage);

            if (GameOver)
            {
                gameMessage = string.Empty;
                break;
            }

            gameMessage = string.Empty;

            Console.Write("Enter move using WASD or arrow keys: ");
            var key = Console.ReadKey(true);
            PlayerMoves(key.Key);
            CheckForSpecialTile();
            maze.tiles[player.xPos, player.yPos] = '@';

        }

    }

    // prints maze tiles to console
    public void PrintMaze()
    {
        for (int y = 0; y < maze.height; y++)
        {
            for (int x = 0; x < maze.width; x++)
            {
                Console.Write(maze.tiles[x, y] + " ");
            }
            Console.WriteLine();
        }
    }

    // checks to make sure user key input is valid, checks maze wall boundaries, sets new player position
    public void PlayerMoves(ConsoleKey Key)
    {
        int xPosition = player.xPos;
        int yPosition = player.yPos;

        switch (Key)
        {
            case ConsoleKey.W : yPosition--; break;
            case ConsoleKey.UpArrow : yPosition--; break;
            case ConsoleKey.A : xPosition--; break;
            case ConsoleKey.LeftArrow : xPosition--; break;
            case ConsoleKey.S : yPosition++; break;
            case ConsoleKey.DownArrow : yPosition++; break;
            case ConsoleKey.D : xPosition++; break;
            case ConsoleKey.RightArrow : xPosition++; break;

            default: 
                gameMessage = "Invalid key. Use WASD or arrow keys.";
                return;
        }

        if (maze.tiles[xPosition, yPosition] == '#')
        {
            gameMessage = "Invalid input. Wall blocking path.";
            return;
        }

        maze.tiles[player.xPos, player.yPos] = '.';
        player.xPos = xPosition;
        player.yPos = yPosition;
    }

    // calls attack and take damage methods for player and monster, displays battle results to console.
    public void Battle()
    {
        while (player.Health > 0)
        {
            player.Attack(monster);
            gameMessage += "Player attacked monster! -" + player.damage + "HP\n";
            if (monster.Health <= 0)
            {
                gameMessage += "You defeated the monster!\n";
                maze.tiles[player.xPos, player.yPos] = '@';
                break;
            }
            monster.Attack(player);
            gameMessage += "Monster attacked player. -" + monster.damage + "HP\n";
            if (player.Health <=0)
            {
                gameMessage += "The monster killed you! Game over!\n";
                GameOver = true;
                break;
            }
        }
    }

    // checks player position for types of tiles, game ends if tile is an exit tile, battle commences if tile is a monster tile, etc.
    public void CheckForSpecialTile()
    {
        char tile = maze.tiles[player.xPos, player.yPos];

        if (tile == 'E')
        {
            gameMessage = "You have reached the exit! Game over!\n";
            maze.tiles[player.xPos, player.yPos] = '@';
            GameOver = true;
        }
        else if (tile == 'M')
        {
            gameMessage = "Oh no! You ran into a monster! Let the battle begin.\n";
            Battle();
        }
        else if (tile == 'P')
        {
            player.PickUpItem(potion);
            gameMessage = potion.pickupMessage;
            player.Heal(potion);
            maze.tiles[player.xPos, player.yPos] = '@';
        }
        else if (tile == 'W')
        {
            player.PickUpItem(weapon);
            gameMessage = weapon.pickupMessage;
            player.damage += player.GetHighestModifier();
            maze.tiles[player.xPos, player.yPos] = '@';
        }
    }

}
