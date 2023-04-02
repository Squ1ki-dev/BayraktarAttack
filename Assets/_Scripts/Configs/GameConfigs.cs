using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

public class GameConfigs : Singleton<GameConfigs>
{
    public GameConfigs()
    {
        settings = Resources.LoadAll<GameSettings>("")[0];
        shopSettings = Resources.LoadAll<ShopSettings>("")[0];
    }
    public GameSettings settings;
    public ShopSettings shopSettings;
}
