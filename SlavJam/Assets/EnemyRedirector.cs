using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRedirector : MonoBehaviour
{
    public int direction;

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
            other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y + direction, other.transform.position.z + direction);
            other.GetComponent<SpriteRenderer>().sortingOrder -= direction;
        }
    }
}
