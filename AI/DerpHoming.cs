using UnityEngine;
using System.Collections;

public class DerpHoming : MonoBehaviour
{

    public int rotationSpeed;
    public int movementSpeed;

    private Transform myTransform;
    public Transform target;

    // Use this for initialization
    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        target = go.transform;
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        //Debug.DrawLine(myTransform.position, target.position, Color.red);
        //rotate enemy
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);
        //move
        myTransform.position += myTransform.forward * movementSpeed * Time.deltaTime;
    }
}
