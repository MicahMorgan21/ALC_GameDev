using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int scoreToWin;
    public int curScore;
    public bool gamePaused;
    // Instance of Game Manager
    public static GameManager instance;

    void Awake()
    {
        //Set the instance of this script
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Cancel"))
        {
            TogglePausedGame();
        }
    }

    public void ToggglePausedGame()
    {
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused == true ? 0.0f : 1.0f;

        //Toggle Pause Menu
        GameUI.instance.TogglePauseMenu(gamePaused);
    }

    public void AddScore(int score)
    {
        curScore += score;

        //Update score text
        GameUI.instance.UpdateScoreText(curScore);

        //Have we reached the score to win?
        if(curScore >= scoreToWin)
            WinGame();
    }

    public void WinGame()
    {
        //Set end game screen
        GameUI.instance.SetEndGameScreen(true,curScore);
    }
}
