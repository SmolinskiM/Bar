using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Place : MonoBehaviour
{
    private Cup cup;
    
    private Player player;
    private Button placeButton;
    private CupSpriteShower cupSpriteShower;

    void Start()
    {
        cupSpriteShower = GetComponent<CupSpriteShower>();
        placeButton = GetComponent<MovePlayer>().PlaceButton;
        player = Player.Instance.GetComponent<Player>();
        placeButton.onClick.AddListener(PutCupOnTable);
    }

    private void PutCupOnTable()
    {
        if (player.Cup == null)
        {
            return;
        }

        if(cup != null)
        {
            return;
        }

        cup = player.Cup;
        player.ChangeCup(null);

        placeButton.onClick.AddListener(TakenCupFromTable);
        placeButton.onClick.RemoveListener(PutCupOnTable);
        cupSpriteShower.ChangeCupSprite(cup);
    }

    private void TakenCupFromTable()
    {
        if (player.Cup != null)
        {
            return;
        }

        if (cup == null)
        {
            return;
        }

        player.ChangeCup(cup);
        cup = null;

        placeButton.onClick.AddListener(PutCupOnTable);
        placeButton.onClick.RemoveListener(TakenCupFromTable);
        cupSpriteShower.ChangeCupSprite(cup);
    }
}
