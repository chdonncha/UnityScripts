using UnityEngine;
using System.Collections;

public class GernadeThrow : MonoBehaviour
{

    public Rigidbody bullet;
    public Transform gunPoint;
    public AudioClip shootSound;
    public AudioSource _audio;
    public float shotThrust;
    public float moveSpeed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateInputs();

        if (Input.GetKeyDown("g"))
        {
            HandleObjectShoot();
        }
    }

    private void UpdateInputs()
    {
        float h = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float v = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
    }

    public void HandleObjectShoot()
    {
        Rigidbody bulletShot = (Rigidbody)Instantiate(bullet, gunPoint.position, transform.rotation);
        bulletShot.velocity = gunPoint.forward * shotThrust;
    }
}
