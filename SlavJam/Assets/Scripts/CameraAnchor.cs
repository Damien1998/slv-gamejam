using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnchor : MonoBehaviour
{
    public Camera mainCamera;

    public float distanceFromPlayer;

    // Start is called before the first frame update
    void Start()
    {
        float aspectRatio = Mathf.Round(Screen.height) / Mathf.Round(Screen.width);
        distanceFromPlayer = (mainCamera.orthographicSize / (aspectRatio * 2));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector2(PlayerController.instance.transform.position.x + distanceFromPlayer, transform.position.y);
        mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}
