using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    private bool isClientHaveCup;

    [SerializeField] private float patienceLeft;
    private float drinkingTimeLeft;

    [SerializeField] private CupData order;
    
    private const float PATIENCE = 10;
    private const float DRINKING_TIME = 1;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if(!isClientHaveCup)
        {
            PatienceClient();
        }
        else
        {
            Drinking();
        }

    }

    private void OnEnable()
    {
        isClientHaveCup = false;
        patienceLeft = PATIENCE;
        drinkingTimeLeft = DRINKING_TIME;
    }

    public void CheckOrder(Cup cup)
    {
        if(order != cup.CupData)
        {
            return;
        }
        
        if(!cup.IsCupFull)
        {
            return;
        }

        isClientHaveCup = true;
    }

    public void SetOrder(CupData cupData)
    {
        order = cupData;
    }

    private void PayMoney(int score)
    {
        Player.Instance.Score += (int)(score * (patienceLeft / PATIENCE));
    }

    private void PatienceClient()
    {
        if (patienceLeft > 0)
        {
            patienceLeft -= Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void Drinking()
    {
        if (drinkingTimeLeft > 0)
        {
            patienceLeft -= Time.deltaTime;
        }
        else
        {
            PayMoney(order.Value);
            gameObject.SetActive(false);
        }
    }
}
