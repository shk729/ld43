using System.Collections;
using System.Collections.Generic;
using UnityEngine;


abstract class StateItem
{
    public StateItem next;

    public abstract StateItem run();
}

class Scenary
{
    private StateItem current;
    private StateItem start;

    public Scenary then(StateItem state)
    {
        if (start == null) start = state;
        if (current != null) current.next = state;
        current = state;
        return this;
    }

    public void run()
    {
        if (start == null) return;
        start = start.run();
    }
}


class WaitState : StateItem
{
    private float delay;
    private float startTime = 0;

    public WaitState(float delay)
    {
        this.delay = delay;
    }

    public override StateItem run()
    {
        if (startTime == 0)
        {
            startTime = Time.time;
            return this;
        }
        if (Time.time > startTime + delay) return next;
        return this;
    }
}

class LogState : StateItem
{
    private string msg;

    public LogState(string value)
    {
        msg = value;
    }

    public override StateItem run()
    {
        Debug.Log(msg);
        return next;
    }
}


class WaitForNoMonsters : StateItem
{
    public override StateItem run()
    {
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
        if (monsters.Length == 0) return next;
        return this;
    }
}


class ActivateSpawner : StateItem
{
    private string tag;
    private bool value = true;

    public ActivateSpawner(string tag, bool value)
    {
        this.tag = tag;
        this.value = value;
    }

    public ActivateSpawner(string tag)
    {
        this.tag = tag;
    }

    public override StateItem run()
    {
        GameObject[] spawners = GameObject.FindGameObjectsWithTag(tag);
        foreach(GameObject spawner in spawners)
        {
            xMonsterSpawner item = spawner.GetComponent<xMonsterSpawner>();
            if (item == null) continue;
            item.active = value;
        }

        return next;
    }
}


/*
class StateStart {
    void Test() {
        Start()
            .then( WaitForX() )
            .then( ShowText("Text") )
            .then( ShowRemoveAbilityScreen() )
            .then( ActivateSpawnPoint()  )
    }
}
*/
