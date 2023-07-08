using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private Sprite heartFull;
    [SerializeField] private Sprite heartEmpty;

    [SerializeField] private List<Image> heartImages;

    [SerializeField] private TextMeshProUGUI moneyText;


    public void Awake()
    {
        Player.Instance.updateHealth += UpdateHealth;
        Player.Instance.updateMoney += UpdateMoney;
    }

    public void UpdateHealth()
    {
        int heartCount = Player.Instance.Heart;

        foreach (Image heartImage in heartImages)
        {
            if (heartCount != 0)
            {
                heartImage.sprite = heartFull;
                heartCount--;
            }
            else
            {
                heartImage.sprite = heartEmpty;
            }
        }
    }

    public void UpdateMoney()
    {
        moneyText.text = "Money: " + Player.Instance.Money.ToString();
    }
}
