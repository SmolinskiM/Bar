using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Place : MonoBehaviour
{
    [SerializeField] private Transform pointForCup;
    
    private InputDetector inputDetector;
    private PlayerMover playerMover;

    //Wait to change
    [SerializeField] private Cup cup;

    public InputDetector InputDetector { get { return inputDetector; } set { inputDetector = value; } }

    void Start()
    {
        playerMover = GetComponent<PlayerMover>();

        inputDetector.onClickEvent += PutCupOnTable;
        inputDetector.onClickEvent += playerMover.MovingPlayer;
    }

    private void PutCupOnTable()
    {
        if (Player.Instance.Cup == null)
        {
            return;
        }

        if(cup != null)
        {
            return;
        }

        cup = Player.Instance.Cup;
        Player.Instance.ChangeCup(null);

        inputDetector.onClickEvent += TakenCupFromTable;
        inputDetector.onClickEvent -= PutCupOnTable;
        cup.MoveCup(pointForCup);
    }

    private void TakenCupFromTable()
    {
        if (Player.Instance.Cup != null)
        {
            return;
        }

        if (cup == null)
        {
            return;
        }

        Player.Instance.ChangeCup(cup);
        cup.MoveCup(Player.Instance.transform);
        cup = null;

        inputDetector.onClickEvent += PutCupOnTable;
        inputDetector.onClickEvent -= TakenCupFromTable;
    }
}
