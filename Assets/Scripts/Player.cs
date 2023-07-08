using System;

public class Player : SingletoneMonobehaviour<Player>
{
    public Action updateHealth;
    public Action updateMoney;

    private Cup cup;

    private int money;
    private int heart = 3;

    public int Money { get { return money; } set { money = value; } }
    public int Heart { get { return heart; } }
    public Cup Cup { get { return cup; } set { cup = value; } }

    public void LostHeart()
    {
        heart--;
        updateHealth?.Invoke();
    }

    public void AddMoney(int moneyToAdd)
    {
        money = moneyToAdd;
        updateMoney?.Invoke();
    }
}
