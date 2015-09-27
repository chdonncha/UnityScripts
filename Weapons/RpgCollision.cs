using UnityEngine;
using System.Collections;

public class RpgCollision : MonoBehaviour
{

    public GameObject explosion; // drag your explosion prefab here

    public float radius;
    public float forceRadius;
    public float power;
    public float dammageRadius;
    public AudioClip sound;
    public AudioSource _audio;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
        Destroy(gameObject); // destroy the grenade
        Destroy(expl, 3); // delete the explosion after 3 seconds

        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

        _audio.PlayOneShot(sound);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
        }

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
