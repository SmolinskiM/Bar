using UnityEngine;

public class GameMeneger : MonoBehaviour
{
    private SurvivalMode survivalMode;

    public SurvivalMode SurvivalMode { get { return survivalMode; } }

    private void Awake()
    {
        survivalMode = GetComponent<SurvivalMode>();
    }
}
