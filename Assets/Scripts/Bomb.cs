using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Collectable {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void OnKittyHit(Kitty kitty)
    {
        Kitty.current.removeHealth();
        CollectedHide();
    }
}
