using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public int currentHealth;
    public int maxHealth;
    public Texture2D healthImg;
    public float hbLength;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
        hbLength = Screen.width / 6;
        ChangeHealth(0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(10, Screen.height - 50, 30, 30), healthImg);
        GUI.color = Color.yellow;
        GUI.Box(new Rect(50, Screen.height - 47.5f, hbLength - 200, 25), currentHealth + " / " + maxHealth);
       
    }
    
    public void ChangeHealth(int health)
    {
        currentHealth += health;

        hbLength = (Screen.width / 2) + (currentHealth / (float)maxHealth);
    }
}
