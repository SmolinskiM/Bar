using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupSpriteShower : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    public void ChangeCupSprite(Cup cup)
    {
        if(cup == null)
        {
            spriteRenderer.sprite = null;
            return;
        }

        if(cup.IsCupFull)
        {
            spriteRenderer.sprite = cup.CupData.CupSprite;
            return;
        }

        spriteRenderer.sprite = cup.CupData.CupSpriteEmpty;
    }
}
