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
        if (collider.gameObject.layer == LayerMask.NameToLayer("Kitty") && !Kitty.current.isGrounded)
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Kitty.current.GetComponent<Collider2D>(), true);
    }

    void onTriggerExit(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Kitty"))
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Kitty.current.GetComponent<Collider2D>(), false);
    }
}
