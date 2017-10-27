using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yarn : MonoBehaviour {

    public Vector3 UpperPoint{get;private set;}
    public Vector3 OriginPoint{get;private set;}
    float timer;
    public Vector3 power{get;private set;}


    public bool isAlive{get;private set;}
    public bool isReady = true;

    void Start ()
    {
        isAlive = true;
        isReady = true;
        power = Vector3.zero;
    }

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

    }


    public void SetUpperPoint(Vector3 vec){
        isAlive = true;
        UpperPoint = vec;
    }

    public void StartGame ()
    {
        isReady = false;

    }

    public void SetLowerPoint (Vector3 vec)
    {
        OriginPoint = vec;
    }

    public void LostPoint ()
    {
        isAlive = false;
    }



}
