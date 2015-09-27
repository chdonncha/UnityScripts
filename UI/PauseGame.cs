using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

    public GameObject mainMenu;
    private bool isActive;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        bringUpMenu();
	}

    public void bringUpMenu()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isActive = !isActive;

            if (isActive)
            {
                mainMenu.gameObject.SetActive(true);
                //Cursor.lockState(false);  
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

            else
            {
                mainMenu.gameObject.SetActive(false);
              //  Screen.lockCursor = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
           } 
          

           /* if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }*/
        }
    }
}
