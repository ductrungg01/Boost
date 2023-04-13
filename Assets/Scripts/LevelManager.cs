using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [HideInInspector] public bool isTransition = false;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Quit();
        }
    }

    public void LoadNextLevel()
    {
        // TODO: implement later
    }

    void Quit()
    {
        Application.Quit();
    }
}
