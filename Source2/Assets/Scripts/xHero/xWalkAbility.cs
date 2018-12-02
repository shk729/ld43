using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xWalkAbility : xAbility {
    public float speed;
    public GameObject hero;

    public override void doUpdate()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(inputX, inputY);
        KeyboardMove(move);
        AnimationControl(move);
    }

    // Use this for initialization
    void Start () {
		
	}

	void KeyboardMove(Vector2 moveDirection)
    {
        Rigidbody2D body = Body();
        body.MovePosition( body.position + (moveDirection * speed) );
    }

    void AnimationControl(Vector2 moveDirection)
    {
        if (moveDirection.x < 0) this.transform.localScale = new Vector3(1f, 1, 1);
        else if (moveDirection.x > 0) this.transform.localScale = new Vector3(-1f, 1, 1);
        
        if (moveDirection.normalized.magnitude > 0) Animator().Play("hero_walk");
    }


    Rigidbody2D Body()
    {
        return hero.GetComponent<Rigidbody2D>();
    }

    Animator Animator()
    {
        return hero.GetComponent<Animator>();
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
