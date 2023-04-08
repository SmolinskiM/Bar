using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SingletoneMonobehaviour<Player>
{
    private Cup cup;

    public Cup Cup { get { return cup; } set { cup = value; } }
}
