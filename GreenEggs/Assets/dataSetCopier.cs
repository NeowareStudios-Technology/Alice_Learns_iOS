//DataSetLoader
//Developed by Alessandro Mondaini, Red Frog Digital Limited, Manchester, United Kingdom
//Free to use, improve and distribute but NOT reselling.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class dataSetCopier : MonoBehaviour 
{
	public string nextScene = "";
	WWW xmlPosition;
	WWW datPosition;
	string SetXml; 
	string SetDat; 
	string filePath;
	bool isRunning = false;
	public bool isEditor;
	public string localPath = "";
	
	[System.Serializable]
	public enum options {Local, SDCard};
	public options dataLocation;
	string shortName;
	public List<string> dataSetName;
	string DataSetFolderLocation;
	public bool runOnce = false;
	string dataSetsUID = "";

	void Awake(){
		DataSetFolderLocation = Application.streamingAssetsPath+"/QCAR/";

		if(dataLocation==options.Local)
			isEditor=true;
		else
			isEditor=false;


		if (PlayerPrefs.HasKey ("dataSetsPresent")) {
			bool refresh = false;

			if (!runOnce) {
				Debug.Log ("Run once not selected. Refresh needed.");
				refresh = true;
			}
			else {
				DateTime latestCreationTime = DateTime.MinValue;
				for (int i = 0; i < dataSetName.Count; i++) {
					string sourceFile = DataSetFolderLocation+dataSetName[i]+".xml";

					bool exists = File.Exists (sourceFile);
					if (!exists) {
						Debug.Log ("Source file " + sourceFile + " doesn't exist. Refresh needed.");
						refresh = true;
						break;
					} else {
						dataSetsUID += dataSetName[i];

						DateTime creationTime = File.GetCreationTime (sourceFile);
						if (creationTime > latestCreationTime) {
							latestCreationTime = creationTime;
						}
					}
				}

				if (!refresh) {
					dataSetsUID += "_" + latestCreationTime;
					Debug.Log ("New dataset UID: " + dataSetsUID + ", old dataset UID: " + PlayerPrefs.GetString ("dataSetsPresent"));
					if (PlayerPrefs.GetString ("dataSetsPresent") != dataSetsUID) {
						Debug.Log ("New dataset UID is different from old dataset UID. Refresh needed.");
						refresh = true;
					}
				}
			}

			if (refresh) {
				Debug.Log ("Removing dataSetsPresent key");
				PlayerPrefs.DeleteKey ("dataSetsPresent");
			}
		}
	}

	void Start(){
		Debug.Log ("Dataset copying scene launched");
		#if UNITY_ANDROID
		Debug.Log ("Dataset copying scene: found Android Run-time");
		if(!PlayerPrefs.HasKey("dataSetsPresent")){
			if(!isRunning) {
				Debug.Log ("Dataset not present, starting dataset copying routine");
				StartCoroutine (copyDataSet());
			}

		}
		else {
			goToNextScene();
		}
		#endif

		#if UNITY_IPHONE
		Debug.Log ("Dataset copying scene: found iOS Run-time");
		goToNextScene();
		#endif
	}

	IEnumerator copyDataSet(){
		isRunning=true;

		for(int i = 0; i < dataSetName.Count;i++){
			if(isEditor)
				SetDat = "File:///"+DataSetFolderLocation+dataSetName[i]+".dat";
			else
				SetDat = DataSetFolderLocation+dataSetName[i]+".dat";

			datPosition = new WWW(SetDat);
			yield return datPosition;
			
			if(isEditor)
				File.WriteAllBytes(localPath+dataSetName[i]+".dat", datPosition.bytes );
			else {
				Debug.Log("Copying data set from " + SetDat + " to " + Application.persistentDataPath+"/"+dataSetName[i]+".dat");
				File.WriteAllBytes(Application.persistentDataPath+"/"+dataSetName[i]+".dat", datPosition.bytes );
			}
		}

		yield return new WaitForEndOfFrame();

		for(int i = 0; i < dataSetName.Count; i++){
			if(isEditor)
				SetXml = "File:///"+DataSetFolderLocation+dataSetName[i]+".xml";
			else
				SetXml = DataSetFolderLocation+dataSetName[i]+".xml";

			xmlPosition = new WWW(SetXml);
			yield return xmlPosition;
			
			if(isEditor)
				File.WriteAllBytes(localPath+dataSetName[i]+".xml", xmlPosition.bytes );
			else
				File.WriteAllBytes(Application.persistentDataPath+"/"+dataSetName[i]+".xml", xmlPosition.bytes );
		}

		yield return new WaitForEndOfFrame();

		PlayerPrefs.SetString("dataSetsPresent", dataSetsUID);

		if(!isEditor){
			Debug.Log("DataSet succesfully copied to SD Card");
			goToNextScene();
		} else {
			Debug.Log("DataSet succesfully copied to Local Folder");
			goToNextScene();
		}
	}

	void goToNextScene() {
		if(!string.IsNullOrEmpty(nextScene))
			Application.LoadLevel(nextScene);
		else
			Application.LoadLevel(1);
	}
}