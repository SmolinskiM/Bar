using UnityEngine;

public class Cup : MonoBehaviour
{
    [SerializeField] private CupData cupData;
    private SpriteRenderer spriteRenderer;

    private bool isCupFull;

    public CupData CupData { get { return cupData; } set { cupData = value; } }
    public bool IsCupFull { get { return isCupFull; } set { isCupFull = value; } }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void MoveCup(Transform destinationPoint)
    {
        transform.SetParent(destinationPoint);
        transform.position = new Vector3(destinationPoint.position.x, destinationPoint.position.y, -0.2f);
    }

    public void ChangeSprite(Sprite cupSprite)
    {
        spriteRenderer.sprite = cupSprite;
    }
}
