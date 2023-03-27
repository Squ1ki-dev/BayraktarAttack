using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools;

public class ProjectRunner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var window = WindowManager.Instance.Show<MainScreen>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
