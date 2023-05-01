using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientVisit : MonoBehaviour
{
    [SerializeField] private CupData[] cupDatas;
    
    private float timeToVisitClient = 7;
    private float timeToVisitClientLeft = 1;
    
    private Client[] clients;

    private void Awake()
    {
        clients = FindObjectsOfType<Client>();
    }

    private void Update()
    {
        if(timeToVisitClientLeft > 0)
        {
            timeToVisitClientLeft -= Time.deltaTime;
        }
        else
        {
            SelectClient();
        }
    }

    private void SelectClient()
    {
        foreach(Client client in clients)
        {
            if(!client.gameObject.activeSelf)
            {
                client.gameObject.SetActive(true);
                int cupDataRandom = Random.Range(0, cupDatas.Length);
                client.SetOrder(cupDatas[cupDataRandom]);
                timeToVisitClientLeft = timeToVisitClient;
                timeToVisitClient -= 0.1f;
                return;
            }
        }
    }
}
