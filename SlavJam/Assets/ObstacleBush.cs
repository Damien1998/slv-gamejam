using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBush : MonoBehaviour
{
    public float duration;
    public float slowDownSpeed = 0f;
    public bool allowPickupOnSkateboard = false;
    public bool hidePlayer = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (allowPickupOnSkateboard || !PlayerController.instance.isOnSkateboard)
            {               
                StartCoroutine(StopPlayer());
                if(hidePlayer)
                {
                    StartCoroutine(HidePlayer());
                }
            }          
        }
    }

    IEnumerator StopPlayer()
    {
        PlayerController.instance.isStopped = true;
        PlayerController.instance.moveSpeed = slowDownSpeed;
        yield return new WaitForSecondsRealtime(duration);        
        PlayerController.instance.isStopped = false;
        PlayerController.instance.moveSpeed = PlayerController.instance.normalSpeed;
    }

    IEnumerator HidePlayer()
    {
        PlayerController.instance.isHiding = true;

        yield return new WaitForSecondsRealtime(duration);

        PlayerController.instance.isHiding = false;

    }
}
