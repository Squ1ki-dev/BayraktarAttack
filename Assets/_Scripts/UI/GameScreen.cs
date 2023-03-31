using System.Collections;
using System.Collections.Generic;
using TMPro;
using Tools;
using UnityEngine;

public class GameScreen : WindowBase
{
    [field: SerializeField] public Joystick joystick { get; private set; }
    [SerializeField] private TextMeshProUGUI timer;
    [SerializeField] private PlayersTopView top;
    public void Show(PlayerModel player, List<PlayerModel> oponents, GameModel gameModel)
    {
        gameModel.TimeToEnd.SubscribeAndInvoke(value => timer.text = value.ToString());
        top.Present(oponents, player);
    }
}
