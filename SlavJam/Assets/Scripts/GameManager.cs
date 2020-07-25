using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;
    public float tempScore;
    public Text scoreDisplay;
    public Slider meterDisplay;
    public GameObject gameOver;

    public float dangerMeterMax, dangerMeter;
    public float alertMeterMax, alertMeter;

    public float speedModifier = 1, speedUpRate;

    public ObstacleSkateboard previousObstacle;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        score = Mathf.FloorToInt(tempScore);
        scoreDisplay.text = "Score: " + score;

        if(dangerMeter > 0)
        {
            if(!meterDisplay.IsActive())
            {
                meterDisplay.gameObject.SetActive(true);
            }
            float value = dangerMeter / dangerMeterMax;
            meterDisplay.value = value;
        }
        if (alertMeter > 0)
        {
            if (!meterDisplay.IsActive())
            {
                meterDisplay.gameObject.SetActive(true);
            }
            float value = alertMeter / alertMeterMax;
            meterDisplay.value = value;
        }

        if(alertMeter == 0 && dangerMeter == 0)
        {
            if (meterDisplay.IsActive())
            {
                meterDisplay.gameObject.SetActive(false);
            }
        }

        if(alertMeter >= alertMeterMax)
        {
            if(PlayerController.instance.hasBag)
            {
                PlayerController.instance.hasBag = false;
                alertMeter = 0.01f;
            }
            else
            {
                gameOver.SetActive(true);
                Time.timeScale = 0;
            }         
        }

        if(dangerMeter >= dangerMeterMax)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
        }

        speedModifier += Time.deltaTime * speedUpRate;
    }
}
