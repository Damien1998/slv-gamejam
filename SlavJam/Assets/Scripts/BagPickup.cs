using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagPickup : MonoBehaviour
{
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
        if (other.CompareTag("Player") && !PlayerController.instance.hasBag)
        {
            audioSource.Play();
            PlayerController.instance.hasBag = true;
            spriteRenderer.color = new Color(1, 1, 1, 0);
            //Destroy(gameObject);
        }
    }
}
