using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPickup : MonoBehaviour
{
    public float points;

    private AudioSource audioSource;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Play();
            GameManager.instance.tempScore += points;
            spriteRenderer.color = new Color(1, 1, 1, 0);
            //Destroy(gameObject);
        }
    }
}
