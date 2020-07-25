using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBird : MonoBehaviour
{
    private bool playerInRange, activated;
    public float alertAmount;
    public float duration;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange && !Input.GetButton("SlowDown") && !activated)
        {
            StartCoroutine(StopPlayer());
            GameManager.instance.alertMeter += alertAmount;
            activated = true;
        }
    }

    IEnumerator StopPlayer()
    {
        PlayerController.instance.isStopped = true;
        PlayerController.instance.moveSpeed = 0;
        yield return new WaitForSecondsRealtime(duration);
        PlayerController.instance.isStopped = false;
        PlayerController.instance.moveSpeed = PlayerController.instance.normalSpeed;
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
            activated = false;
        }
    }
}
