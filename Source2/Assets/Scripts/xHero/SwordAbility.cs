using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAbility : xAbility
{
    public GameObject damageZone;
    public float cooldown;
    public float attackTime;
    private float lastAttack;

	// Use this for initialization
	void Start () {
		
	}

    private void FixedUpdate()
    {
        if (!IsReady()) return;
        if (!Input.GetMouseButton(1)) return;
        Attack();
        AttackAnimation();
    }
    void Attack()
    {
        lastAttack = Time.time;
        damageZone.SetActive(true);
    }

    void AttackAnimation() {
        Animator animator = this.GetComponent<Animator>();
        animator.Play("sword_attack");
    }

    bool IsReady()
    {
        float time = Time.time;
        if (damageZone.activeSelf &&  time > lastAttack + attackTime) damageZone.SetActive(false);
        return time > lastAttack + cooldown;
    }

    public override void doUpdate()
    {
        // Do nothing...
    }
}

