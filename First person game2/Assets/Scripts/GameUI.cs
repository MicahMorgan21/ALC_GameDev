using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [Header("HUD")]

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI ammoText;

    public Image healthBarFill;

    [Header("Pause Menu")]
    public GameObject pauseMenu;

    [Header("End Game Screen")]

    public GameObject endGameScreen;

    public TextMeshProUGUI endGameHeaderText;

    public TextMeshProUGUI endGameScoreText;

    // Instance

    public static GameUI instance;

    void Awake()
    {
        //Set the instance to this script
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void UpdateHealthBar(int curHP, int maxHP)
    {
        healthBarFill.fillAmount = (float)curHP / (float)maxHP;
    }

     public void UpdateScoreText(int score)
     {
         scoreText.text = "Score: " + score;
     }

     public void UpdateAmoText( int curAmmo, int maxAmmo)
     {
         ammoText.text = "Ammo: " + curAmmo + " / " + maxAmmo;
     }

     public void TogglePauseMenu( bool paused)
     {
         pauseMenu.SetActive(paused);
     }

     public void SetEndGameScreen(bool won, int score)
     {
         endGameScreen.SetActive(true);
         endGameHeaderText.text = won == true ? "You win, you good" : "You lose, You bad";
         endGameHeaderText.color = won == true ? Color.green : Color.red;
         endGameScoreText.text = "<b>Score</b>\n" + score;
     }

     public void OnResumeButton()
     {
         GameManager.instance.TogglePausedGame();
     }

     public void OnRestartButton()
     {
         SceneManager.LoadScene("Game");
     }

     public void OnMenuButton()
     {
         SceneManager.LoadScene("Menu");
     }


}
