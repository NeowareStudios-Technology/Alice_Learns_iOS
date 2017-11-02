
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoMain : MonoBehaviour {

    public void NextScene()
    {

        SceneManager.LoadScene("Menu");
    }
}
