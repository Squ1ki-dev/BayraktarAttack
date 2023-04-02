using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ShopItem
{
    public Dron drone;
    public int cost;
}
[CreateAssetMenu(fileName = "ShopSettings", menuName = "Configs/ShopSettings")]
public class ShopSettings : ScriptableObject
{
    public List<ShopItem> drones;
}
