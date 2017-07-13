using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LessonController : MonoBehaviour {
    public int yearsToCheckCount;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Years to check: " + yearsToCheckCount);

        if (yearsToCheckCount == 0)
        {
            Debug.Log("Reset position count is 0");
            Debug.Log("and result is: " + checkSpheres());
        }

	}

    void resetPositions()
    {
        
    }

    bool checkSpheres()
    {
        PowerUp[] myItems = FindObjectsOfType(typeof(PowerUp)) as PowerUp[];

        foreach (PowerUp sphere in myItems)
        {
            foreach (GameObject year in sphere.getYearsToCheck())
            {
                if (sphere.year != year.GetComponent<Magnet>().Year)
                {
                    return false;
                }
            }
        }

        return true;
    }
}
