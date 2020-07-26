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
    public Slider alertMeterDisplay;
    public Slider farMeterDisplay;
    public GameObject gameOver;

    public float dangerMeterMax, dangerMeter;
    public float alertMeterMax, alertMeter;

    public float speedModifier = 1, speedUpRate;

    public ObstacleSkateboard previousObstacle;

    public GameObject[] tracks;
    public int currentTrackID;


    public AudioClip[] gibberish;
    public AudioClip[] steps;

    public Button restart;
    public Button menu;


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

        restart.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);

        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        score = Mathf.FloorToInt(tempScore);
        scoreDisplay.text = "Score: " + score;

        if(dangerMeter > 0)
        {
            if(!farMeterDisplay.IsActive())
            {
                farMeterDisplay.gameObject.SetActive(true);
            }
            float value = dangerMeter / dangerMeterMax;
            farMeterDisplay.value = value;
        }
        if (alertMeter > 0)
        {
            if (!alertMeterDisplay.IsActive())
            {
                alertMeterDisplay.gameObject.SetActive(true);
            }
            float value = alertMeter / alertMeterMax;
            alertMeterDisplay.value = value;
        }

        if(alertMeter == 0)
        {
            if (alertMeterDisplay.IsActive())
            {
                alertMeterDisplay.gameObject.SetActive(false);
            }
        }
        if (dangerMeter == 0)
        {
            if (farMeterDisplay.IsActive())
            {
                farMeterDisplay.gameObject.SetActive(false);
            }
        }

        if (alertMeter >= alertMeterMax)
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
                restart.gameObject.SetActive(true);
                menu.gameObject.SetActive(true);
            }         
        }

        if(dangerMeter >= dangerMeterMax)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
            restart.gameObject.SetActive(true);
            menu.gameObject.SetActive(true);
        }

        speedModifier += Time.deltaTime * speedUpRate;
    }
}
