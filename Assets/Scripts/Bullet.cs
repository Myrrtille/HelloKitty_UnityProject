using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 0.005f;

    // Use this for initialization
    void Start () {
        StartCoroutine(destroyLater());
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = this.transform.position;
        pos.y += Time.deltaTime +  1* 0.05f;
        this.transform.position = pos;
    }

    IEnumerator destroyLater()
    {
        yield return new WaitForSeconds(4.0f);
        Destroy(this.gameObject);
    }

    void onMonsterHit(FlyingMonster monster)
    {
        monster.die();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("hit");
        //int layer_id = 1 << LayerMask.NameToLayer("Monster");
        FlyingMonster monster = collider.GetComponent<FlyingMonster>();
        if (monster != null)
        {
            onMonsterHit(monster);
        }
    }
}
