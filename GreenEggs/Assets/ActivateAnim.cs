using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAnim : MonoBehaviour {
    public bool Tracked = false;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Tracked == true)
        {
            print("wetracked");
            this.gameObject.SetActive(true);
        
        }
        if (Tracked == false)
        {
            this.gameObject.SetActive(false);
        }
	}
}
