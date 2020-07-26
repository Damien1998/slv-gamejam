using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenZone : MonoBehaviour
{
    public float scorePerSecond;
    public float scoreDecay;
    private bool playerInRange;

    public AudioSource staticSource;
    public AudioSource gibberishSource;
    private bool waitingForGibberish;
    public float delayMin, delayMax;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange)
        {
            if(!staticSource.isPlaying)
            {
                staticSource.Play();
            }
            if(!waitingForGibberish && !gibberishSource.isPlaying)
            {
                StartCoroutine(WaitRandom());
            }

            GameManager.instance.tempScore += scorePerSecond * Time.deltaTime * GameManager.instance.speedModifier;
            if (GameManager.instance.dangerMeter > 0)
            {
                GameManager.instance.dangerMeter -= 5 * Time.deltaTime;
            }
            else
            {
                GameManager.instance.dangerMeter = 0;
            }
        }
        else
        {
            if (staticSource.isPlaying)
            {
                staticSource.Stop();
                StopCoroutine(WaitRandom());
                gibberishSource.Stop();
            }

            if (GameManager.instance.tempScore > 0)
            {
                GameManager.instance.tempScore -= scoreDecay * Time.deltaTime * GameManager.instance.speedModifier;
            }
            GameManager.instance.dangerMeter += Time.deltaTime;
        }
    }

    IEnumerator WaitRandom()
    {
        waitingForGibberish = true;
        float time = Random.Range(delayMin, delayMax);

        yield return new WaitForSecondsRealtime(time);

        waitingForGibberish = false;

        int gbID = Random.Range(0, GameManager.instance.gibberish.Length);
        gibberishSource.clip = GameManager.instance.gibberish[gbID];
        gibberishSource.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
