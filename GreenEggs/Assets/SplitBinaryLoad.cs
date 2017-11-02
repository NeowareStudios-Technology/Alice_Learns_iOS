using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class FirstScene : MonoBehaviour {

	public Text infoText;
	public GameObject spinnerImage;

	// the files we need to copy from obb to users storage
	private string[] paths={   
		"TROBO.mp4",
		"alicelilb.mp4",
		"alicelila.mp4",
		"aliceCapB.mp4",
		"alicecapA.mp4",
		"HelloSticker.mp4"
	};

	// will track as files are copied
	private int totalFilesCopied;

	void Awake() {

		// presume no files copied yet
		totalFilesCopied = 0;

		#if UNITY_IPHONE

		// if ios just jump straight to menu
		Application.LoadLevel("Menu");

		#endif

		#if UNITY_ANDROID 

		// we gotta process files from obb to storage on users device...
		CheckForFiles();

		#endif
	}

	void Start() {

		spinnerImage.SetActive(true);

		infoText.text = "Copying data please wait";
	}

	private void CheckForFiles() {

		// presume non copied yet
		int fileCount = 0;

		// cycle the list of required files
		for (int i=0; i<paths.Length; ++i) {

			// if the file exists
			if (File.Exists (Application.persistentDataPath  + "/" +  paths [i])) {

				// increment counter
				fileCount++;
			}
		}

		// if they don't match
		if (fileCount < paths.Length) {

			// copy all again, lazy but hey ho belt n braces
			StartCoroutine (CopyFiles ());
		} 
		else {

			// if they match we can load menu
			Application.LoadLevel ("Menu");
		}
	}

	public IEnumerator CopyFiles() {

		// cycle the required files
		for(int i = 0; i < paths.Length; ++i) {

			// and copy file
			yield return StartCoroutine(PullStreamingAssetFromObb(paths[i], i));
		}

		yield return new WaitForSeconds(1f); 
	}

	public IEnumerator PullStreamingAssetFromObb(string sapath, int index) { 

		// get the file out of obb
		WWW unpackerWWW = new WWW(Application.streamingAssetsPath + "/" + sapath);

		// wait until done
		while (!unpackerWWW.isDone) {

			yield return null;
		}

		// if there is an error here, lets be lazy and ignore...
		if (!string.IsNullOrEmpty(unpackerWWW.error)) {

			yield break; 
		} 
		else {

			// simples...create the destination directory if not already there
			if (!Directory.Exists(Path.GetDirectoryName(Application.persistentDataPath + "/" + sapath))) {

				Directory.CreateDirectory(Path.GetDirectoryName(Application.persistentDataPath + "/" + sapath));
			}

			// write the file to destination
			File.WriteAllBytes(Application.persistentDataPath + "/" + sapath, unpackerWWW.bytes);

			// increment how many files copied so far
			totalFilesCopied++;

			// have we copied all the files
			if (totalFilesCopied == paths.Length) {

				// yep, so load menu
				Application.LoadLevel("Menu");
			}

			if (index == paths.Length-1 && totalFilesCopied < paths.Length) {

				spinnerImage.SetActive(false);

				infoText.text = "Copy failed, please check free space";
			}
		}

		yield return 0;
	}
}