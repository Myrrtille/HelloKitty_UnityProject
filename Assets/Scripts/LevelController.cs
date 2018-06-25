using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    public static LevelController current;

    // Use this for initialization
    void Start () {
		
	}

    void Awake()
    {
        current = this;
    }

	// Update is called once per frame
	void Update () {
		
	}

    Vector3 startingPosition;

    public void setStartPosition(Vector3 pos)
    {
        this.startingPosition = pos;
    }

    public void onKittyDeath(Kitty rabit)
    {
        Debug.Log("die");
        rabit.transform.position = this.startingPosition;
    }
}
