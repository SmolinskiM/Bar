using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private Button placeButton;
    [SerializeField] private Transform destinationPoint;

    private Player player;

    public Button PlaceButton { get { return placeButton; } }

    void Start()
    {
        if (destinationPoint == null)
        {
            destinationPoint = transform;
        }
        player = Player.Instance.GetComponent<Player>();
        placeButton.onClick.AddListener(MovingPlayer);
    }

    private void MovingPlayer()
    {
        player.transform.position = destinationPoint.position;
    }
}
