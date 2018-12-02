using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHit : MonoBehaviour {
    public float damage;


	void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Monster")
        {
            target.gameObject.GetComponent<Monster_stat>().Monster_hit( damage );
        }
    }
}
