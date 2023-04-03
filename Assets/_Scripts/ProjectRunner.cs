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
        get { return PlayerPrefsPro.Get<bool>(nameof(isFirstSession)); }
        private set { PlayerPrefsPro.Set(nameof(isFirstSession), value); }
    }
    void Start()
    {
        if (isFirstSession)
        {
            isFirstSession = false;
            GameSaves.Instance.selectedDroneName.value = GameConfigs.Instance.shopSettings.drones[0].drone.name;
            Debug.LogError(isFirstSession);
        }

        SkinSelector skinSelector = new(skinPlace);
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
