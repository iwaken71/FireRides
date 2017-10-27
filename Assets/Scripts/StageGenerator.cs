using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour {
    [SerializeField]GameObject WallPrefab;
    public GameObject ball;

  

    int index = 0;
    float timer = 0;

    List<GameObject> WallPool = new List<GameObject>();

    int poolIndex=0; 

	// Use this for initialization
	void Awake ()
    {
        
        for (int i = 0; i < 8; i++) {
            GameObject a =  Instantiate(WallPrefab,new Vector3(3*index,20+Random.Range(-3,3),0),Quaternion.identity)as GameObject ;
            index++;
            WallPool.Add(a);
        }
	}

    void Update ()
    {
        if (ball.gameObject.transform.position.x + 20 >= index * 3) {
            GeneratePoolWall ();
        }
    }
	
   
    public void GeneratePoolWall ()
    {
        if (poolIndex >= WallPool.Count) {
            poolIndex=0;
        }
        GameObject a = WallPool[poolIndex];
        a.transform.position = new Vector3(3*index,20+Random.Range(-3,3),0);
        poolIndex++;
        index++;
    }
}
