using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float fastSpeed, slowSpeed, normalSpeed;
    private Rigidbody rigidBody;

    private float moveSpeed;

    public static PlayerController instance;

    // Start is called before the first frame update
    void Start()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        rigidBody = GetComponent<Rigidbody>();
        moveSpeed = normalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("SlowDown") && !Input.GetButton("SpeedUp"))
        {
            moveSpeed = Mathf.Lerp(moveSpeed, slowSpeed, 0.4f);
        }
        else if(!Input.GetButton("SpeedUp"))
        {
            moveSpeed = Mathf.Lerp(moveSpeed, normalSpeed, 0.6f);
        }

        if (Input.GetButton("SpeedUp") && !Input.GetButton("SlowDown"))
        {
            moveSpeed = Mathf.Lerp(moveSpeed, fastSpeed, 0.4f);
        }
        else if (!Input.GetButton("SlowDown"))
        {
            moveSpeed = Mathf.Lerp(moveSpeed, normalSpeed, 0.6f);
        }

        rigidBody.velocity = new Vector3(moveSpeed, 0, 0);

        if (Input.GetKeyDown("w") && transform.position.z < 1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z + 1);
        }

        if (Input.GetKeyDown("s") && transform.position.z > -1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z - 1);
        }
    }
}
