using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenZone : MonoBehaviour
{
    public float scorePerFrame;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("uidsgsdhfs");
            GameManager.instance.tempScore += scorePerFrame;
        }
    }
}
