using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float fastSpeed, slowSpeed, normalSpeed;
    public float trackSwitchTime;
    private Rigidbody rigidBody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public float moveSpeed;
    public float runAlertRate;
    public bool isRunning;
    public bool isOnSkateboard, hasBag;

    public bool isStopped, isHiding;

    public static PlayerController instance;

    public bool canMoveForward;

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
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        moveSpeed = normalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStopped && !isOnSkateboard)
        {
            if (Input.GetButton("SlowDown") && !Input.GetButton("SpeedUp"))
            {
                moveSpeed = Mathf.Lerp(moveSpeed, slowSpeed, 0.4f);
            }
            else if (!Input.GetButton("SpeedUp"))
            {
                moveSpeed = Mathf.Lerp(moveSpeed, normalSpeed, 0.6f);
            }

            if (Input.GetButton("SpeedUp") && !Input.GetButton("SlowDown") && canMoveForward)
            {
                moveSpeed = Mathf.Lerp(moveSpeed, fastSpeed, 0.4f);
                GameManager.instance.alertMeter += runAlertRate * Time.deltaTime;
                isRunning = true;
            }
            else if (!Input.GetButton("SlowDown"))
            {
                moveSpeed = Mathf.Lerp(moveSpeed, normalSpeed, 0.6f);
                isRunning = false;
            }

            rigidBody.velocity = new Vector3(moveSpeed * GameManager.instance.speedModifier, 0, 0);

            if (Input.GetKeyDown("w") && transform.position.z < 1)
            {
                StartCoroutine(SwitchTrack(1));
            }

            if (Input.GetKeyDown("s") && transform.position.z > -1)
            {
                StartCoroutine(SwitchTrack(-1));
            }
        }
        else if (isOnSkateboard)
        {
            rigidBody.velocity = new Vector3(moveSpeed * GameManager.instance.speedModifier, 0, 0);

            if (Input.GetKeyDown("w") && transform.position.z < 1)
            {
                StartCoroutine(SwitchTrack(1));
            }

            if (Input.GetKeyDown("s") && transform.position.z > -1)
            {
                StartCoroutine(SwitchTrack(-1));
            }
        }
        else
        {
            rigidBody.velocity = new Vector3(moveSpeed * GameManager.instance.speedModifier, 0, 0);
        }

        if (!isOnSkateboard && isHiding)
        {
            animator.SetBool("isHiding", true);
        }
        else
        {
            animator.SetBool("isHiding", false);
        }

        if(hasBag)
        {
            animator.SetBool("hasBag", true);
        }
        else
        {
            animator.SetBool("hasBag", false);
        }
    }

    IEnumerator SwitchTrack(int direction)
    {       
        yield return new WaitForSecondsRealtime(trackSwitchTime);

        transform.position = new Vector3(transform.position.x, transform.position.y + direction, transform.position.z + direction);
        spriteRenderer.sortingOrder -= direction * 2;
    }
}
