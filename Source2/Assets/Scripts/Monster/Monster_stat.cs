using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster_stat : MonoBehaviour {

    public float monster_HP = 10;

    [SerializeField]
    private Slider monsterSlider;

    private float monster_currentHP;

    void Start()
    {
        MonsterSliderInitialization();
    }

    public void Monster_hit(float damage)
    {
        monster_HP -= damage;
        monsterSlider.value = monster_HP;

        if (monster_HP <= 0) Destroy(this.gameObject);
        
    }

    void MonsterSliderInitialization()
    {

        monsterSlider.minValue = 0;
        monsterSlider.maxValue = monster_HP;
        monsterSlider.value = monster_HP;
    }

    public void SetHP(float hp)
    {
        monster_HP = hp;
    }
}
