using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_hit : MonoBehaviour {


    void OnCollisionEnter2D(Collision2D target)
    {
    
        if (target.gameObject.tag == "Monster")
        {
            Destroy(this.gameObject);
            target.gameObject.GetComponent<Monster_stat>().Monster_hit(player_stat.bullet_Damage);

        }
    }
}
