﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePaperStand : MonoBehaviour
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
        if (other.CompareTag("Enemy"))
        {
            StartCoroutine(StopEnemy());
        }
    }

    IEnumerator StopEnemy()
    {
        EnemyController.instance.isStopped = true;
        yield return new WaitForSecondsRealtime(duration);
        EnemyController.instance.isStopped = false;
    }
}
