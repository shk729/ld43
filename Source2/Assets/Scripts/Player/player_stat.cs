using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_stat : MonoBehaviour {


    [SerializeField]
    public Slider playerHPbar;

    public float curValue_slider=100f;
    private float maxValue_slider = 100f;

    void Start()
    {
        playerHPbar_initialization();
    }

    void playerHPbar_initialization()
    {
        curValue_slider = maxValue_slider;
        playerHPbar.minValue = 0;
        playerHPbar.maxValue = maxValue_slider;
        playerHPbar.value = curValue_slider;

    }
}
