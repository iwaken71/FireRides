using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class YarnModel{

    public Vector3ReactiveProperty UpperPoint;
    public Vector3ReactiveProperty OriginPoint;
    public ReadOnlyReactiveProperty<Vector3> Point;// 
    public float timer;
    //public Vector3 power{get;private set;}


   // public BoolReactiveProperty isAlive{get;private set;}
   // public BoolReactiveProperty isReady = true;

    YarnStateReactiveProperty state;
    public IReadOnlyReactiveProperty<YarnState> State { get { return state; }}

    public YarnModel (Vector3 upperPoint,Vector3 originPoint)
    {
        state = new YarnStateReactiveProperty(YarnState.Ready);
        UpperPoint = new Vector3ReactiveProperty(upperPoint);
        OriginPoint = new Vector3ReactiveProperty(originPoint);
        timer = 0;
        //Point = Observable.CombineLatest(UpperPoint, OriginPoint, (x, y) => x + y).ToReadOnlyReactiveProperty();
    }
    public YarnModel ()
    {
        state = new YarnStateReactiveProperty(YarnState.Ready);
        UpperPoint = new Vector3ReactiveProperty(Vector3.zero);
        OriginPoint = new Vector3ReactiveProperty(Vector3.zero);
        timer = 0;
        //Point = Observable.CombineLatest(UpperPoint, OriginPoint, (x, y) => x + y).ToReadOnlyReactiveProperty();
    }

    public void SetState (YarnState input)
    {
        state.Value = input;
    }

    /*
    void Start ()
    {
        isAlive = true;
        isReady = true;
        power = Vector3.zero;
    }*/
    /*
    void Update ()
    {
        if (isAlive) {
            if (isReady) {
                float cos = Vector3.Dot((OriginPoint-UpperPoint).normalized,Vector3.down);
                power = (UpperPoint - OriginPoint).normalized * Const.gravity *cos;
            } else {
                if (timer <= 0.25f) {
                    timer += Time.deltaTime;
                }
                float cos = Vector3.Dot((OriginPoint-UpperPoint).normalized,Vector3.down);
                power = (UpperPoint - OriginPoint).normalized * Const.gravity *cos* (timer*6f+1);


            }

           
            

        }else {

            power = Vector3.zero;
            timer = 0;
        }

    }*/


    public void SetUpperPoint(Vector3 vec){
        //isAlive = true;
        UpperPoint.Value = vec;
    }
    /*
    public void StartGame ()
    {
        isReady = false;

    }*/

    public void SetOriginPoint (Vector3 vec)
    {
        OriginPoint.Value = vec;
    }
    /*
    public void LostPoint ()
    {
        isAlive = false;
    }
    */


}

public enum YarnState{
    Ready,
    Active,
    NonActive
}

[System.Serializable]
public class YarnStateReactiveProperty : ReactiveProperty<YarnState>
{
    public YarnStateReactiveProperty (){}
    public YarnStateReactiveProperty (YarnState initialValue) : base (initialValue) {}
}
