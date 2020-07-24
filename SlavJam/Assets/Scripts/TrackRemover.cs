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
        }
    }
}
