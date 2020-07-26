using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCrowd : MonoBehaviour
{
    private bool playerInRange;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange && Input.GetButton("Interact") && !PlayerController.instance.isOnSkateboard)
        {
            PlayerController.instance.isStopped = true;
            PlayerController.instance.moveSpeed = 0f;
            PlayerController.instance.isHiding = true;
        }
        else if(playerInRange)
        {
            PlayerController.instance.isStopped = false;
            PlayerController.instance.moveSpeed = PlayerController.instance.normalSpeed;
            PlayerController.instance.isHiding = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Play();
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Stop();
            playerInRange = false;
        }
    }
}
