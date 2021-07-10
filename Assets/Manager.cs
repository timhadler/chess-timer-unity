using Microsoft.Unity.VisualStudio.Editor;
using System.Threading;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class Manager : MonoBehaviour
{
    [Header("Menu")]
    public GameObject menuCanvas;

    [Header("Timer")]
    public GameObject timerCanvas;
    public bool gameActive = false;
    public GameObject player_1;
    public GameObject player_2;
    public TMP_Text startPauseText;
    public GameObject playSymbol;
    public GameObject pauseSymbol;

    private bool gameHasStarted = false;
    private Button playerScript_1;
    private Button playerScript_2;

    // Start is called before the first frame update
    void Start()
    {
        playerScript_1 = player_1.GetComponent<Button>();
        playerScript_2 = player_2.GetComponent<Button>();
    }


    /* Move timer function from Button to Manager 
       Move playPause button stuff to new playButton script
       Disable active players button when pause is hit*/


    public void startTimer()
    {
        menuCanvas.SetActive(false);
        timerCanvas.SetActive(true);
    }

    public void setMinutes(int i)
    {
        float mins = 0;
        switch (i)
        {
            case 0:
                mins = 1;
                break;
            case 1:
                mins = 2;
                break;
            case 2:
                mins = 3;
                break;
            case 3:
                mins = 5;
                break;
            case 4:
                mins = 10;
                break;
            case 5:
                mins = 15;
                break;
            case 6:
                mins = 20;
                break;
            case 7:
                mins = 30;
                break;
        }
        playerScript_1.setMins(mins*60);
        playerScript_2.setMins(mins*60);
    }

    public void setBonus(int i)
    {
        int sec = 0;
        switch (i)
        {
            case 0:
                sec = 0;
                break;
            case 1:
                sec = 1;
                break;
            case 2:
                sec = 2;
                break;
            case 3:
                sec = 5;
                break;
            case 4:
                sec = 10;
                break;
        }
        playerScript_1.setBonusTime(sec);
        playerScript_2.setBonusTime(sec);
    }

    public void StartPause()
    {
        if (gameActive)
        {
            //startPauseText.text = "Start";
            //char c = '\u23F8';
            //startPauseText.text = c.ToString();
            pauseSymbol.SetActive(false);
            playSymbol.SetActive(true);
            gameActive = false;

        }
        else
        {
            //startPauseText.text = "Pause";
            playSymbol.SetActive(false);
            pauseSymbol.SetActive(true);
            gameActive = true;


            if (!gameHasStarted)
            {
                playerScript_1.ToggleActive();
                gameHasStarted = true;
            }
        }
    }

    public void Player_1_Button()
    {
        if (playerScript_1.active)
        {
            SwitchTurn();
        }
    }

    public void Player_2_Button()
    {
        if (playerScript_2.active)
        {
            SwitchTurn();
        }
    }

    void SwitchTurn()
    {
        playerScript_1.ToggleActive();
        playerScript_2.ToggleActive();
    }
}
