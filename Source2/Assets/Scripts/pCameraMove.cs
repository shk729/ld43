using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pCameraMove : MonoBehaviour {
    public GameObject player;
    public float speedOffset;

    private Vector3 offset;

    // Use this for initialization
    void Start () {
        offset = transform.position - player.transform.position;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 oldPosition = transform.position;
        Vector3 newPosition = player.transform.position + offset;
        Vector3 difPosition = (newPosition - oldPosition) / speedOffset;
        transform.position = oldPosition + difPosition;
    }
}
