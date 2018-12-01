using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pMove : RigidPausable {
    private GameObject player;
    static Rigidbody2D playerBody;
    //Vector2 moveDirection;

    public float speed;

    // Use this for initialization
    void Start () {
        playerBody = GetComponent<Rigidbody2D>();
        player = this.gameObject;
    }
	
	// Update is called once per frame
	void Update () {
		// s
	}

    private void Awake()
    {
        
        body = playerBody;
    }

    private void FixedUpdate()
    {
        KeyboardMove();
    }


    void KeyboardMove()
    {
        
        float forceScale = 5f;

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        Vector2 moveDirection = new Vector2(inputX, inputY);
        playerBody.MovePosition(playerBody.position + (moveDirection * speed) );
    }
}
