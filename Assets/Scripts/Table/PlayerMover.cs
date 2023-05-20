using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Transform destinationPoint;
    [SerializeField] private InputDetector InputDetector;

    void Awake()
    {
        if (destinationPoint == null)
        {
            destinationPoint = transform;
        }

        InputDetector.onClickEvent += MovingPlayer;
    }

    public void MovingPlayer()
    {
        Player.Instance.transform.position = destinationPoint.position;
    }
}
