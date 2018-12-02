using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHit : MonoBehaviour {
    public float damage;


	void OnTriggerEnter2D(Collider2D target)
    {
        Debug.Log("Shotaputat");
        if (target.gameObject.tag == "Monster")
        {
            target.gameObject.GetComponent<Monster_stat>().Monster_hit( damage );
        }
    }
}
