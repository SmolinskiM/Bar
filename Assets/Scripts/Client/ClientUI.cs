using UnityEngine;
using UnityEngine.UI;

public class ClientUI : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Image orderImage;

    private Client client;

    private Vector3 ofset = new Vector3(0.4f, 0.75f, 0);

    private void Awake()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.position + ofset);
        client = GetComponent<Client>();
    }

    private void OnEnable()
    {
        orderImage.sprite = client.Order.CupSprite;
    }

    void Update()
    {
        if (client.IsClientDrinking)
        {
            slider.value = client.DrinkingTimeLeft / client.DrinkingTime;
        }
        else
        {
            slider.value = client.PatienceTimeLeft / client.PatienceTime;
        }
    }
}
