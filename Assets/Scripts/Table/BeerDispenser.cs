using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerDispenser : MonoBehaviour
{
    [SerializeField] private InputDetector inputDetector;

    private void Start()
    {
        inputDetector.onClickEvent += CompleteCup;
    }

    private void CompleteCup()
    {
        Player player = Player.Instance;

        if (player.Cup == null)
        {
            return;
        }

        player.Cup.IsCupFull = true;
        player.Cup.ChangeSprite(player.Cup.CupData.CupSprite);
    }
}
