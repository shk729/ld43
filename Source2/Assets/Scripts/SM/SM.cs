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


class WaitUntilInactiveState : StateItem
{
    private GameObject objectToWait;

    public WaitUntilInactiveState(GameObject obj)
    {
        this.objectToWait = obj;
    }

    public override StateItem run()
    {
        Debug.Log(objectToWait.active);
        if (objectToWait.active) return this;
        return next;
    }
}


class ChangeActiveState : StateItem
{
    private GameObject parent;
    private string name;
    private bool value;

    public ChangeActiveState(GameObject parent, string name, bool value)
    {
        this.parent = parent;
        this.name = name;
        this.value = value;
    }

    public override StateItem run()
    {
        Transform[] children = parent.GetComponentsInChildren<Transform>(true);
        foreach(Transform child in children)
        {
            if (child.name != name) continue;
            child.gameObject.SetActive(value);
        }
        return next;
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
        if (Time.time > startTime + delay)
        {
            startTime = 0;
            return next;
        }
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
    private string name;
    private bool value = true;

    public ActivateSpawner(string name, bool value)
    {
        this.name = name;
        this.value = value;
    }

    public ActivateSpawner(string name)
    {
        this.name = name;
    }

    public override StateItem run()
    {

        xMonsterSpawner[] spawners = GameObject.FindObjectsOfType<xMonsterSpawner>();
        foreach(xMonsterSpawner spawner in spawners)
        {
            if (!spawner.name.Equals(name) ) continue;
            spawner.active = value;
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
