using System;
using System.Numerics;
using System.Xml.Linq;

public class Field
{
    public Element[,] Map = new Element[12, 17];
    public Field()
    {
        fillField();
        DrawField();
    }
    private void fillField()
    {
        char[,] fieldFilledWithSymbols = new char[12, 17]
        {
             {'0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0'},
             {'0', 'I', '0', ' ', '0', '#', ' ', ' ', ' ', '#', ' ', ' ', '0', ' ', '#', '#', '0'},
             {'0', ' ', ' ', '#', '0', ' ', '#', '#', '0', ' ', '#', '0', ' ', ' ', '0', '#', '0'},
             {'0', '#', '0', '#', ' ', '#', '0', '0', '#', '0', '#', '0', '#', '0', '#', ' ', '0'},
             {'0', '0', '#', ' ', '0', '0', ' ', ' ', ' ', '0', ' ', '0', '#', ' ', '0', ' ', '0'},
             {'0', '#', '0', '0', '#', ' ', ' ', '0', '#', '#', ' ', '#', '0', ' ', '0', '#', '0'},
             {'0', '#', ' ', '#', ' ', '0', '0', '#', '0', '#', ' ', '0', '#', '#', '0', ' ', '0'},
             {'0', '0', ' ', '0', '#', '0', '#', ' ', '#', '0', '#', '0', ' ', '0', '#', '#', '0'},
             {'0', '#', '0', '0', '#', '#', ' ', '0', '#', '0', '0', ' ', '#', ' ', '0', '#', '0'},
             {'0', '#', ' ', ' ', ' ', '0', ' ', '0', ' ', '#', ' ', '#', '0', ' ', '0', ' ', '0'},
             {'0', ' ', '#', '#', ' ', ' ', '0', '#', '0', '0', ' ', '0', ' ', '#', '0', 'X', '0'},
             {'0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0', '0'}
        };
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 17; j++)
            {
                switch (fieldFilledWithSymbols[i, j])
                {
                    case 'I':
                        Map[i, j] = new Player();
                        break;
                    case '0':
                        Map[i, j] = new ConcreteWall();
                        break;
                    case '#':
                        Map[i, j] = new BrickWall();
                        break;
                    case ' ':
                        Map[i, j] = new Empty();
                        break;
                    case 'X':
                        Map[i, j] = new Finish();
                        break;
                    case '@':
                        Map[i, j] = new Bomb();
                        break;
                    case '.':
                        Map[i, j] = new BlastWave();
                        break;
                }
            }
        }
    }
    public void DrawField()
    {
        Console.Clear();
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 17; j++)
            {
                switch (Map[i, j].Symbol)
                {
                    case 'I':
                        Console.Write('I');
                        break;
                    case '0':
                        Console.Write('0');
                        break;
                    case '#':
                        Console.Write('#');
                        break;
                    case ' ':
                        Console.Write(' ');
                        break;
                    case 'X':
                        Console.Write('X');
                        break;
                    case '@':
                        Console.Write('@');
                        break;
                    case '.':
                        Console.Write('.');
                        break;
                }
            }
            Console.WriteLine();
        }
    }
}