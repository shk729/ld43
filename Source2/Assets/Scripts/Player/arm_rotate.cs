using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arm_rotate : MonoBehaviour
{
    private Vector3 m;
    public Camera cam;

    void FixedUpdate()
    {

        Vector3 temp = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
        Vector3 currentMousePosition = cam.ScreenToWorldPoint(temp);    
        Vector3 mouseDirection = currentMousePosition - transform.position;

         float angle = Vector3.Angle(mouseDirection, Vector3.up);

         float moveAngle = 0;
         float rotAngle = Mathf.Atan(mouseDirection.normalized.y/ mouseDirection.normalized.x); 

         if (mouseDirection.normalized.x>=0)
             moveAngle = rotAngle * Mathf.Rad2Deg-90;
         else if (mouseDirection.normalized.x<0)
             moveAngle = rotAngle * Mathf.Rad2Deg+90;

        this.gameObject.transform.rotation = Quaternion.Euler (0, 0, moveAngle-90);

    }

}