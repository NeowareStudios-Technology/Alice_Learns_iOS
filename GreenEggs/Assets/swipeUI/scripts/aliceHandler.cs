using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aliceHandler : MonoBehaviour {
	public GameObject laugh;
	public GameObject fly;
	public GameObject celebration;
	public GameObject wave;

	// Use this for initialization
	void Start () {
		wave.transform.position = new Vector3 (0f, 0f, 0f);
		laugh.transform.position = new Vector3 (150f, -150f, 0f);
		fly.transform.position = new Vector3 (150f, -150f, 0f);
		celebration.transform.position = new Vector3 (150f, 150f, 0f);
	}
		

	public void switchAlice(string word){
		
	if (word == "Laugh") {
			laugh.transform.position = new Vector3 (0f, 0f, 0f);

			fly.transform.position = new Vector3 (150f, -150f, 0f);
			wave.transform.position = new Vector3 (150f, -150f, 0f);
			celebration.transform.position = new Vector3 (150f, -150f, 0f);

		} else if (word == "Fly") {			
			fly.transform.position = new Vector3 (0f, 0f, 0f);

			laugh.transform.position = new Vector3 (150f, -150f, 0f);
			wave.transform.position = new Vector3 (150f, -150f, 0f);
			celebration.transform.position = new Vector3 (150f, 150f, 0f);
		} else if (word == "Hello") {		
			wave.transform.position = new Vector3 (0f, 0f, 0f);

			laugh.transform.position = new Vector3 (150f, -150f, 0f);
			fly.transform.position = new Vector3 (150f, -150f, 0f);
			celebration.transform.position = new Vector3 (150f, 150f, 0f);

		} 
		else
			print ("No animation found");
	}

	public void aliceCelebrate (){
		celebration.transform.position = new Vector3 (0f, 0f, 0f);
		laugh.transform.position = new Vector3 (150f, -150f, 0f);
		fly.transform.position = new Vector3 (150f, -150f, 0f);
	}
		
}
