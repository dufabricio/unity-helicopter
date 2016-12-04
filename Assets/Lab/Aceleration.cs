using UnityEngine;
using System.Collections;
using System;

public class Aceleration : MonoBehaviour {

    public float aceleration;

    // Use this for initialization
    void Start () {
        aceleration = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("d"))
        {
            aceleration += .3F;
        }else
        {
            if(aceleration > 0)
            {
                aceleration -= .1F;
            }
        }
        if (Input.GetKey("a"))
        {
            aceleration -= .3F;
        }else
        {
            if (aceleration < 0)
            {
                aceleration += .1F;
            }
        }

        //iTween.MoveTo(gameObject, iTween.Hash("x", endValue, "easeType", "easeInOutExpo", "delay", .1, "time", 3));
        this.transform.Translate(aceleration, 0, 0);
    }

}
