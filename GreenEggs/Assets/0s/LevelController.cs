
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
 
public class LevelController : MonoBehaviour
{

    AsyncOperation asyncOps;
    public Image AliceLoading;

    public float FadeRate;
    private Image image;
    private float targetAlpha;

    bool readyToDestroy = false;

    public void NextScene()
    {
        SceneManager.LoadScene("book");
    }

    public void NextSceneAsync()
    {
        FadeIn();
        StartCoroutine(LoadYourAsyncScene());
    }

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this.transform.parent.gameObject);
        this.image = AliceLoading;
        this.targetAlpha = this.image.color.a;
    }

    // Update is called once per frame
    void Update()
    {

        Color curColor = this.image.color;
        float alphaDiff = Mathf.Abs(curColor.a - this.targetAlpha);
        if (alphaDiff > 0.0001f)
        {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, this.FadeRate * Time.deltaTime);
            this.image.color = curColor;
        }
        else if (readyToDestroy)
        {
            Destroy(this.transform.parent.gameObject, 5f);
        }
    }

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background at the same time as the current Scene.
        //This is particularly good for creating loading screens. You could also load the scene by build //number.
        

        yield return new WaitForSeconds(3);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("book");

        //Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            
            yield return null;
        }

        FadeOut();

    }

    public void FadeOut()
    {
        this.targetAlpha = 0.0f;
        readyToDestroy = true;
    }

    public void FadeIn()
    {
        this.targetAlpha = 1.0f;
    }
}

