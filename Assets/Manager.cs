using TMPro;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class Manager : MonoBehaviour
{
    public bool gameActive = false;
    public GameObject player_1;
    public GameObject player_2;
    public TMP_Text startPauseText;

    private bool gameHasStarted = false;
    private Button playerScript_1;
    private Button playerScript_2;

    // Start is called before the first frame update
    void Start()
    {
        playerScript_1 = player_1.GetComponent<Button>();
        playerScript_2 = player_2.GetComponent<Button>();
    }

    public void StartPause()
    {
        if (gameActive)
        {
            startPauseText.text = "Start";
            gameActive = false;
        }
        else
        {
            startPauseText.text = "Pause";
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
