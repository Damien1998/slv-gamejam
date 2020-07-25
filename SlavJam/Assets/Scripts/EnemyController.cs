using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float fastSpeed, slowSpeed, moveSpeed, normalSpeed;
    private Rigidbody rigidBody;

    private float distance;

    public bool isStopped;

    public static EnemyController instance;

    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        rigidBody = GetComponent<Rigidbody>();
        moveSpeed = normalSpeed;

        float aspectRatio = Mathf.Round(Screen.height) / Mathf.Round(Screen.width);
        distance = (mainCamera.orthographicSize / (aspectRatio * 2f));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!isStopped)
        {
            rigidBody.velocity = new Vector3(moveSpeed * GameManager.instance.speedModifier, 0, 0);
        }
        else
        {
            rigidBody.velocity = Vector3.zero;
        }
        
        //mainCamera.transform.position = new Vector3(transform.position.x - distance, mainCamera.transform.position.y, mainCamera.transform.position.z);
    }
}
