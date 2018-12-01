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

<<<<<<< HEAD
         if (mouseDirection.normalized.x>=0)
             moveAngle = rotAngle * Mathf.Rad2Deg-90;
         else if (mouseDirection.normalized.x<0)
             moveAngle = rotAngle * Mathf.Rad2Deg+90;

        Debug.Log(moveAngle);
        this.gameObject.transform.rotation = Quaternion.Euler (0, 0, moveAngle-90);
=======
         moveAngle = rotAngle * Mathf.Rad2Deg;
         this.gameObject.transform.rotation = Quaternion.Euler (0, 0, moveAngle);
>>>>>>> de6566f32a01550344217c1658629f84526a798a

    }

}