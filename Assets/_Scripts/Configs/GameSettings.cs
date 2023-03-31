using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/GameSettings", fileName = "GameSettings")]
public class GameSettings : ScriptableObject
{
    public int maxOponentsInScene;
    public int maxTargetsInScene;
    public int gameSessionDuration;
    public RivalsAISettings rivalsAISettings;
    public List<string> oponentNames;
}
