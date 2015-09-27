using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
      //  Quit();
	}

    public void LoadLevel(string level)
    {
       // level = "Tutorial";
        Application.LoadLevel(level);
    }

    public void Quit(bool quitGame)
    {
        if (!quitGame)
        {
            Application.Quit();
            //Debug.Log("quit");
        }
    }
}
