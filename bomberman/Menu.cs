using System;

public class Menu
{
    SplashScreen splashScreen = new SplashScreen();
    public void StartMenu(State state)
    {
        StartScreen();
        MainMenu(state);
    }
    private void MainMenu(State state)
    {
        int WhichKey = 1;
        MainMenuOutput(splashScreen.StartGameSq, splashScreen.Rules);
        do
        {
            ConsoleKey inputedKey = Console.ReadKey().Key;
            switch (inputedKey)
            {
                case ConsoleKey.DownArrow:
                    Console.Clear();
                    MainMenuOutput(splashScreen.StartGame, splashScreen.RulesSq);
                    WhichKey = 2;
                    break;
                case ConsoleKey.UpArrow:
                    Console.Clear();
                    MainMenuOutput(splashScreen.StartGameSq, splashScreen.Rules);
                    WhichKey = 1;
                    break;
                case ConsoleKey.Enter:
                    if (WhichKey == 2)
                    {
                        Console.Clear();
                        Console.Write
                        ("Ласкаво просимо до гри Bomberman! Правила гри прості: \n" +
                        "Ви маєте переміщатися гральним полем, руйнуючи на своєму \n" +
                        "шляху цегляні стіни за допомогою бомб, щоб досягти фінішу \n" +
                        "за відведений для цього час. Керування гравцем здійснюється \n" +
                        "за допомогою клавіш WASD. Ставити бомби Ви можете на пусті \n" +
                        "клітинки перед собою за допомогою клавіш IJKL, в залежності \n" +
                        "від напрямку, в якому Ви бажаєте поставити бомбу. Але будьте \n" +
                        "уважні! Адже вибухова хвиля від бомби може зачіпити і Вас, \n" +
                        "якщо вчасно не відбіги на безпечну відстань. Щоб повернутися \n" +
                        "до головного меню, натисніть Escape.");
                    }
                    if (WhichKey == 1)
                    {
                        Console.Clear();
                        state.GameStarted = true;
                        Countdown();
                    }
                    break;
                case ConsoleKey.Escape:
                    Console.Clear();
                    MainMenuOutput(splashScreen.StartGameSq, splashScreen.Rules);
                    WhichKey = 1;
                    break;
            }
        } while (!state.GameStarted);
    }
    private void MainMenuOutput(char[,] startGame, char[,] rules)
    {
        Console.WriteLine("   BOMBERMAN");
        Console.WriteLine();
        Console.WriteLine();
        for (int i = 0; i < startGame.GetLength(0); i++)
        {
            for (int j = 0; j < startGame.GetLength(1); j++)
            {
                Console.Write(startGame[i, j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        for (int i = 0; i < rules.GetLength(0); i++)
        {
            for (int j = 0; j < rules.GetLength(1); j++)
            {
                Console.Write(rules[i, j]);
            }
            Console.WriteLine();
        }
    }
    private void StartScreen()
    {
        StartScreenOutput(splashScreen.StartScreen4, 200);
        StartScreenOutput(splashScreen.StartScreen3, 200);
        StartScreenOutput(splashScreen.StartScreen2, 200);
        StartScreenOutput(splashScreen.StartScreen1, 1500);
        StartScreenOutput(splashScreen.StartScreen2, 200);
        StartScreenOutput(splashScreen.StartScreen3, 200);
        StartScreenOutput(splashScreen.StartScreen4, 200);
    }
    private void StartScreenOutput(char[,] screen, int time)
    {
        for (int i = 0; i < screen.GetLength(0); i++)
        {
            for (int j = 0; j < screen.GetLength(1); j++)
            {
                Console.Write(screen[i, j]);
            }
            Console.WriteLine();
        }
        Thread.Sleep(time);
        Console.Clear();
    }
    private void Countdown()
    {
        CountdownOutput(splashScreen.Countdown3);
        CountdownOutput(splashScreen.Countdown2);
        CountdownOutput(splashScreen.Countdown1);
        CountdownOutput(splashScreen.Start);
    }
    private void CountdownOutput(char[,] countdown)
    {
        Console.Clear();
        for (int i = 0; i < countdown.GetLength(0); i++)
        {
            for (int j = 0; j < countdown.GetLength(1); j++)
            {
                Console.Write(countdown[i, j]);
            }
            Console.WriteLine();
        }
        Thread.Sleep(1500);
    }
}