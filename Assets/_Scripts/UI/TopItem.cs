using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TopItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI massage;
    [SerializeField] private Image bg;
    public PlayerModel currentModel { get; private set; }
    public void Show(PlayerModel model)
    {
        model.Scores.SubscribeAndInvoke(value => massage.text = model.playerName + ": " + value);
        currentModel = model;
    }
    public void SetColors(Color bgColor, Color textColor)
    {
        bg.color = bgColor;
        massage.color = textColor;
    }
}
