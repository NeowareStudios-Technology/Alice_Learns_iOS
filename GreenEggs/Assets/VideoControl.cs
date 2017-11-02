using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine;

public class VideoControl : MonoBehaviour {
    
    public GameObject vid;
    public VideoPlayer video;
    public GameObject Alicetext;
	// Use this for initialization
	void Start () {
        video = this.gameObject.GetComponent<VideoPlayer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!video.isPlaying)
        {
            this.gameObject.SetActive(false);
            Alicetext.SetActive(true);
        }

    }
}
