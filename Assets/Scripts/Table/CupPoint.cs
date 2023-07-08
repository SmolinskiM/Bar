using UnityEngine;

public class CupPoint : MonoBehaviour
{
    [SerializeField] private CupSlot[] cupSlots;

    [SerializeField] private InputDetector inputDetector;

    [SerializeField] private SpriteRenderer plateSprite;

    private CupData cupData;

    public CupData CupData { get { return cupData; } set { cupData = value; } }

    private void Start()
    {
        inputDetector.onClickEvent += OnCupPointClicked;

        foreach (CupSlot cupSlot in cupSlots)
        {
            cupSlot.Cup.CupData = cupData;
            cupSlot.Cup.ChangeSprite(cupData.CupSpriteEmpty);
        }
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
