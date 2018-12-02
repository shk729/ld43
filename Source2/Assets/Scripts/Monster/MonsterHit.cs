using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHit : MonoBehaviour {
    public float damage;

    private player_stat onAim;
	// Use this for initialization
	void Start () {
		
	}

    private void LateUpdate()
    {
        if (onAim != null)
        {
            onAim.AddHP(-damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            onAim = target.gameObject.GetComponent<player_stat>(); //.AddHP(-damage);
        }
    }
    private void OnTriggerExit2D(Collider2D target)
    {
        onAim = null;
    }
}
