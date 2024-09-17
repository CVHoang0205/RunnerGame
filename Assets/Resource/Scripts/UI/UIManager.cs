using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public GameObject CointPanel;
    public GameObject RunPanel;
    public GameObject MainMenu;
    public GameObject DeadNotification;

    public Button PlayGame;
    public Button Replay;

    // Start is called before the first frame update
    void Start()
    {
        InitGameState(1);
        PlayGame.onClick.AddListener(() => InitGameState(2));
        Replay.onClick.AddListener(Replaygame);
    }

    private void InitGameState(int state) 
    {
        MainMenu.SetActive(state == 1);
        CointPanel.SetActive(state == 2);
        RunPanel.SetActive(state == 2);
        if (state == 2) 
        {
            LevelBoundary.Ins.StartGame();
        }
        CameraFollower.Ins.ChangeState(state);
    }

    public void ShowDeadNotification() 
    {
        DeadNotification.SetActive(true);
    }

    public void Replaygame() 
    {
        DeadNotification.SetActive(false);
        Resetgame();
        InitGameState(2);
    }

    private void Resetgame()
    {
        CointText.cointCount = 0;
        LevelRun.Ins.ResetRunCount();
        LevelBoundary.Ins.ResetGame();
        GenarateLevel.Ins.ResetGeneration();
    }
}
