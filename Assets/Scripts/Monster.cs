using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    // Use this for initialization
    void Start()
    {}
    
    void Update()
    {}

    protected virtual void OnCollisionEnter2D(Collision2D collider)
    {
    }

    public void die()
    {
        Destroy(this.gameObject);
    }
}
