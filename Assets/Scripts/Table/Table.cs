using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] private InputDetector inputDetectorLeft;
    [SerializeField] private InputDetector InputDetectorRight;

    [SerializeField] private Place placeLeft;
    [SerializeField] private Place placeRight;

    private void Awake()
    {
        placeLeft.InputDetector = inputDetectorLeft;
        placeRight.InputDetector = InputDetectorRight;
    }
}
