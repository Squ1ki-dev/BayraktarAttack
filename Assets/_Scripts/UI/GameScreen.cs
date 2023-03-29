using System.Collections;
using System.Collections.Generic;
using TMPro;
using Tools;
using UnityEngine;

public class GameScreen : WindowBase
{
    [field: SerializeField] public Joystick joystick { get; private set; }
    [SerializeField] private TextMeshProUGUI scores;
    public void Show(PlayerModel player)
    {

    }
}
