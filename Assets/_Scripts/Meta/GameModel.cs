using System.Collections;
using System.Collections.Generic;
using Tools;
using Tools.Reactive;
using UnityEngine;
using UnityEngine.Events;

public class GameModel
{
    public Reactive<int> TimeToEnd = new Reactive<int>();
    private bool isStarted = false;
    public UnityEvent onEnd = new();

    public void Start(int sessionDuration, PlayerModel player, List<PlayerModel> oponents)
    {
        TimeToEnd.value = sessionDuration;
        StartTimer(sessionDuration);
    }
    private async void StartTimer(int duration)
    {
        while(TimeToEnd.value > 0)
        {
            var wait = TaskTools.WaitForMilliseconds(1000);
            if (wait != null) await wait;
            else return;
            TimeToEnd.value--;
        }
        End();
    }
    public void End()
    {
        onEnd.Invoke();
        GameSession.Instance.EndGame(this);
    }
}
