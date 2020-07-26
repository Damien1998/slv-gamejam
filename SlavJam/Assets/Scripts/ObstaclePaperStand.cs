using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePaperStand : MonoBehaviour
{
    public float duration;
    public float enemySpeed;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if(audioSource != null)
            {
                audioSource.Play();
            }
            StartCoroutine(StopEnemy());
        }
    }

    IEnumerator StopEnemy()
    {
        EnemyController.instance.moveSpeed = enemySpeed;
        yield return new WaitForSecondsRealtime(duration);
        EnemyController.instance.moveSpeed = EnemyController.instance.normalSpeed;
    }
}
