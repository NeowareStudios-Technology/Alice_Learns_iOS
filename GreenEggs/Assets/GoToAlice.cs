
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToAlice: MonoBehaviour
{

    public void NextScene()
    {

        SceneManager.LoadScene("AliceAssetsSpeech/speech");
    }
}
