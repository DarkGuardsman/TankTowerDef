using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodePath : NodeMap {

    public NodePath nextPoint;

    public override void OnEnable ()
    {
        base.OnEnable();
        moveGoal.position = targetPoint;
	}

    protected override int getRayOffsetY()
    {
        return 1;
    }
}
