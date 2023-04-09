using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    private bool isCupFull;
    
    private CupData cupData;

    public bool IsCupFull { get { return isCupFull; } set { isCupFull = value; } }
}
