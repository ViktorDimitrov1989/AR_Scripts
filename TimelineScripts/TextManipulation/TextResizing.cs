using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextResizing : MonoBehaviour {
    public float maxSize = 0.09f;
    public float minSize = 0.00f;
    public float speed = 1.0f;

    void Update()
    {
        var range = maxSize - minSize;
        transform.localScale = new Vector3((float)((Mathf.Sin(Time.time * speed) + 1.0) / 2.0 * range + minSize), (float)((Mathf.Sin(Time.time * speed) + 1.0) / 2.0 * range + minSize), (float)((Mathf.Sin(Time.time * speed) + 1.0) / 2.0 * range + minSize));

        //todo set the position to be at the center all the time
    }

}
