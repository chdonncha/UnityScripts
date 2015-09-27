using UnityEngine;
using System.Collections;

public class GernadeExplode : MonoBehaviour
{

    public GameObject explosion; // drag your explosion prefab here
    public AudioClip sound;
    public AudioSource _audio;
    public float forceRadius;
    public float dammageRadius;
    public float power;
    public float timer;

    // Use this for initialization
    void Start()
    {
        Invoke("Explode", timer);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
    }

    private void Explode()
    {
        GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
        //gameObject.SetActive(false);
        _audio.PlayOneShot(sound);
        Destroy(gameObject); // destroy the grenade
        Destroy(expl, 3); // delete the explosion after 3 seconds

        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, forceRadius);

        foreach (var c in Physics.OverlapSphere(transform.position, dammageRadius))
        {

            Rigidbody rb = c.GetComponent<Rigidbody>();
            if (rb)
            {
                rb.AddExplosionForce(power, explosionPos, forceRadius, 3.0F);
            }
        }

        foreach (var c in Physics.OverlapSphere(transform.position, dammageRadius, 1 << LayerMask.NameToLayer("Enemy")))
        {
            Rigidbody dead = c.GetComponent<Rigidbody>();
            if (dead != null)
            {
                Destroy(dead.transform.gameObject);
            }
        }
    }
}
