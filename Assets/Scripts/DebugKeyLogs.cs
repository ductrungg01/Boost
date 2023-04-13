using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugKeyLogs : MonoBehaviour
{
    public LevelManager levelManager;
    public CollisionHandler rocketCollision;

    public KeyCode nextLevelKeycode;
    public KeyCode disableRocketCollision;
    
    void Update()
    {
        KeylogDebugImplement();
    }

    void KeylogDebugImplement()
    {
        if (Input.GetKeyDown(nextLevelKeycode))
        {
            levelManager.LoadNextLevel();
        }

        if (Input.GetKeyDown(disableRocketCollision))
        {
            rocketCollision.allowCollision = !rocketCollision.allowCollision; // toggle collision
        }
    }
}
