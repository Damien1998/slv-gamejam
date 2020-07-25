using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackGenerator : MonoBehaviour
{
    public Transform placeToGenerate;
    public GameObject currentTrack;

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
            int trackID = Random.Range(0, GameManager.instance.tracks.Length);
            GameManager.instance.currentTrackID = trackID;

            GameObject newTrack = Instantiate(GameManager.instance.tracks[trackID], placeToGenerate.position, placeToGenerate.rotation);
            newTrack.GetComponentInChildren<TrackRemover>().previousTrack = currentTrack;
        }
    }
}
