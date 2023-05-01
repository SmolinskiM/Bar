using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    [SerializeField] private CupData cupData;
    private SpriteRenderer spriteRenderer;
    
    private bool isCupFull;

    public CupData CupData { get { return cupData; } }
    public bool IsCupFull { get { return isCupFull; } set { isCupFull = value; } }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        spriteRenderer.sprite = cupData.CupSpriteEmpty;
    }

    public void MoveCup(Transform destinationPoint)
    {
        transform.SetParent(destinationPoint);
        transform.position = destinationPoint.position;
    }

    public void ChangeSprite(Sprite cupSprite)
    {
        spriteRenderer.sprite = cupSprite;
    }
}
