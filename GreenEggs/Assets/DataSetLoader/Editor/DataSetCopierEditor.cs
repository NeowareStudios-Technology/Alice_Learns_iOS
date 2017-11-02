//DataSetLoader
//Developed by Alessandro Mondaini, Red Frog Digital Limited, Manchester, United Kingdom
//Free to use, improve and distribute but NOT reselling.

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

[CustomEditor(typeof(dataSetCopier))]
public class dataSetCopierEditor : Editor {

	[System.Serializable]
	public enum options {Local, SDCard};
	public options dataLocation;
	int index = 0;
	dataSetCopier _target;
	private string entry;
	string shortName;
	bool isCalculated = false;

	void OnEnable(){
	
		_target = (dataSetCopier)target;

	}

	override public void OnInspectorGUI(){

		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();

		Texture2D cambrianNews =  AssetDatabase.LoadMainAssetAtPath("Assets/DataSetLoader/Logo/rflogo.png") as Texture2D;
		GUILayout.Label(cambrianNews,GUILayout.Height(200));

		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();

		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		GUI.color = Color.green;

		if(_target.dataSetName.Count==0){
			if(GUILayout.Button("Calculate DataSet",GUILayout.Width(120))){
				copyDataSet();
			}
		}

		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUI.color = Color.white;

		for(int i = 0; i<_target.dataSetName.Count;i++){
			EditorGUILayout.LabelField("DataSet: " + _target.dataSetName[i],EditorStyles.whiteLabel ) ;
		}

		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		GUI.color = Color.yellow;

		if(_target.dataSetName.Count!=0){
			if(GUILayout.Button("Reset DataSet",GUILayout.Width(120))){
				resetDataSet();
			}
		}
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();

		GUI.color = Color.white;

		if(_target.dataSetName.Count!=0){
			_target.nextScene =  EditorGUILayout.TextField ("Next Scene: ",_target.nextScene,EditorStyles.textField);

			_target.runOnce =  EditorGUILayout.Toggle ("Run Only Once: ",_target.runOnce,EditorStyles.radioButton);

			EditorGUILayout.HelpBox( "Enter the name of the next scene to load. If empty, the level with ID 1 will be loaded", MessageType.Info );

			GUI.color = Color.white;

			EditorGUILayout.LabelField ("DataSet Location:",EditorStyles.whiteLabel);

			if(_target.dataLocation==dataSetCopier.options.Local)
				GUI.color = Color.red;
			else
				GUI.color = Color.green;

			_target.dataLocation = (dataSetCopier.options) EditorGUILayout.EnumPopup ( _target.dataLocation);

			GUI.color = Color.white;

		if(_target.dataLocation==dataSetCopier.options.Local){
			EditorGUILayout.HelpBox( "WARNING! Remember to select SDCard before you build the app.", MessageType.Warning )
					;
			_target.localPath =  EditorGUILayout.TextField ("Local Path: ",_target.localPath);

			EditorGUILayout.HelpBox( "Enter the full path of a local folder to check if the script is working right.", MessageType.Info );
		  }
		}

		if (GUI.changed) EditorUtility.SetDirty(_target);

	}

	void copyDataSet()
	{

		DirectoryInfo dirD = new DirectoryInfo(Application.streamingAssetsPath+"/QCAR/");

		FileInfo[] infoD = dirD.GetFiles("*xml*");
		
		foreach (FileInfo d in infoD) {
			string fullName = d.Name;
			shortName = fullName.Replace(".xml","");
			
			if(!shortName.Contains("meta")){
		
				_target.dataSetName.Add(shortName);

			}

		}

		isCalculated=true;
	}

	void resetDataSet(){
		_target.dataSetName.Clear();
		isCalculated=false;
	}
}
