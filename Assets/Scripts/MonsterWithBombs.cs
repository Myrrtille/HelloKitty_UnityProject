using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWithBombs : Monster {

    Rigidbody2D myBody = null;

    bool attack = false;

    Vector3 scale_speed;
    Vector3 targetScale = Vector3.one;

    public GameObject bomb;
    

    // Use this for initialization
    void Start () {
        myBody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 my_pos = this.transform.position;
        Vector3 kitty_pos = Kitty.current.transform.position;

        if (kitty_pos.y < my_pos.y && kitty_pos.y > my_pos.y - 5)
            attack = true;
        else attack = false;

        if (attack)
            dropBomb();


        this.transform.localScale = Vector3.SmoothDamp(this.transform.localScale, this.targetScale, ref scale_speed, 1.0f);
    }

    protected override void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.layer != LayerMask.NameToLayer("Kitty"))
            return;

        if (collider.transform.position.y > this.transform.position.y + 1.2)//kitty kill monster (shoot flower?)
        {
            Vector2 vel = Kitty.current.myBody.velocity;
            vel.y = Kitty.current.jumpHeight;
            Kitty.current.myBody.velocity = vel;
            die();
        }
        else
        {
            //callAttack();
            Kitty.current.removeHealth();
            LevelController.current.onKittyDeath(Kitty.current);
        }
    }

    float last_bomb = 0;

    void dropBomb()
    {
        if (Time.time - last_bomb > 2.0f)
        {
            this.last_bomb = Time.time;
            GameObject obj = GameObject.Instantiate(this.bomb);
            obj.transform.position = this.transform.position;
            MonsterBomb b = obj.GetComponent<MonsterBomb>();
        }
    }
}
