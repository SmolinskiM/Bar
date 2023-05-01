using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupPoint : MonoBehaviour
{
    [SerializeField] private Transform[] cupPoints;

    [SerializeField] private InputDetector inputDetector;

    [SerializeField] private CupData cupData;

    private void Start()
    {
        inputDetector.onClickEvent += DecidingWhatToDoWithCup;
    }

    private void DecidingWhatToDoWithCup()
    {
        if(Player.Instance.Cup != null)
        {
            PutCup();
        }
        else
        {
            TakeCup();
        }
    }

    private void TakeCup()
    {
        foreach(Transform cupPoint in cupPoints)
        {
            if(cupPoint.childCount != 0)
            {
                Cup cup = cupPoint.GetComponentInChildren<Cup>();
                cup.MoveCup(Player.Instance.transform);
                Player.Instance.ChangeCup(cup);
                return;
            }
        }
    }

    private void PutCup()
    {
        if(Player.Instance.Cup.CupData != cupData)
        {
            return;
        }

        foreach (Transform cupPoint in cupPoints)
        {
            if (cupPoint.childCount == 0)
            {
                Player.Instance.Cup.MoveCup(cupPoint);
                Player.Instance.ChangeCup();
                return;
            }
        }
    }
}
