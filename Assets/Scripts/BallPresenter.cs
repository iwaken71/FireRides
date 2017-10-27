﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class BallPresenter : MonoBehaviour {

    BallModel ballModel;
    YarnModel yarnModel;

    //float timer = 0;
    void Awake ()
    {
        Init();

        var stream = Observable.EveryUpdate ();
        stream
        .Where (_ => Input.GetMouseButtonDown (0))
        .Subscribe (_ => ClickDown()).AddTo (gameObject);
        stream
        .Where (_ => Input.GetMouseButtonUp (0))
        .Subscribe (_ => ClickUp()).AddTo (gameObject);

        //yarnModel.State
        //.Where(state => state == YarnState.Active)

       

    }

    void ClickDown(){
        Vector3 dir = new Vector3 (1, 1, 0);

        if (IsHitRay (dir)) {
            yarnModel.SetUpperPoint(GetRayPoint(dir));
            yarnModel.SetOriginPoint(this.transform.position);
            yarnModel.SetState(YarnState.Active);
        }
    }

    Vector3 Power ()
    {
        Vector3 power = Vector3.zero;
        if (yarnModel.State.Value == YarnState.Ready) {
            float cos = Vector3.Dot ((yarnModel.OriginPoint.Value - yarnModel.UpperPoint.Value).normalized, Vector3.down);
            power = (yarnModel.UpperPoint.Value - yarnModel.OriginPoint.Value).normalized * Const.gravity * cos;
        } else if (yarnModel.State.Value == YarnState.Active) {
            if (yarnModel.timer <= 0.25f) {
                yarnModel.timer += Time.deltaTime;
            }
            float cos = Vector3.Dot ((yarnModel.OriginPoint.Value - yarnModel.UpperPoint.Value).normalized, Vector3.down);
            power = (yarnModel.UpperPoint.Value - yarnModel.OriginPoint.Value).normalized * Const.gravity * cos * (yarnModel.timer * 6f + 1);
        }

        power += new Vector3 (0, -Const.gravity, 0);
        return power;
    }

    void ClickUp(){
        yarnModel.SetState(YarnState.NonActive);
    }

    void Init ()
    {
        ballModel = new BallModel (this.transform.position);
        yarnModel = new YarnModel ();

    }
    void Start ()
    {
        
        Vector3 dir = new Vector3 (0, 1, 0);
        if (IsHitRay (dir)) {
            yarnModel.SetUpperPoint(GetRayPoint(dir));
            yarnModel.SetOriginPoint(this.transform.position);
        }
        yarnModel.SetOriginPoint(this.transform.position);


        var updateStream = Observable.EveryUpdate ();
        updateStream
        .Where(_ => yarnModel.State.Value == YarnState.Active)
        .Subscribe(_ => {
            yarnModel.timer += Time.deltaTime;
        });

        yarnModel.State
        .Where(s => s == YarnState.NonActive)
        .Subscribe(_ => {
            yarnModel.timer = 0;
        });

        Observable.EveryFixedUpdate().Subscribe(_ =>{
            ballModel.PositionUpdate(Power ());
            transform.position = new Vector3(ballModel.x,ballModel.y,0);
        });
    }

    bool IsHitRay (Vector3 dir)
    {
        Ray ray = new Ray (transform.position, dir);
        RaycastHit hit;
//        Debug.Log(ray);
        if (Physics.Raycast (ray, out hit,30)) {
            return true;
          //  Debug.Log(hit.collider.name);
        }
        return false;
    }

    Vector3 GetRayPoint (Vector3 dir)
    {
        Ray ray = new Ray (transform.position, dir);
        RaycastHit hit;
//        Debug.Log(ray);
        if (Physics.Raycast (ray, out hit,30)) {
            return hit.point;
          //  Debug.Log(hit.collider.name);
        }
        return transform.position;
    }




    
    
    
}
