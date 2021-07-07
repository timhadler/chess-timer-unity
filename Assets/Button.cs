using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public Manager managerScript;
    public TMP_Text timerText;
    public Color activeColor;
    public bool active = false;        // Player clock active

    private Image image;
    private float timerValue = 3;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.color = Color.grey;
        DisplayTimer(timerValue);
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


    public void ToggleActive()
    {
        if (managerScript.gameActive)
        {
            if (active)
            {
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


    void setDisabled()
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
