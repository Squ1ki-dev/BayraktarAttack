using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;
using Tools.PlayerPrefs;

public class ProjectRunner : MonoBehaviour
{
    public Transform skinPlace;
    public bool isFirstSession
    {
        get { return !PlayerPrefsPro.Get<bool>(nameof(isFirstSession)); }
        private set { PlayerPrefsPro.Set(nameof(isFirstSession), true); }
    }
    void Start()
    {
        SkinSelector skinSelector = new(skinPlace);
        if (isFirstSession)
        {
            GameSaves.Instance.selectedDroneName.value = GameConfigs.Instance.shopSettings.drones[0].drone.name;
        }
        WindowManager.Instance.Show<MainScreen>().Show(
            onPlay: () =>
        {
            skinSelector.SaveCurrentSkin();
        }, onNextClick: () =>
        {
            skinSelector.NextDrone();
        }, onPrevClick: () =>
        {
            skinSelector.PrevDrone();
        });
        Application.targetFrameRate = 360;
    }
}
