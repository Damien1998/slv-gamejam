using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    public float scorePerSecond;

    private bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange)
        {
            GameManager.instance.tempScore += scorePerSecond * Time.deltaTime;
            GameManager.instance.alertMeter += Time.deltaTime;
        }
        else
        {
            if (GameManager.instance.alertMeter > 0)
            {
                if(!PlayerController.instance.isRunning)
                {
                    GameManager.instance.alertMeter -= 3 * Time.deltaTime;
                }                
            }
            else
            {
                GameManager.instance.alertMeter = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
