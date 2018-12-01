using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_hit : MonoBehaviour {

    public float bullet_gamage=3f;

    void OnCollisionEnter2D(Collision2D target)
    {
    
        if (target.gameObject.tag == "Monster")
        {
            Destroy(this.gameObject);
            target.gameObject.GetComponent<Monster_stat>().Monster_hit(bullet_gamage);

        }
    }
}
