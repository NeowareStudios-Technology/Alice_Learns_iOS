
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoTrobo: MonoBehaviour
{

    public void NextScene()
    {

        SceneManager.LoadScene("TroboBook");
    }
    private void OnMouseUp()
    {
        SceneManager.LoadScene("TroboBook");
    }
}