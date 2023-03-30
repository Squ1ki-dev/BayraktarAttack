using UnityEngine;

[CreateAssetMenu(menuName = "Configs/GameSettings", fileName = "GameSettings")]
public class GameSettings : ScriptableObject
{
    public int maxOponentsInScene;
    public int maxTargetsInScene;
    public RivalsAISettings rivalsAISettings;
}
