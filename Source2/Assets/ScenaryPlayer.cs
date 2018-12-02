using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenaryPlayer : MonoBehaviour {

    public float delay = 0.2f;

    private float lastRun;
    private Scenary scenary = new Scenary();
    // Use this for initialization
    void Start () {
        scenary
            .then(new LogState("Start of machine"))
            .then(new WaitState(0.5f))
            .then(new LogState("Afffter delllay"))
            .then(new WaitState(0.5f))
            .then(new LogState("Afffter delllay 2 COOOL !!!"))
            .then(new WaitForNoMonsters())
            .then(new LogState("thea all DEAD!!!!"))
            ;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        float time = Time.time;
        if (Time.time > lastRun + delay)
        {
            lastRun = time;
            Run();
        }
	}

    void Run()
    {
        if (scenary == null) return;
        scenary.run();
    }
}
