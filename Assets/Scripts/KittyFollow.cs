using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittyFollow : MonoBehaviour {

    public Kitty kitty;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Transform kitty_transform = kitty.transform;
        Transform camera_transform = this.transform;
        Vector3 kitty_position = kitty_transform.position;
        Vector3 camera_position = camera_transform.position;
        //camera_position.x = kitty_position.x;
        camera_position.y = kitty_position.y;
        camera_transform.position = camera_position;
    }
}
