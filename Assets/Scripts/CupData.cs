using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cup", menuName = "Cup")]
public class CupData : ScriptableObject
{
    [SerializeField] private int value;
    
    [SerializeField] private Sprite cupSprite;
    [SerializeField] private Sprite cupSpriteEmpty;
    [SerializeField] private CupType cupType;

    public int Value { get { return value; } }
    public Sprite CupSprite { get { return cupSprite; } }
    public Sprite CupSpriteEmpty { get { return cupSpriteEmpty; } }

    public CupType CupType { get { return cupType; } }
}
