using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        Destroy(this.gameObject, 2.7f);

        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
}
