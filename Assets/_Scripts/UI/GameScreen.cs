using System.Collections;
using System.Collections.Generic;
using TMPro;
using Tools;
using UnityEngine;

public class GameScreen : WindowBase
{
    [field: SerializeField] public Joystick joystick { get; private set; }
    [SerializeField] private TextMeshProUGUI scores;
    [SerializeField] private PlayersTopView top;
    public void Show(PlayerModel player, List<PlayerModel> oponents)
    {
        player.Scores.SubscribeAndInvoke(value => scores.text = value.ToString());
        top.Present(oponents, player);
    }
}
