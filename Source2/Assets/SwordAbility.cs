using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAbility : MonoBehaviour {
    public GameObject damageZone;
    public float cooldown;
    public float attackTime;
    private float lastAttack;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!Input.GetMouseButton(1)) return;
		if (IsReady())
        {
            Attack();
            AttackAnimation();
        }
	}

    void Attack()
    {
        lastAttack = Time.time;
        damageZone.SetActive(true);
    }

    void AttackAnimation() { }

    bool IsReady()
    {
        float time = Time.time;
        if (damageZone.active &&  time > lastAttack + attackTime) damageZone.SetActive(false);
        return time > lastAttack + cooldown;
    }
}

