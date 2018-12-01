using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFollowAI : MonoBehaviour {
    public GameObject target;
    public float speed;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = - this.transform.position;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        MoveToTarget();
	}

    void MoveToTarget()
    {
        if (target == null) return;
        Vector3 tPosition = target.transform.position ;
        Vector3 current = this.transform.position;
        this.transform.position = Vector3.MoveTowards(current, tPosition, speed);

    }
}
