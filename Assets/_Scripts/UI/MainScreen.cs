using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;
using UnityEngine.UI;
using System;

public class MainScreen : AnimatedWindowBase
{
    [SerializeField] private Button playBtn, nextBtn, prevBtn;

    public void Show(Action onPlay, Action onNextClick, Action onPrevClick)
    {
        playBtn.OnClick(() =>
        {
            onPlay?.Invoke();
            GameSession.Instance.StartGame();
        });
        nextBtn.OnClick(() => onNextClick?.Invoke());
        prevBtn.OnClick(() => onPrevClick?.Invoke());
    }
}
