using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSkateboard : MonoBehaviour
{
    public float duration;
    public float slowDownSpeed = 9f;
    public bool allowPickupOnSkateboard = true;
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
        if (other.CompareTag("Player"))
        {
            if (allowPickupOnSkateboard || !PlayerController.instance.isOnSkateboard)
            {
                if (GameManager.instance.previousObstacle != null)
                {
                    StopCoroutine(GameManager.instance.previousObstacle.StopPlayer());
                }
                GameManager.instance.previousObstacle = this;
                StartCoroutine(StopPlayer());
                if (hidePlayer)
                {
                    StartCoroutine(HidePlayer());
                }
            }
        }
    }

    IEnumerator StopPlayer()
    {
        PlayerController.instance.moveSpeed = slowDownSpeed;
        PlayerController.instance.isOnSkateboard = true;        
        yield return new WaitForSecondsRealtime(duration);
        PlayerController.instance.moveSpeed = PlayerController.instance.normalSpeed;
        PlayerController.instance.isOnSkateboard = false;
    }

    IEnumerator HidePlayer()
    {
        PlayerController.instance.isHiding = true;

        yield return new WaitForSecondsRealtime(duration);

        PlayerController.instance.isHiding = false;

    }
}
