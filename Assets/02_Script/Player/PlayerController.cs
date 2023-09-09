using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private RoadObject currentRoad = null;

    private bool moveAble = true;

    private void Awake()
    {
        
        transform.position = currentRoad.GetMovePos() + new Vector3(0, 0.25f);

    }

    private void Update()
    {
        
        if(Input.GetMouseButtonDown(0) && moveAble)
        {

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hitInfo, 1000, LayerMask.GetMask("Road")))
            {

                if(hitInfo.transform.TryGetComponent<RoadObject>(out var compo))
                {

                    if (compo.moveAble)
                    {

                        MoveCo(compo);

                    }


                }

            }

        }

    }

    private void MoveCo(RoadObject firstRoad)
    {

        Sequence seq = DOTween.Sequence();

        var cur = firstRoad;
        int moveCnt = 0;
        bool isBreaked = false;

        moveAble = false;

        while(cur.before != currentRoad)
        {
            moveCnt++;
            seq.Prepend(transform.DOMove(cur.GetMovePos() + new Vector3(0, 0.25f), 0.3f));
            cur = cur.before;
            
            if(cur.before == null || cur.moveAble == false)
            {

                isBreaked = true;
                break;

            }

        }

        if (isBreaked)
        {

            seq.Kill();

        }

        currentRoad = firstRoad;
        moveAble = true;

    }

}
