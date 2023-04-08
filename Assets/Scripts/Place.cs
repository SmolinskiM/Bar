using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Place : MonoBehaviour
{
    [SerializeField] private Button PlaceButton;
    [SerializeField] private Transform destinationPoint;
    
    private Cup cup;
    private Player player;

    void Start()
    {
        if(destinationPoint == null)
        {
            destinationPoint = transform;
        }
        player = Player.Instance.GetComponent<Player>();
        PlaceButton.onClick.AddListener(MovingPlayer);
        PlaceButton.onClick.AddListener(PutCupOnTable);
    }

    private void MovingPlayer()
    {
        player.transform.position = destinationPoint.position;
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
        player.Cup = null;

        PlaceButton.onClick.AddListener(TakenCupFromTable);
        PlaceButton.onClick.RemoveListener(PutCupOnTable);

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

        player.Cup = cup;
        cup = null;

        PlaceButton.onClick.AddListener(PutCupOnTable);
        PlaceButton.onClick.RemoveListener(TakenCupFromTable);
    }
}
