using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjFront
{

    x,
    Mx,
    y,
    My,
    z,
    Mz

}

public abstract class RoadObject : MonoBehaviour
{

    [SerializeField] protected ObjFront objFront;

    public RoadObject before;
    public bool moveAble;

    public abstract Vector3 GetMovePos();

    protected virtual void OnDrawGizmos()
    {

        var old = Gizmos.color;

        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(GetMovePos(), 0.25f);
        Gizmos.color = old;

    }

}
