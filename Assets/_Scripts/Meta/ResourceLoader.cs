using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ResourceLoader
{
    public static Dron LoadDronePrefab(string name) => Resources.Load<Dron>(name);
    public static List<Dron> LoadAllDronePrefabes() => Resources.LoadAll<Dron>("").ToList();
    public static List<Tank> LoadAllTanksPrefabes() => Resources.LoadAll<Tank>("").ToList();
    public static Dron LoadSelectedDronePrefab() => Resources.Load<Dron>(GameSaves.Instance.selectedDroneName.value);
}
