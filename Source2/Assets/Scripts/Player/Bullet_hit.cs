using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_hit : MonoBehaviour {


    void OnCollisionEnter2D(Collision2D target)
    {
        Debug.Log("hit1");
        if (target.gameObject.tag == "Monster")
        {
            Destroy(this.gameObject);
            Debug.Log("hit");

          target.gameObject.GetComponent<Monster_stat>().Monster_hit(3f);

        }
    }
}
