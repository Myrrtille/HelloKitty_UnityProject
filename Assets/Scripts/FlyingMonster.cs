using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMonster : MonoBehaviour {

    public static FlyingMonster current;

    public enum Mode
    {
        GoToA,
        GoToB,
        Dead,
        Attack
    }

    Mode mode = Mode.GoToB;
    Rigidbody2D myBody = null;
    public float movingDist = 14;
    public float speed = 2;

    Vector3 scale_speed;
    Vector3 targetScale = Vector3.one;

    Vector3 pointA;
    Vector3 pointB;

    // Use this for initialization
    void Start () {
        pointA = this.transform.position;
        pointB = pointA;
        pointB.x += movingDist;

        myBody = this.GetComponent<Rigidbody2D>();
        //LevelController.current.setStartPosition(this.transform.position);
    }

    float getDirection()
    {
        Vector3 my_pos = this.transform.position;
        Vector3 kitty_pos = Kitty.current.transform.position;

        //attack{}

        //move to kitty
        if(kitty_pos.y > my_pos.y-2 && kitty_pos.y < my_pos.y + 2)
        {
            if (my_pos.x < kitty_pos.x) return 1;
            else return -1;
        }

        if (this.mode == Mode.GoToA)
        {
            if (my_pos.x <= pointA.x) this.mode = Mode.GoToB;
        }
        else if (this.mode == Mode.GoToB)
        {
            if (my_pos.x >= pointB.x) this.mode = Mode.GoToA;
        }

        //get new direction
        if (this.mode == Mode.GoToA)
        {
            if (my_pos.x <= pointA.x) return 1;
            else return -1;
        }
        else if (this.mode == Mode.GoToB)
        {
            if (my_pos.x <= pointB.x) return 1;
            else return -1;
        }

        return 0;
    }

    // Update is called once per frame
    void Update () {
        float value = this.getDirection();
        if (Mathf.Abs(value) > 0)
        {
            Vector2 vel = myBody.velocity;
            vel.x = value * speed;
            myBody.velocity = vel;
        }

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (value < 0) sr.flipX = true;
        else if (value > 0) sr.flipX = false;

        this.transform.localScale = Vector3.SmoothDamp(this.transform.localScale, this.targetScale, ref scale_speed, 1.0f);
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.layer != LayerMask.NameToLayer("Kitty"))
            return;

        if (false)//kitty kill monster (shoot flower?)
        {
            //StartCoroutine(monsterDie());
        }
        else
        {
            //callAttack();
            LevelController.current.onKittyDeath(Kitty.current);
        }
    }

    public void die()
    {
        Destroy(this.gameObject);
    }
}
