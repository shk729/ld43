using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class xHeroAbilities : MonoBehaviour {

    public LineRenderer lr;
    public Camera cam;
    public Text abilka1_text;
    public float Laser_duration;
    public float Laser_cooldown;
    public float Laser_damage=100f;
    public GameplayAudioManager audioManager;


    private float cooldownStart;
    bool cooldown=false;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;
    }


    private void Update()
    {
        if (Input.GetKey("q") && !cooldown){
            lr.enabled = true;
            StartCoroutine(LaserShootEnd());

            cooldownStart = Time.fixedTime;
            cooldown = true;
            StartCoroutine(LaserCooldownEnd());

        }

        if (lr.enabled)
        {
            audioManager.PlayLaserSound();
            LaserShot();
        } else
        {
            audioManager.StopLaserSound();
        }

        if (cooldown)
        {            
            abilka1_text.text = (cooldownStart + Laser_cooldown - Time.fixedTime).ToString("F0");
        }

    }


    public void LaserShot()
    {

        Vector3 temp = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
        Vector3 currentMousePosition = cam.ScreenToWorldPoint(temp);

        Vector2 mouseDirection = currentMousePosition - transform.position;

        lr.SetPosition(0, mouseDirection * 10);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, mouseDirection, 100f);        

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Monster")
            {
                hit.collider.gameObject.GetComponent<Monster_stat>().Monster_hit(Laser_damage);
            }
        }    
    }

    IEnumerator LaserShootEnd(){    
        yield return new WaitForSeconds(Laser_duration);
        lr.enabled = false;
    }

    IEnumerator LaserCooldownEnd()
    {
        yield return new WaitForSeconds(Laser_cooldown);
        cooldown = false;
        abilka1_text.text = " ";
    }

}
