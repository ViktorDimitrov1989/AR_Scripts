using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerMove : MonoBehaviour {
    public float rotateSpeed = 5.0f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float tempX = Input.acceleration.x;
        float tempY = Input.acceleration.y;
        float tempZ = Input.acceleration.z;

        transform.Translate(0,0, -tempZ * rotateSpeed);
        transform.Rotate(0, tempX * rotateSpeed, 0);
        //Debug.Log(tempX);


	}
}
