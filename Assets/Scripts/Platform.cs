using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void onTriggerEnter(Collider collider)
    {
        if(Kitty.current == collider)
        {
            Debug.Log("coll enter");
            if (!Kitty.current.isGrounded)
            {
                Physics.IgnoreCollision(GetComponent<Collider>(), collider, true);
            }
        }
    }

    void onTriggerExit(Collider collider)
    {
        if(Kitty.current == collider)
        {
            Debug.Log("coll exit");
            Physics.IgnoreCollision(GetComponent<Collider>(), collider, false);
        }
    }
}
