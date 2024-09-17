using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : Singleton<LevelBoundary>
{
    public static float leftSide = -3.5f;
    public static float rightSide = 3.5f;
    public float internalLeft;
    public float internalRight;
    public PlayerMove player;
    public LevelRun runCoint;


    // Update is called once per frame
    void Update()
    {
        internalLeft = leftSide;
        internalRight = rightSide;
    }

    public void StartGame()
    {
        GenarateLevel.Ins.StartGenarateLevel();
        player.StartRunning();
    }
    
    public void GameOver() 
    {
        runCoint.StopRun();
        UIManager.Ins.ShowDeadNotification();
    }



    public void ResetGame() 
    {
        player.transform.position = new Vector3(-0.01484594f, 1.28f, -18.71f);
        player.isRunning = false;
    }
 
}
