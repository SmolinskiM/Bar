using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    private float patience;
    private float patienceLeft;

    private CupData order;

    private void Update()
    {
        if(patienceLeft > patience)
        {
            patienceLeft -= Time.deltaTime;
        }

        if(patienceLeft >= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void CheckOrder(Cup cup)
    {
        if(order != cup.CupData)
        {
            return;
        }
        
        if(!cup.IsCupFull)
        {
            return;
        }

        //Waiting time + money 
        gameObject.SetActive(false);
    }

    private void SetOrder(CupData cupData)
    {
        order = cupData;
    }
}
