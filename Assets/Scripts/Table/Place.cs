using UnityEngine;

public class Place : MonoBehaviour
{
    [SerializeField] private Transform pointForCup;
    [SerializeField] private InputDetector inputDetector;
    [SerializeField] private Client client;

    private Cup cup;
    private PlayerMover playerMover;

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

        if (cup != null)
        {
            return;
        }

        cup = Player.Instance.Cup;
        Player.Instance.Cup = null;

        if (client.gameObject.activeSelf)
        {
            client.CheckOrder(cup);
        }

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

        if (client.IsClientDrinking)
        {
            return;
        }

        Player.Instance.Cup = cup;
        cup.MoveCup(Player.Instance.transform);
        cup = null;

        inputDetector.onClickEvent += PutCupOnTable;
        inputDetector.onClickEvent -= TakenCupFromTable;
    }
}
