using UnityEngine;
using System.Collections;

public class BulletCollision : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.layer.Equals("Bullet"))
        {
            Destroy(gameObject);
        }
    }


  //  void OnTriggerEnter(Collider other)
  //  {
   //     if (other.gameObject.tag == "bullet")
   //         Destroy(gameObject);
  //  }
}