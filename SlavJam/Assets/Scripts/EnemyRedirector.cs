using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRedirector : MonoBehaviour
{
    public int direction;
    public float trackSwitchTime;

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
        if(other.CompareTag("Enemy"))
        {
            StartCoroutine(SwitchTrack(other.transform, direction));
        }
    }

    IEnumerator SwitchTrack(Transform enemy, int switchDirection)
    {
        yield return new WaitForSecondsRealtime(trackSwitchTime);

        enemy.position = new Vector3(enemy.position.x, enemy.position.y + switchDirection, enemy.position.z + switchDirection);
        enemy.GetComponent<SpriteRenderer>().sortingOrder -= switchDirection;
    }
}
