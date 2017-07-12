using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothlyScale : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
   
 
    void Update()
    {
        Vector3 newScale = new Vector3(1, 1, 5);
        float speed = 2.0f;

        transform.localScale = Vector3.Lerp(transform.localScale, newScale, speed * Time.deltaTime);
    }
}
