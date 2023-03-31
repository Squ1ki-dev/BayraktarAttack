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
        for (int i = 0; i < duration; i++)
        {
            var wait = TaskTools.WaitForSeconds(1);
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
