using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SingletoneMonobehaviour<Player>
{
    private Cup cup;

    private int score;

    public int Score { get { return score; } set { score = value; } }
    public Cup Cup { get { return cup; }}

    public void ChangeCup(Cup cup = null)
    {
        this.cup = cup;
    }
}
