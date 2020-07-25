using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBush : MonoBehaviour
{
    public float duration;

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
            StartCoroutine(StopPlayer());
        }
    }

    IEnumerator StopPlayer()
    {
        PlayerController.instance.isStopped = true;
        yield return new WaitForSecondsRealtime(duration);
        PlayerController.instance.isStopped = false;
    }
}
