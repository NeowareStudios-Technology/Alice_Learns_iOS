using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class DatasetHandler : MonoBehaviour {



	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.A))
			ActivateDataset ();

	}

	void ActivateDataset () {

		ObjectTracker objectTracker = TrackerManager.Instance.GetTracker<ObjectTracker> ();
		IEnumerable<DataSet> datasets = objectTracker.GetDataSets ();


		foreach (DataSet ds in datasets) {

			Debug.Log(ds.ToString ());

		}

	}
}
