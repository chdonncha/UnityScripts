using UnityEngine;
using System.Collections;

public class MuzzleFlash : MonoBehaviour {

    public float timer;
    private float _counter;

	// Use this for initialization
	void Start () {
        _counter = timer;
	}
	
	// Update is called once per frame
	void Update () {
        Timer();
	}

    void Timer()
    {
        _counter -= Time.deltaTime;

        if(_counter <= 0)
        {
            Destroy(gameObject);
        }
    }
}
