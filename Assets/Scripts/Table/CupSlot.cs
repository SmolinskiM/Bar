using UnityEngine;

public class CupSlot : MonoBehaviour
{
    public Cup Cup { get; set; }

    private void Awake()
    {
        Cup = GetComponentInChildren<Cup>();
    }
}
