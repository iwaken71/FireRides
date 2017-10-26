using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    float x,y;
    float vx,vy;
    float ax,ay;
    float m;



    Vector3 power;
    Yarn yarn;



	void Start ()
    {
        ax = 0;
        ay = 0;
        vx = 0;
        vy = 0;
        m = 1;
        x = transform.position.x;
        y = transform.position.y;
        yarn = GetComponentInChildren<Yarn>();
        power = Vector3.zero;

        CastRay(new Vector3(0,1,0));
    }

    void Update ()
    {

        if (Input.GetMouseButtonDown (0)) {
            CastRay (new Vector3(1,1.5f,0));
            yarn.StartGame();

        } else if (Input.GetMouseButtonUp (0)) {
            yarn.LostPoint();

        }

       

    }


    void SetPower ()
    {
        if (!yarn.isReady) {
            power = new Vector3 (0, -Const.gravity, 0) + yarn.power;
        } else {
            power = Vector3.zero;
        }
        Debug.Log(power);
        ax = power.x/m;
        ay = power.y/m;
        Debug.Log(ay);

    }

    void CastRay (Vector3 dir)
    {
        Ray ray = new Ray (transform.position, dir);
        RaycastHit hit;
//        Debug.Log(ray);
        if (Physics.Raycast (ray, out hit,30)) {
            yarn.SetUpperPoint(hit.point);
          //  Debug.Log(hit.collider.name);
        }

    }


    void FixedUpdate(){
        SetPower ();

        vx += ax * Time.fixedDeltaTime;
        vy += ay * Time.fixedDeltaTime;

        x += vx * Time.fixedDeltaTime;
        y += vy * Time.fixedDeltaTime;

        transform.position = new Vector3(x,y,0);
        yarn.SetLowerPoint(new Vector3(x,y,0));

    }
}
