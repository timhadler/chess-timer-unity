using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public Manager managerScript;
    public TMP_Text timerText;
    public Color activeColor;
    public bool active = false;        // Player clock active, public so the manager script knows if a button press is valid or not (players turn)

    private Image image;
    [SerializeField]
    private float timerValue;
    private int bonus;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.color = Color.grey;
    }

    // Update is called once per frame
    void Update()
    {
        if (active && managerScript.gameActive)
        {
            if (timerValue > 0)
            {
                timerValue -= Time.deltaTime;
            }
            else
            {
                timerValue = 0;
                image.color = Color.red;
                active = false;
            }

            DisplayTimer(timerValue);
        }
    }


    public void setMins(float _mins)
    {
        timerValue = _mins;

        DisplayTimer(timerValue);
    }

    public void setBonusTime(int _bonus)
    {
        bonus = _bonus;
    }

    public void ToggleActive()
    {
        if (managerScript.gameActive)
        {
            if (active)
            {
                timerValue += bonus;
                DisplayTimer(timerValue);
                setDisabled();
            }
            else
            {
                setActive();
            }
        }
    }


    public void setActive()
    {
        image.color = activeColor;
        active = true;
    }


    public void setDisabled()
    {
        image.color = Color.grey;
        active = false;
    }


    void DisplayTimer(float _time)
    {
        float min;
        float sec;

        if (_time < 0)
        {
            _time = 0;
        }

        min = Mathf.FloorToInt(_time / 60);
        sec = Mathf.FloorToInt(_time % 60);

        timerText.text = string.Format("{0:00}:{1:00}", min, sec);
    }
}
