using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

public class ProjectRunner : MonoBehaviour
{
    void Start()
    {
        WindowManager.Instance.Show<MainScreen>().Show();
    }
}
