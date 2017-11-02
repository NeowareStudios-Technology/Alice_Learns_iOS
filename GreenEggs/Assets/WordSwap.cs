using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordSwap : MonoBehaviour {
    // public string first, second, third, fourth, fifth, sixth, seventh, eigth, ninth, tenth;
    public GameObject First, Second, Third, Fourth, Fifth, Sixth, Seventh, Eighth, Ninth, Tenth;
    int currenttext = 1;
    string currentline;
    // Use this for initialization
    void Start () {
		
	}
   public  void nextline()
    {
        currenttext++;
    }

    public void prevline()
    {
        currenttext--;
    }
    // Update is called once per frame
    void Update () {
		if (currenttext == 1)
        {
            currentline = First.GetComponent<Text>().text;
            GameObject.Find("Placeholder").GetComponent<Text>().text = currentline;
        }
        if (currenttext == 2)
        {
            currentline = Second.GetComponent<Text>().text;
            GameObject.Find("Placeholder").GetComponent<Text>().text = currentline;
        }
        if (currenttext == 3)
        {
            currentline = Third.GetComponent<Text>().text;
            GameObject.Find("Placeholder").GetComponent<Text>().text = currentline;
        }
        if (currenttext == 4)
        {
            currentline = Fourth.GetComponent<Text>().text;
            GameObject.Find("Placeholder").GetComponent<Text>().text = currentline;
        }
        if (currenttext == 5)
        {
            currentline = Fifth.GetComponent<Text>().text;
            GameObject.Find("Placeholder").GetComponent<Text>().text = currentline;
        }
        if (currenttext == 6)
        {
            currentline = Sixth.GetComponent<Text>().text;
            GameObject.Find("Placeholder").GetComponent<Text>().text = currentline;
        }
        if (currenttext == 7)
        {
            currentline = Seventh.GetComponent<Text>().text;
            GameObject.Find("Placeholder").GetComponent<Text>().text = currentline;
        }
        if (currenttext == 8)
        {
            currentline = Eighth.GetComponent<Text>().text;
            GameObject.Find("Placeholder").GetComponent<Text>().text = currentline;
        }
        if (currenttext == 9)
        {
            currentline = Ninth.GetComponent<Text>().text;
            GameObject.Find("Placeholder").GetComponent<Text>().text = currentline;
        }
        if (currenttext == 10)
        {
            currentline = Tenth.GetComponent<Text>().text;
            GameObject.Find("Placeholder").GetComponent<Text>().text = currentline;
        }
    }
}
