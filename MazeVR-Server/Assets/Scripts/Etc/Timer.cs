using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public GameObject winCondition;

    public int timeMinute = 15;
    float timeSecond = 60;

    bool timerIsFinich;
    int timeSecondDisplay;

    private void Start()
    {
        timerIsFinich = false;
    }

    void Update()
    {
        timeSecond -= Time.deltaTime;
        timeSecondDisplay = Mathf.RoundToInt(timeSecond);

        if (timeMinute <= 0 && timeSecond <= 0)
        {
            timerIsFinich = true;
            timerText.text = ("00 : 00");
            winCondition.SetActive(true);
        }

        if (timerIsFinich == false)
        {
            if (timeMinute != 0 && timeSecondDisplay == 0)
            {
                timeMinute--;
                timeSecond = 60;
            }

            if (timeMinute != 0)
            {
                if (timeMinute != 0 && timeSecondDisplay < 10)
                {
                    timerText.text = (timeMinute + " : " + "0" + timeSecondDisplay);
                    return;
                }

                timerText.text = (timeMinute + " : " + timeSecondDisplay);
            }

            if (timeMinute == 0 || timeMinute < 10)
            {
                if (timeMinute < 10 && timeSecondDisplay < 10)
                {
                    timerText.text = ("0" + timeMinute + " : " + "0" + timeSecondDisplay);
                    return;
                }

                timerText.text = ("0" + timeMinute + " : " + timeSecondDisplay);
            }
        }

    }
}
