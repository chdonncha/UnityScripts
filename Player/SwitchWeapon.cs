using UnityEngine;
using System.Collections;

public class SwitchWeapon : MonoBehaviour
{

    public int currentWeapon;
	public int gunNumber;
    public Transform[] weapons;
    public Texture2D AmmoImage;
    public Texture2D gunSelectImg; // add a incrementing / de-incrementing integer to allow switiching of textures 
    public Shooter CurrentWeapon { get; set; }

    private Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        ChangeWeapon(currentWeapon);
    }

    public void ChangeWeapon(int num)
    {
        if (CurrentWeapon != null)
        {
            // Unsubscribe to event if the gun is not null
            CurrentWeapon.OnGunShoot -= GunShotEvent;
        }
        weapons[currentWeapon].gameObject.SetActive(false);
        currentWeapon = num;
        weapons[currentWeapon].gameObject.SetActive(true);
        CurrentWeapon = weapons[currentWeapon].GetComponent<Shooter>();
        // Subscribe to the current weapons shoot event
        CurrentWeapon.OnGunShoot += GunShotEvent;
    }

    private void GunShotEvent()
    {
        animator.SetTrigger(CurrentWeapon.animShootID);
    }

    void Update()
    {
        //Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
        // Debug.Log(currentWeapon);

        if (Input.GetKeyDown("1"))
        {
            ChangeWeapon(0);
			gunNumber = 0;
        }

        if (Input.GetKeyDown("2"))
        {
            ChangeWeapon(1);
			gunNumber = 1;
        }

        if (Input.GetKeyDown("3"))
        {
            ChangeWeapon(2);
			gunNumber = 2;
        }

        if (Input.GetKeyDown("4"))
        {
            ChangeWeapon(3);
			gunNumber = 3;
        }

        if (Input.GetKeyDown("5"))
        {
            ChangeWeapon(4);
			gunNumber = 4;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            ChangeWeapon(0);
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            ChangeWeapon(1);
        }

    }

    private void OnGUI()
    {
        if (CurrentWeapon != null)
        {
            GUI.DrawTexture(new Rect(100, Screen.height - 450, 500, 50), gunSelectImg //+ the img number using a toString to represent it as a string have it fade after a few seconds);
            GUI.DrawTexture(new Rect(Screen.width - 200, Screen.height - 50, 30, 30), AmmoImage);
            GUI.color = Color.yellow;
            GUI.Box(new Rect(Screen.width - 150, Screen.height - 47.5f, 100, 25), CurrentWeapon.CurrentAmmo + " / " + CurrentWeapon.Clips);
        }
    }
}
