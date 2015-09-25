using UnityEngine;
using System.Collections;

public class DerpAI : MonoBehaviour
{

    public NavMeshAgent agent;
    public Transform player;


    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
    }
}
