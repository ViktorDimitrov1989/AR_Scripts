using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    public void CollectObject(GameObject magnetSurface)
    {

        foreach (SelectObjectScript item in GameObject.FindObjectsOfType<SelectObjectScript>())
        {
            if (item.IsSelected)
            {
                item.GetComponent<SortingMagnet>().enabled = true;
                item.GetComponent<SortingMagnet>().target = magnetSurface.transform;
            }
            else
            {
                item.gameObject.GetComponent<SortingMagnet>().enabled = false;
            }

        }
    }


}
