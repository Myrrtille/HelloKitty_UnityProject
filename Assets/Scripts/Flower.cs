using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : Collectable {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
       /* if(GetComponent<BoxCollider2D>().transform.eulerAngles.z == 360)
            GetComponent<BoxCollider2D>().transform.Rotate(0, 0, 0);
        else GetComponent<BoxCollider2D>().transform.Rotate(0, 0, 10);*/
    }

    protected override void OnKittyHit(Kitty kitty)
    {
        LevelController.current.addFlower();
        CollectedHide();

    }

    IEnumerator createNew()
    {
        yield return new WaitForSeconds(9.0f);
        
    }
}
