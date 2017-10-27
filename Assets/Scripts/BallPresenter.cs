using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPresenter : MonoBehaviour {

    BallModel ballModel;
    YarnModel yarnModel;


    void Start ()
    {
        ballModel = new BallModel (this.transform.position);
        yarnModel = new YarnModel ();
        Vector3 dir = new Vector3 (0, 1, 0);

        if (IsHitRay (dir)) {
            yarnModel.SetUpperPoint(CastRay(dir));
            yarnModel.SetOriginPoint(this.transform.position);
        }
        yarnModel.SetOriginPoint(this.transform.position);
    }


    void FixedUpdate ()
    {
        
        ballModel.PositionUpdate(Vector3.zero);
        transform.position = new Vector3(ballModel.x,ballModel.y,0);

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

    Vector3 CastRay (Vector3 dir)
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
