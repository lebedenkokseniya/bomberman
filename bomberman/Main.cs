using System;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Numerics;

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

    int totalSeconds = 120;
    Stopwatch stopwatch = new Stopwatch();
    public void GameProcess()
    {
        do
        {
            stopwatch.Start();
            do
            {
                field.DrawField();
                TimeSpan remainingTime = TimeSpan.FromSeconds(totalSeconds - stopwatch.Elapsed.TotalSeconds);
                Console.SetCursorPosition(20, 15);
                Console.WriteLine(remainingTime.ToString("mm\\:ss"));
                state.GameFinished = Input(GetField());
            } while (stopwatch.Elapsed.TotalSeconds <= 120);
            state.GameFinished = true;
        } while (!state.GameFinished);
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
    private bool Input(Field field)
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
        return state.GameFinished;
    }
}