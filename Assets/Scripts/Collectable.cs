using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    protected virtual void OnKittyHit(Kitty kitty)
    {
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Kitty kitty = collider.GetComponent<Kitty>();
        if (kitty != null)
            this.OnKittyHit(kitty);
    }

    public void CollectedHide()
    {
        Destroy(this.gameObject);
    }
}

