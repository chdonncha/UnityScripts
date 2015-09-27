using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{

    public Rigidbody bullet;
    public Rigidbody ejectedBullet;
    public Transform gunPoint;
    public Transform ejectPoint;
    public GameObject[] bulletHoles;
    public GameObject muzzleFlashObj;
    public string animShootID;
    public bool bulletEject;
    public bool gunMuzzleFlash;
    public float Distance;
    public float shotThrust;
    public float moveSpeed;
    public float shootTimer;
    public float reloadTimer;
    public int maxAmmo;
    public int clips;
    //public int shotFragments;
    //public float spreadAngle;
    public bool shootsObjects;
    private float _emptyTimer = 0.5f;
    private float _shootCounter;
    private float _reloadCounter;
    private float _emptyCounter;
    private int _curAmmo;
    public AudioClip reloadSound;
    public AudioClip shootSound;
    public AudioClip emptySound;
    public AudioSource _audio;

    public event System.Action OnGunShoot;

    public int CurrentAmmo { get { return _curAmmo; } }
    public int MaxAmmo { get { return maxAmmo; } }
    public int Clips { get { return clips; } }

    void Start()
    {
        _shootCounter = shootTimer;
        _reloadCounter = reloadTimer;
        _curAmmo = maxAmmo;
        clips -= 1;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInputs();
        HandleShooting();
        Reload();
        EmptyMag();
    }

    private void UpdateInputs()
    {
        float h = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float v = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
    }

    private void HandleShooting()
    {

        RaycastHit hit;
        Ray shootRay = new Ray(gunPoint.position, gunPoint.forward);
        //Debug.DrawRay(gunPoint.position, gunPoint.forward * 50f, Color.red);

        _shootCounter -= Time.deltaTime;

        if (_shootCounter <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                _shootCounter = shootTimer;

                if (_curAmmo > 0)
                {
                    _audio.PlayOneShot(shootSound);

                    if (OnGunShoot != null)
                    {
                        OnGunShoot();
                    }

                    if (shootsObjects)
                    {
                        HandleObjectShoot();
                    }
                    else
                    {
                        if (bulletEject)
                        {
                            Rigidbody ejectedBulletShot = (Rigidbody)Instantiate(ejectedBullet, ejectPoint.position, transform.rotation);
                            ejectedBullet.velocity = ejectPoint.forward * shotThrust;
                        }

                        if(gunMuzzleFlash)
                        {
                            Quaternion spawnRotation = Quaternion.Euler(0, 0, 90);
                            Instantiate(muzzleFlashObj, gunPoint.position, spawnRotation);
                        }

                        if (Physics.Raycast(shootRay, out hit, 50f, 1 << LayerMask.NameToLayer("Map")))
                        {
                            Instantiate(bulletHoles[(Random.Range(0, 2))], hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));

                        }

                        if (Physics.Raycast(shootRay, out hit, 50f, 1 << LayerMask.NameToLayer("Objects")))
                        {
                            // Debug.Log(hit.collider.name);
                            Rigidbody r = hit.collider.gameObject.GetComponent<Rigidbody>();
                            if (r != null)
                            {
                                r.AddForce(transform.forward * shotThrust);
                                //Instantiate(bulletHole, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                            }
                        }

                        if (Physics.Raycast(shootRay, out hit, 50f, 1 << LayerMask.NameToLayer("Enemy")))
                        {
                            Rigidbody dead = hit.collider.gameObject.GetComponent<Rigidbody>();
                            if (dead != null)
                            {
                                Destroy(dead.transform.gameObject);
                            }
                        }
                    }
                    _curAmmo = _curAmmo - 1;
                }

            }
        }
    }

    public void Reload()
    {
        if (clips > 0)
        {
            _reloadCounter -= Time.deltaTime;
            if (_curAmmo == 0)
            {

                if (_reloadCounter <= 0)
                {
                    _audio.PlayOneShot(reloadSound);
                    _reloadCounter = reloadTimer;
                    _curAmmo = maxAmmo;
                    clips -= 1;
                }
            }
        }
    }

    public void EmptyMag()
    {
        if (Input.GetMouseButton(0))
        {
            if (clips == 0)
            {
                if (_curAmmo == 0)
                {
                    if (_emptyCounter <= 0)
                    {
                        _audio.PlayOneShot(emptySound);
                    }
                }
            }
        }
    }

    public void HandleObjectShoot()
    {
        Rigidbody bulletShot = (Rigidbody)Instantiate(bullet, gunPoint.position, transform.rotation);
        bulletShot.velocity = gunPoint.forward * shotThrust;
    }
}






