using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;
using UnityEngine.UI;

public class MainScreen : AnimatedWindowBase
{
    [SerializeField] private Button playBtn;

    public void Show()
    {
        playBtn.OnClick(() => GameSession.Instance.StartGame());
    }
}
