using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackGenerator : MonoBehaviour
{
    public Transform placeToGenerate;
    public GameObject trackPrefab, currentTrack;

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
            GameObject newTrack = Instantiate(trackPrefab, placeToGenerate.position, placeToGenerate.rotation);
            newTrack.GetComponentInChildren<TrackRemover>().previousTrack = currentTrack;
        }
    }
}
