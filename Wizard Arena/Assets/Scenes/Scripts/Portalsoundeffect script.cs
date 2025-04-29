using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portalsoundeffectscript : MonoBehaviour
{
    public AudioClip portalSound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {

        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {

            audioSource = gameObject.AddComponent<AudioSource>();

        }
        audioSource.clip = portalSound;
        audioSource.playOnAwake = false;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            if (!audioSource.isPlaying)
            {


                audioSource.Play();

            }


        }

    }
}
