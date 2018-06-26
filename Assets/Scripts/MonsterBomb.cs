using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBomb : MonoBehaviour {

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = this.transform.position;
        pos.y -= Time.deltaTime + 1 * 0.05f;
        this.transform.position = pos;
    }

    IEnumerator destroyLater()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(this.gameObject);
    }

    void onKittyHit(Kitty kitty)
    {
        kitty.removeHealth();
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Kitty kitty = collider.GetComponent<Kitty>();
        if (kitty != null)
        {
            onKittyHit(kitty);
            return;
        }
        else StartCoroutine(destroyLater());
    }
}
