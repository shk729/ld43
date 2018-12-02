using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee_control : MonoBehaviour {
    public float cooldown;
    public float attackTime;
    private float last = 0f; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (IsReady()) Attack();
	}

    void Attack()
    {
        
    }

    bool IsReady()
    {
        return Time.time > (last + cooldown);
    }
}
