using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_stat : MonoBehaviour {


    [SerializeField]
    public Slider playerHPbar;

    public static float bullet_Damage = 3f;

    public float current_HP=100f;
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
}
