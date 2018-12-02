using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xHeroAbilities : MonoBehaviour {

    public LineRenderer lr;
    public Camera cam;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
    }


    private void Update()
    {
        if (Input.GetKey("q"))
        {
            LaserShot();
        }
        else lr.enabled = false;


    }



    public void LaserShot()
    {
        lr.enabled = true;
        Vector3 temp = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
        Vector3 currentMousePosition = cam.ScreenToWorldPoint(temp);

        Vector2 mouseDirection = currentMousePosition - transform.position;

        lr.SetPosition(0, mouseDirection * 10);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, mouseDirection, 20f);
        Debug.Log(hit.collider);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Monster")
            {
                hit.collider.gameObject.GetComponent<Monster_stat>().Monster_hit(100f);
            }
        }


    }
}
