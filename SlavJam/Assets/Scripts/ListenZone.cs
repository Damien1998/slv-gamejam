using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenZone : MonoBehaviour
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
            if (GameManager.instance.dangerMeter > 0)
            {
                GameManager.instance.dangerMeter -= 3 * Time.deltaTime;
            }
            else
            {
                GameManager.instance.dangerMeter = 0;
            }
        }
        else
        {
            GameManager.instance.dangerMeter += Time.deltaTime;
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
