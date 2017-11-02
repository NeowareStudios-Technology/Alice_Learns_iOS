using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundplay : MonoBehaviour {
    public double timer = 0;
    public double timerMax = .05;
    public bool stopped = false;
    public GameObject coach;
    public AudioClip otherClip;
    // Use this for initialization
    void Start () {
       
     
    }

    // Update is called once per frame
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timerMax && stopped == false)
        {
            AudioSource audio = GetComponent<AudioSource>();
            print("hi");
            stopped = true;
            audio.Play();
        }
    }
    
}
