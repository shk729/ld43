using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xMonsterSpawner : MonoBehaviour {
    public bool active = true;
    public float initialDelay;
    public float delay;
    public bool infinitySpawn;
    public GameObject defaultTarget;
    public GameObject[] monstersArray;

    private int i = 0;
    private float lastSpawn = 0f;


	// Use this for initialization
	void Start () {
        lastSpawn = Time.time + initialDelay;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (!active) return;
        if (!IsReadyToSpawn()) return;
        Spawn();
	}

    void Spawn()
    {
        GameObject monster = Instantiate(GetNext(), this.transform.position, Quaternion.identity);
        monster.GetComponent<MonsterFollowAI>().target = defaultTarget;
        lastSpawn = Time.time;
    }

    GameObject GetNext()
    {
        if (i == monstersArray.Length) i = 0;
        if (!infinitySpawn && i + 1 == monstersArray.Length) active = false;
        return monstersArray[i++];
    }

    bool IsReadyToSpawn()
    {
        return Time.time > lastSpawn + delay;
    }
}
