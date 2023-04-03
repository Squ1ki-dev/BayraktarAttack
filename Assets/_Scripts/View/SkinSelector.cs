using System.Collections;
using System.Collections.Generic;
using Tools.Reactive;
using UnityEngine;
using UnityEngine.UI;

public class SkinSelector
{
    public SkinSelector(Transform skinPlace)
    {
        shopSettings.drones.ForEach(item => drones.Add((Object.Instantiate(item.drone, skinPlace), item.drone.name)));
        currentWatchingIdx.value = drones.FindIndex(item => item.Item2 == saves.selectedDroneName.value);
        currentWatchingIdx.SubscribeAndInvoke(idx =>
        {
            drones.ForEach(d => d.Item1.SetActive(false));
            drones[idx].Item1.SetActive(true);
            Debug.LogError(drones.FindIndex(item => item.Item2 == saves.selectedDroneName.value));
            Debug.LogError(saves.selectedDroneName.value);
        });
    }
    ShopSettings shopSettings => GameConfigs.Instance.shopSettings;
    GameSaves saves => GameSaves.Instance;
    private List<(Dron, string)> drones = new();
    private Reactive<int> currentWatchingIdx = new Reactive<int>();
    public void NextDrone()
    {
        if (currentWatchingIdx.value >= drones.Count - 1) return;
        currentWatchingIdx.value++;
    }

    public void PrevDrone()
    {
        if (currentWatchingIdx.value <= 0) return;
        currentWatchingIdx.value--;
    }
    public void SaveCurrentSkin()
    {
        saves.selectedDroneName.value = drones[currentWatchingIdx.value].Item2;
        Debug.Log("Skin " + saves.selectedDroneName.value + " salected");
    }

}
