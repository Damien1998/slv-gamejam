using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBush : MonoBehaviour
{
    public float duration;
    public float slowDownSpeed = 0f;
    public bool allowPickupOnSkateboard = false;
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
        if(other.CompareTag("Player"))
        {
            if (allowPickupOnSkateboard || !PlayerController.instance.isOnSkateboard)
            {               
                StartCoroutine(StopPlayer());
                if(hidePlayer)
                {
                    StartCoroutine(HidePlayer());
                }
            }          
        }
    }

    IEnumerator StopPlayer()
    {
        PlayerController.instance.isStopped = true;
        PlayerController.instance.isOnSkateboard = false;
        PlayerController.instance.moveSpeed = slowDownSpeed;
        yield return new WaitForSecondsRealtime(duration);        
        PlayerController.instance.isStopped = false;
        PlayerController.instance.moveSpeed = PlayerController.instance.normalSpeed;
    }

    IEnumerator HidePlayer()
    {
        
        PlayerController.instance.isHiding = true;
        /**
        PlayerController.instance.transform.position = new Vector3(transform.position.x, PlayerController.instance.transform.position.y, PlayerController.instance.transform.position.z);

        Camera mainCamera = FindObjectOfType<Camera>();
        CameraAnchor anchor = FindObjectOfType<CameraAnchor>();

        float aspectRatio = Mathf.Round(Screen.height) / Mathf.Round(Screen.width);
        float distanceFromPlayer = (mainCamera.orthographicSize / (aspectRatio * 2));

        anchor.transform.position = new Vector3(transform.position.x + distanceFromPlayer, anchor.transform.position.y, anchor.transform.position.z);
        mainCamera.transform.position = new Vector3(transform.position.x + distanceFromPlayer, mainCamera.transform.position.y, mainCamera.transform.position.z);
        **/
        yield return new WaitForSecondsRealtime(duration);

        PlayerController.instance.isHiding = false;

    }
}
