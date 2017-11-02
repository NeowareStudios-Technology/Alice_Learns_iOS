
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gotomenu : MonoBehaviour {

    public void NextScene()
    {
        
        SceneManager.LoadScene("Library");
    }
    private void OnMouseUp()
    {
        SceneManager.LoadScene("Library");
    }
}
