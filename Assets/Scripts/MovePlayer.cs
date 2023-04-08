using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private Button movePlayerButton;
    [SerializeField] private Transform destinationPoint;
    
    private Transform playerTransform;

    void Start()
    {
        if(destinationPoint == null)
        {
            destinationPoint = transform;
        }
        playerTransform = Player.Instance.transform;
        movePlayerButton.onClick.AddListener(MovingPlayer);
    }

    private void MovingPlayer()
    {
        playerTransform.position = destinationPoint.position;
    }
}
