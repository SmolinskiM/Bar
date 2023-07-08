using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CupList", menuName = "CupList")]
public class CupDataList : ScriptableObject
{
    [SerializeField] private List<CupData> cupDatas;

    public List<CupData> CupDatas { get { return cupDatas; } }
}
