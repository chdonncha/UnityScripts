using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour {

    private NavMeshAgent _agent;
    private Transform _target;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

	// Use this for initialization
    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
    void Update()
    {
        _agent.SetDestination(_target.position);
        var camPos = Camera.main.transform.position;
        camPos.y = transform.position.y;
        transform.rotation = Quaternion.LookRotation(transform.position - camPos);
    }
}
