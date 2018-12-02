using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_stat : MonoBehaviour {


    public GameObject Rarm;
    public GameObject Larm;

    [SerializeField]
    public Slider playerHPbar;

    public float current_HP = 100f;
    private float maxValue_slider = 100f;

    void Start()
    {
        playerHPbar_initialization();
    }

    void playerHPbar_initialization()
    {
        current_HP = maxValue_slider;
        playerHPbar.minValue = 0;
        playerHPbar.maxValue = maxValue_slider;
        playerHPbar.value = current_HP;

    }
    

    public void AddHP(float hp_change)
    {
        current_HP += hp_change;
        playerHPbar.value = current_HP;

        if (current_HP < 0) playerDeath();
    }

    public void playerDeath()
    {
        xAbility[] abilities = this.GetComponentsInChildren<xAbility>();
        foreach(xAbility ability in abilities)
        {
            ability.enabled = false;
            ability.gameObject.SetActive(false);
        }
        this.GetComponent<Animator>().Play("hero_death");
    }

    public void playerDestroy() {
        this.gameObject.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
