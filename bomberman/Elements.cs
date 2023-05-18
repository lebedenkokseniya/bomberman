using System;
using System.Numerics;

public class Element
{
    public int x;
    public int y;
    public char Symbol;
    public bool Destroyable;
    public bool CanDo;
    public virtual void Action() { }
}

public class Player : Element
{
    public Player()
    {
        x = 1;
        y = 1;
        Symbol = 'I';
        Destroyable = true;
    }
    public new void Action(Field field, Player player, ConsoleKeyInfo inputedKey)
    {
        switch (inputedKey.KeyChar)
        {
            case 'ц':
            case 'w':
                if (field.Map[player.y - 1, player.x].CanDo)
                {
                    field.Map[player.y, player.x] = new Empty();
                    player.y -= 1;
                    field.Map[player.y, player.x] = player;
                }
                break;
            case 'и':
            case 's':
                if (field.Map[player.y + 1, player.x].CanDo)
                {
                    field.Map[player.y, player.x] = new Empty();
                    player.y += 1;
                    field.Map[player.y, player.x] = player;
                }
                break;
            case 'ф':
            case 'a':
                if (field.Map[player.y, player.x - 1].CanDo)
                {
                    field.Map[player.y, player.x] = new Empty();
                    player.x -= 1;
                    field.Map[player.y, player.x] = player;
                }
                break;
            case 'в':
            case 'd':
                if (field.Map[player.y, player.x + 1].CanDo)
                {
                    field.Map[player.y, player.x] = new Empty();
                    player.x += 1;
                    field.Map[player.y, player.x] = player;
                }
                break;
        }
    }
}

public class Empty : Element
{
    public Empty()
    {
        Symbol = ' ';
        CanDo = true;
    }
}

public class Bomb : Element
{
    public Bomb()
    {
        Symbol = '@';
        CanDo = false;
    }
    public new void Action(Field field, int y, int x, ConsoleKeyInfo inputedKey, State state)
    {
        BlastWave blastWave = new BlastWave();
        switch (inputedKey.KeyChar)
        {
            case 'i':
            case 'ш':
                if (field.Map[y - 1, x].CanDo)
                {
                    field.Map[y - 1, x] = new Bomb();
                    blastWave.Action(field, y - 1, x, state);
                }
                break;
            case 'k':
            case 'л':
                if (field.Map[y + 1, x].CanDo)
                {
                    field.Map[y + 1, x] = new Bomb();
                    blastWave.Action(field, y + 1, x, state);
                }
                break;
            case 'j':
            case 'о':
                if (field.Map[y, x - 1].CanDo)
                {
                    field.Map[y, x - 1] = new Bomb();
                    blastWave.Action(field, y, x - 1, state);
                }
                break;
            case 'l':
            case 'д':
                if (field.Map[y, x + 1].CanDo)
                {
                    field.Map[y, x + 1] = new Bomb();
                    blastWave.Action(field, y, x + 1, state);
                }
                break;
        }
    }
}

public class BlastWave : Element
{
    public BlastWave()
    {
        Symbol = '.';
        CanDo = false;
    }
    bool thereIsABlastWave(Field field, int y, int x)
    {
        if (field.Map[y, x] is Empty || field.Map[y, x].Destroyable)
        {
            return true;
        }
        return false;
    }
    public async new Task Action(Field field, int y, int x, State state)
    {
        await Task.Delay(1300);
        field.Map[y, x] = new Empty();
        field.DrawField();
        if (thereIsABlastWave(field, y, x + 1))
        {
            field.Map[y, x + 1] = new BlastWave();
            if (field.Map[y, x + 1] is Player)
            {
                state.GameFinished = true;
            }
        }
        if (thereIsABlastWave(field, y, x - 1))
        {
            field.Map[y, x - 1] = new BlastWave();
            if (field.Map[y, x - 1] is Player)
            {
                state.GameFinished = true;
            }
        }
        if (thereIsABlastWave(field, y + 1, x))
        {
            field.Map[y + 1, x] = new BlastWave();
            if (field.Map[y + 1, x] is Player)
            {
                state.GameFinished = true;
            }
        }
        if (thereIsABlastWave(field, y - 1, x))
        {
            field.Map[y - 1, x] = new BlastWave();
            if (field.Map[y - 1, x] is Player)
            {
                state.GameFinished = true;
            }
        }
        field.DrawField();
        await Task.Delay(1300);
        if (field.Map[y, x + 1] is BlastWave)
        {
            field.Map[y, x + 1] = new Empty();
        }
        if (field.Map[y, x - 1] is BlastWave)
        {
            field.Map[y, x - 1] = new Empty();
        }
        if (field.Map[y + 1, x] is BlastWave)
        {
            field.Map[y + 1, x] = new Empty();
        }
        if (field.Map[y - 1, x] is BlastWave)
        {
            field.Map[y - 1, x] = new Empty();
        }
        field.DrawField();
    }
}

public class Wall : Element
{

}

public class BrickWall : Wall
{
    public BrickWall()
    {
        Symbol = '#';
        CanDo = false;
        Destroyable = true;
    }
}

public class ConcreteWall : Wall
{
    public ConcreteWall()
    {
        Symbol = '0';
        CanDo = false;
    }
}

public class Finish : Element
{
    public Finish()
    {
        Symbol = 'X';
        CanDo = true;
    }
}