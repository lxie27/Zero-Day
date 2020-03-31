using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using System;

public class GameClock : MonoBehaviour
{
	public Text timerText;
    public Text lossText;

    // How much game time in seconds
	public float time = 300;

    public bool gameOver = false;

	void Start()
	{
		StartCoundownTimer();
	}

	void StartCoundownTimer()
	{
		if (timerText != null)
		{
	
			timerText.text = "Time Left: 05:00:000";
			InvokeRepeating("UpdateTimer", 0.0f, 0.01667f);
		}
	}

	void UpdateTimer()
	{
		if (timerText != null && (time > 0))
		{
			time -= Time.deltaTime;
			string minutes = Mathf.Floor(time / 60).ToString("00");
			string seconds = (time % 60).ToString("00");
			string fraction = ((time * 100) % 100).ToString("000");
			timerText.text = "Time Left: " + minutes + ":" + seconds + ":" + fraction;
		}

        if (time < 0.1f)
        {
            gameOver = true;
        }

        if (gameOver)
        {
            lossText.gameObject.SetActive(true);
        }
        else
        {
            lossText.gameObject.SetActive(false);
        }
	}
}