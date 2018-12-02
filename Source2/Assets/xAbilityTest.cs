using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class xAbility : MonoBehaviour {
    public bool enabled;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (enabled) doUpdate();
    }

    abstract public void doUpdate();
}
