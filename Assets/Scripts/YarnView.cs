using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YarnView : MonoBehaviour {
    LineRenderer lr;

    
    //Yarn yarn;
    //[SerializeField]GameObject bar;


    void Start(){
        //yarn = GetComponent<Yarn>();

        lr = gameObject.GetComponent<LineRenderer>();
    }
	/*
	// Update is called once per frame
	void LateUpdate ()
    {
        if (yarn.isAlive) {
            lr.enabled = true;
            lr.SetPosition(0,yarn.UpperPoint);
            lr.SetPosition(1,yarn.OriginPoint);
            lr.startWidth = 0.1f;
            lr.endWidth = 0.1f;
            //bar.SetActive(true);
            SetBarPosition(yarn.UpperPoint,yarn.OriginPoint);
           
        } else {
           lr.enabled = false;
           //bar.SetActive(false);
        }
		
	}*/

    
    /*
    void SetBarPosition(Vector3 upper,Vector3 lower){
        Vector3 center = (upper + lower)/2;
        bar.transform.position = center;
        bar.transform.up = upper-lower;
        float length = Vector3.Distance(upper,lower);
        bar.transform.localScale = new Vector3(0.0f,length,0.05f);

    }

    */
    public void SetYarnPosition(Vector3 upper,Vector3 lower){
        lr.SetPosition(0,upper);
        lr.SetPosition(1,lower);
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
    }

    public void SetEnable (bool input)
    {
        lr.enabled = input;
    }
}
