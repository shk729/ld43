using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pMove : MonoBehaviour{
    private GameObject player;
    static Rigidbody2D playerBody;

    private Animator player_anim;
    //Vector2 moveDirection;

    public float speed;

    // Use this for initialization
    void Start () {
        playerBody = GetComponent<Rigidbody2D>();
        player = this.gameObject;

        player_anim = this.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		// s
	}

    private void Awake()
    {
       
    }

    private void FixedUpdate()
    {
        KeyboardMove();
    }


    void KeyboardMove()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        Vector2 moveDirection = new Vector2(inputX, inputY).normalized;
        playerBody.MovePosition(playerBody.position + (moveDirection * speed) );

        if (inputX<0) this.transform.localScale = new Vector3(1f, 1, 1);
            else if (inputX > 0) this.transform.localScale = new Vector3(-1f, 1, 1);

        if (moveDirection.magnitude>0) player_anim.Play("hero_walk");
    }
}
