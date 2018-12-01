using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_rotate : MonoBehaviour {


    public Camera cam;

   	void FixedUpdate () {

        Vector3 temp = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
        Vector3 currentMousePosition = cam.ScreenToWorldPoint(temp);


        if (currentMousePosition.x <= 0) this.transform.localScale = new Vector3(1f, 1, 1);
        else this.transform.localScale = new Vector3(-1f, 1, 1);

    }


}
