using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenaryPlayer : MonoBehaviour {

    public GameObject messages;
    public GameObject ui;
    public GameObject dialogItem;
    public float delay = 0.2f;
    

    private float lastRun;
    private Scenary scenary = new Scenary();
    // Use this for initialization
    void Start () {
        generateScenary();
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

    void generateScenary()
    {
        StateItem first = new LogState("Loop Start");
        //StateItem last = new LogState("Loop End");
        scenary
            .then(first)
            .then(new ActivateSpawner("Spawner_1"))
            .then(new ActivateSpawner("Spawner (2)"))
            .then(new ActivateSpawner("Spawner (3)"))
            .then(new ActivateSpawner("Spawner (4)"))
            .then(new ActivateSpawner("Spawner (5)"))
            .then(new ActivateSpawner("Spawner (6)"))
            .then(new ActivateSpawner("Spawner (7)"))
            .then(new ActivateSpawner("Spawner (8)"))
            .then( new ShowCounter() )
            .then(new WaitState(3f))
            .then(new WaitForNoMonsters())
            .then(new ChangeActiveState(messages, "WaveComplete", true))
            .then(new WaitState(2.2f))
            .then(new ChangeActiveState(messages, "WaveComplete", false))
            .then(new ChangeActiveState(ui, "Skill choose panel", true))
            .then(new WaitUntilInactiveState(dialogItem))
            .then(first)
            ;
    }

    void Run()
    {
        if (scenary == null) return;
        scenary.run();
    }
}
