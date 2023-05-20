using UnityEngine;

public class CupPoint : MonoBehaviour
{
    [SerializeField] private CupSlot[] cupSlots;

    [SerializeField] private InputDetector inputDetector;

    [SerializeField] private CupData cupData;

    [SerializeField] private SpriteRenderer plateSprite;

    private void Awake()
    {
        inputDetector.onClickEvent += OnCupPointClicked;
    }

    private void Start()
    {
        plateSprite.sprite = cupData.CupSprite;
    }

    private void OnCupPointClicked()
    {
        if (Player.Instance.Cup != null)
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
        foreach (CupSlot cupSlot in cupSlots)
        {
            if (cupSlot.Cup != null)
            {
                cupSlot.Cup.MoveCup(Player.Instance.transform);
                Player.Instance.Cup = cupSlot.Cup;
                cupSlot.Cup = null;
                return;
            }
        }
    }

    private void PutCup()
    {
        if (Player.Instance.Cup.CupData != cupData)
        {
            return;
        }

        foreach (CupSlot cupSlot in cupSlots)
        {
            if (cupSlot.Cup == null)
            {
                Player.Instance.Cup.MoveCup(cupSlot.transform);
                cupSlot.Cup = Player.Instance.Cup;
                Player.Instance.Cup = null;
                return;
            }
        }
    }
}
