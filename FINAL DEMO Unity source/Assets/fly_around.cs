using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fly_around : MonoBehaviour {
    Worq.AWSPatrol butter_alti;
        
    // Use this for initialization
    void Start() {
        butter_alti = GetComponent<Worq.AWSPatrol>();
    }

    // Update is called once per frame
    void Update() {
        
        //butter_alti = (int)gameObject.transform.position.y;

        if (butter_alti.distanceFromGround < 5)
        {
            butter_alti.distanceFromGround += 0.4f;
        }

        else if (butter_alti.distanceFromGround >= 8)
        {
            butter_alti.distanceFromGround -= 0.4f;
        }
    }
    
}



