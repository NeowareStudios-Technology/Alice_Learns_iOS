// Mutes-Unmutes the sound from this object each time the user presses space.
using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }
    private void OnMouseDown()
    {
        audioSource.mute = !audioSource.mute;
    }
    void Update()
    {

    }
}