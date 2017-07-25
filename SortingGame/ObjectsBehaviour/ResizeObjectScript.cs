using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeObjectScript : MonoBehaviour {
    public bool isShrinking = false;
    public bool isGrowing = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isGrowing && isShrinking)
        {
            isShrinking = false;
        }

        if (isGrowing)
        {
            Grow(gameObject, gameObject.transform.localScale, new Vector3(0.17f, 0.17f, 0.17f));
        }

        if (isShrinking)
        {
            Shrink(gameObject,gameObject.transform.localScale, new Vector3(0.07f, 0.07f, 0.07f));
        }
	}


    public bool IsShrinking {
        get {
            return isShrinking;
        }
        set {
            isShrinking = value;
        }
    }

    public bool IsGrowing
    {
        get
        {
            return isGrowing;
        }
        set
        {
            isGrowing = value;
        }
    }


    private void Grow(GameObject target, Vector3 startScale, Vector3 endScale)
    {

        target.transform.localScale = Vector3.Lerp(startScale, endScale, 3.0f * Time.deltaTime);

        if (Mathf.Abs(endScale.x - target.transform.localScale.x) < 0.005)
        {
            Debug.Log("Grow ends");
            target.transform.localScale = endScale;
            IsGrowing = false;
        }

    }

    private void Shrink(GameObject target, Vector3 startScale, Vector3 endScale)
    {

        target.transform.localScale = Vector3.Lerp(startScale, endScale, 2.0f * Time.deltaTime);

        if (Mathf.Abs(endScale.x - target.transform.localScale.x) < 0.005)
        {
            Debug.Log("Shrink ends");
            target.transform.localScale = endScale;
            isShrinking = false;
        }

    }

}
