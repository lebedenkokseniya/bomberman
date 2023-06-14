using System.Diagnostics;

class Global
{
    static void Main()
    {
        Game game = new Game();
        game.GameProcess();
    }
}

public class Game
{
    State state = new State();
    Field field;
    Player player = new Player();
    Menu menu = new Menu();
    SplashScreen splashScreen = new SplashScreen();
    public Game()
    {
        menu.StartMenu(state);
        field = new Field();
        GameProcess();
    }

    int totalSeconds = 180;
    Stopwatch stopwatch = new Stopwatch();
    public void GameProcess()
    {
        stopwatch.Start();
        do
        {
                field.DrawField();
                TimeSpan remainingTime = TimeSpan.FromSeconds(totalSeconds - stopwatch.Elapsed.TotalSeconds);
                Console.SetCursorPosition(20, 15);
                Console.WriteLine(remainingTime.ToString("mm\\:ss"));
                Input(GetField(), state);
        } while (!state.GameFinished && stopwatch.Elapsed.TotalSeconds <= totalSeconds);
        Console.Clear();
        if (state.Win)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 44; j++)
                {
                    Console.Write(splashScreen.YouWin[i, j]);
                }
                Console.WriteLine();
            }
        }
        else
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 58; j++)
                {
                    Console.Write(splashScreen.GameOver[i, j]);
                }
                Console.WriteLine();
            }
        }
    }

    private Field GetField()
    {
        return field;
    }

    private void Input(Field field, State state)
    {
        ConsoleKeyInfo inputedKey = Console.ReadKey();
        player.Action(field, player, inputedKey);
        if (field.Map[player.y, player.x] is Finish)
        {
            state.GameFinished = true;
            state.Win = true;
        }
        Bomb bomb = new Bomb();
        bomb.Action(field, player.y, player.x, inputedKey, state);
    }
}
