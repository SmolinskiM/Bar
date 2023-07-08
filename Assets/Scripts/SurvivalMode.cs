using UnityEngine;

public class SurvivalMode : MonoBehaviour
{
    [SerializeField] private CupDataList cupDataList;
    [SerializeField] private CupPoint[] cupPoints;

    private CupData[] cupDatas = new CupData[3];

    public CupData[] CupDatas { get { return cupDatas; } }

    void Awake()
    {
        for (int i = 0; i < cupDatas.Length; i++)
        {
            cupDatas[i] = cupDataList.CupDatas[Random.Range(0, cupDatas.Length)];
            cupPoints[i].CupData = cupDatas[i];
        }
    }
}
