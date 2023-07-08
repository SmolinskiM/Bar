using UnityEngine;

public class ClientVisit : MonoBehaviour
{
    [SerializeField] private float timeToVisitClientLeft = 1;

    [SerializeField] private Client[] clients;

    private float timeToVisitClient = 7;

    private GameMeneger gameMeneger;

    private void Awake()
    {
        gameMeneger = GetComponent<GameMeneger>();
    }

    private void Update()
    {
        if (timeToVisitClientLeft > 0)
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
        foreach (Client client in clients)
        {
            if (!client.gameObject.activeSelf)
            {
                int cupDataRandom = Random.Range(0, gameMeneger.SurvivalMode.CupDatas.Length);
                client.SetOrder(gameMeneger.SurvivalMode.CupDatas[cupDataRandom]);
                timeToVisitClientLeft = timeToVisitClient;
                timeToVisitClient -= 0.1f;
                client.gameObject.SetActive(true);
                return;
            }
        }
    }
}
