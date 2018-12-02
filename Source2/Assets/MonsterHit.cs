using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHit : MonoBehaviour {
    public float damage;
	// Use this for initialization
	void Start () {
		
	}

    void OnCollisionStay2D(Collision2D target)
    {
        Debug.Log(target.gameObject.tag);
        if (target.gameObject.tag == "Player")
        {
            target.gameObject.GetComponent<player_stat>().AddHP(-damage);
        }
    }
}
