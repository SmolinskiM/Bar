using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeerDispenser : MonoBehaviour
{
    private Button beerDispenserButton;
    private Player player;

    private void Start()
    {
        beerDispenserButton = GetComponent<MovePlayer>().PlaceButton;
        player = Player.Instance.GetComponent<Player>();
        beerDispenserButton.onClick.AddListener(CompleteCup);
    }

    private void CompleteCup()
    {
        if(player.Cup == null)
        {
            return;
        }

        player.Cup.IsCupFull = true;
    }
}
