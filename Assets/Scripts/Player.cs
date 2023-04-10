using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SingletoneMonobehaviour<Player>
{
    [SerializeField] private Cup cup;
    private CupSpriteShower cupSpriteShower;

    public Cup Cup { get { return cup; }}

    private void Start()
    {
        cupSpriteShower = GetComponent<CupSpriteShower>();
    }

    public void ChangeCup(Cup cup = null)
    {
        this.cup = cup;
        cupSpriteShower.ChangeCupSprite(cup);

    }
}
