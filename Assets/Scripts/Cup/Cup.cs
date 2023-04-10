using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    [SerializeField] private CupData cupData;
    
    private bool isCupFull;

    public CupData CupData { get { return cupData; } }
    public bool IsCupFull { get { return isCupFull; } set { isCupFull = value; } }
}
