using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class Manager : MonoBehaviour
{
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
