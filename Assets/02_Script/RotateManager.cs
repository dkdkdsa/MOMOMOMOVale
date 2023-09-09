using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateManager : MonoBehaviour
{

    [SerializeField] private GameObject rotateObj;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            rotateObj.transform.DORotate(new Vector3(0, 0, 90), 0.5f).SetEase(Ease.OutBounce).OnComplete(() =>
            {

                foreach(var itme in rotateObj.GetComponentsInChildren<RoadObject>())
                {

                    itme.moveAble = true;

                }

            });

        }

    }

}
