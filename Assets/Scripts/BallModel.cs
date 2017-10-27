using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class BallModel{

    public float x {get; private set;}
    public float y {get; private set;}
    FloatReactiveProperty vx,vy;
    FloatReactiveProperty ax,ay;
    [SerializeField]float m;



    Vector3ReactiveProperty power;
    //Yarn yarn;


    public BallModel (Vector3 startPosition)
    {
        x = startPosition.x;
        y = startPosition.y;
        ax = new FloatReactiveProperty(0);
        ay = new FloatReactiveProperty(0);
        vx = new FloatReactiveProperty(0);
        vy = new FloatReactiveProperty(0);

        //power = new Vector3ReactiveProperty(Vector3.zero);
    }
	void Start ()
    {
//        ax = 0;
//        ay = 0;
//        vx = 0;
//        vy = 0;
//        m = 1;
//        x = transform.position.x;
//        y = transform.position.y;
//       // yarn = GetComponentInChildren<Yarn>();
//        power = Vector3.zero;
        //CastRay(new Vector3(0,1,0));
    }
    /*
    void Update ()
    {

        if (Input.GetMouseButtonDown (0)) {
            CastRay (new Vector3(1,1.5f,0));
            yarn.StartGame();

        } else if (Input.GetMouseButtonUp (0)) {
            yarn.LostPoint();

        }

       

    }/*


    void SetPower ()
    {
        if (!yarn.isReady) {
            power = new Vector3 (0, -Const.gravity, 0) + yarn.power;
        } else {
            power = Vector3.zero;
        }
       // Debug.Log(power);

       // Debug.Log(ay);

    }
    /*
    void CastRay (Vector3 dir)
    {
        Ray ray = new Ray (transform.position, dir);
        RaycastHit hit;
//        Debug.Log(ray);
        if (Physics.Raycast (ray, out hit,30)) {
            yarn.SetUpperPoint(hit.point);
          //  Debug.Log(hit.collider.name);
        }

    }*/

    public void PositionUpdate (Vector3 power)
    {

        ax.Value = power.x/m;
        ay.Value = power.y/m;

        vx.Value += ax.Value * Time.fixedDeltaTime;
        vy.Value += ay.Value * Time.fixedDeltaTime;

        x += vx.Value * Time.fixedDeltaTime;
        y += vy.Value * Time.fixedDeltaTime;
    }

    /*
    void FixedUpdate(){
        SetPower ();

       
        transform.position = new Vector3(x,y,0);
        yarn.SetLowerPoint(new Vector3(x,y,0));
    }*/
}
