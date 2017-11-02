using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BookLoad: MonoBehaviour {
    public float progress = 0;
    public static bool bookselected = false;
	// Use this for initialization
	void Start () {
        StartCoroutine(LoadYourAsyncScene());
    }
    

        IEnumerator LoadYourAsyncScene()
        {
       
            // The Application loads the Scene in the background at the same time as the current Scene.
            //This is particularly good for creating loading screens. You could also load the scene by build //number.
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("book");
        
            //Wait until the last operation fully loads to return anything
            while (!asyncLoad.isDone && bookselected == false)
            {
                yield return null;
            }  
    }
	// Update is called once per frame
	void Update () {
		
	}
}
