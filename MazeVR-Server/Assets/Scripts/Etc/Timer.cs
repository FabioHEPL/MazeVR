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

    int timeSecondDisplay;

    void Update()
    {
        timeSecond -= Time.deltaTime;
        timeSecondDisplay = Mathf.RoundToInt(timeSecond);

        if (timeSecondDisplay < 10)
        {
            timerText.text = ("0" + timeMinute + " : " + "0" + timeSecondDisplay);
        }
        else
        {
            timerText.text = (timeMinute + " : " + timeSecondDisplay);
        }

        if (timeSecond <= 0)
        {
            if (timeSecondDisplay != 0)
            {
                timeMinute--;
            }

            timerText.text = (timeMinute + " : " + "00");
            timeSecond = 60;
        }

        if (timeMinute < 0 && timeSecondDisplay == 0)
        {
            //vérifier la condision de vitoire/defaite et l'afficher
            if (timeMinute == -1)
            {
                timerText.text = ("00 : 00");
            }

            winCondition.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
