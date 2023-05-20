using UnityEngine;

public class Client : MonoBehaviour
{
    [SerializeField] private float patienceTimeLeft;

    private bool isClientDrinking;

    private float drinkingTimeLeft;

    [SerializeField] private CupData order;

    private const float PATIENCE_TIME = 10;
    private const float DRINKING_TIME = 1;

    public bool IsClientDrinking { get { return isClientDrinking; } }
    public float PatienceTimeLeft { get { return patienceTimeLeft; } }
    public float DrinkingTimeLeft { get { return drinkingTimeLeft; } }
    public float PatienceTime { get { return PATIENCE_TIME; } }
    public float DrinkingTime { get { return DRINKING_TIME; } }
    public CupData Order { get { return order; } }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!isClientDrinking)
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
        patienceTimeLeft = PATIENCE_TIME;
        drinkingTimeLeft = DRINKING_TIME;
    }

    public void CheckOrder(Cup cup)
    {
        if (order != cup.CupData)
        {
            return;
        }

        if (!cup.IsCupFull)
        {
            return;
        }

        isClientDrinking = true;
        cup.IsCupFull = false;
        cup.ChangeSprite(cup.CupData.CupSpriteEmpty);
    }

    public void SetOrder(CupData cupData)
    {
        order = cupData;
    }

    private void PayMoney(int score)
    {
        Player.Instance.Score += (int)(score * (patienceTimeLeft / PATIENCE_TIME));
    }

    private void PatienceClient()
    {
        if (patienceTimeLeft > 0)
        {
            patienceTimeLeft -= Time.deltaTime;
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
            drinkingTimeLeft -= Time.deltaTime;
        }
        else
        {
            PayMoney(order.Value);
            isClientDrinking = false;
            gameObject.SetActive(false);
        }
    }
}
