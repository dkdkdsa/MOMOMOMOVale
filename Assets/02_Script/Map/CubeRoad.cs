using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRoad : RoadObject
{

    public override Vector3 GetMovePos()
    {

        Vector3 frontVec = Vector3.zero;

        switch (objFront)
        {
            case ObjFront.x:
                frontVec = transform.right; 
                break;
            case ObjFront.Mx:
                frontVec = -transform.right;
                break;
            case ObjFront.y:
                frontVec = transform.up;
                break;
            case ObjFront.My:
                frontVec = -transform.up;
                break;
            case ObjFront.z:
                frontVec = transform.forward;
                break;
            case ObjFront.Mz:
                frontVec = -transform.forward;
                break;

        }

        return (transform.position) + frontVec * 0.5f;

    }

}
