using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackRemover : MonoBehaviour
{
    public GameObject previousTrack, currentTrack;

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
        if (other.CompareTag("Player") && previousTrack != null)
        {
            Destroy(previousTrack);
            float distance = -currentTrack.transform.position.x;
            currentTrack.transform.position = new Vector3(0, currentTrack.transform.position.y, currentTrack.transform.position.z);
            PlayerController.instance.transform.position = new Vector3(PlayerController.instance.transform.position.x + distance, PlayerController.instance.transform.position.y, PlayerController.instance.transform.position.z);

            /**
            CameraAnchor anchor = FindObjectOfType<CameraAnchor>();
            anchor.transform.position = new Vector3(anchor.transform.position.x + distance, anchor.transform.position.y, anchor.transform.position.z);
            **/

            EnemyController enemy = EnemyController.instance;
            enemy.transform.position = new Vector3(enemy.transform.position.x + distance, enemy.transform.position.y, enemy.transform.position.z);

            Camera mainCamera = FindObjectOfType<Camera>();
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x + distance, mainCamera.transform.position.y, mainCamera.transform.position.z);
        }
    }
}
