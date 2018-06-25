using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPath : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Kitty"))
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Kitty.current.GetComponent<Collider2D>(), true);
    }
}
