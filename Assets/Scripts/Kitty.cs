using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitty : MonoBehaviour {

    public static Kitty current;
    public GameObject flower;

    public Rigidbody2D myBody = null;
    public float speed = 2;
    public bool isGrounded = false;
    float JumpTime = 0f;
    public float MaxJumpTime = 0f;
    public float JumpSpeed = 0f;

    public Transform groundPrefab;

    void Awake()
    {
        current = this;
    }

    // Use this for initialization
    void Start () {
        myBody = this.GetComponent<Rigidbody2D>();
        LevelController.current.setStartPosition(transform.position);

        //Physics.IgnoreCollision(groundPrefab.GetComponent<Collider>(), GetComponent<Collider>());
    }
	
	// Update is called once per frame
	void Update () {
        float value = Input.GetAxis("Horizontal");

        if (Mathf.Abs(value) > 0)
        {
            Vector2 vel = myBody.velocity;
            vel.x = value * speed;
            myBody.velocity = vel;
        }

        Vector3 from = transform.position + Vector3.up;// * 0.03f;
        Vector3 to = transform.position + Vector3.down;//* 0.01f;
        Debug.DrawLine(from, to);
        int layer_id = 1 << LayerMask.NameToLayer("Ground");
        RaycastHit2D hit = Physics2D.Linecast(from, to, layer_id);
        if (hit)
            isGrounded = true;
        else
            isGrounded = false;

        if (isGrounded)
        {
            this.JumpTime += Time.deltaTime;
            if (this.JumpTime < this.MaxJumpTime)
            {
                Vector2 vel = myBody.velocity;
                vel.y = JumpSpeed * (1.0f - JumpTime / MaxJumpTime);
                myBody.velocity = vel;
            }
        }

        if (Input.GetKeyDown("space")){
            GameObject obj = GameObject.Instantiate(this.flower);
            //Розміщуємо в просторі
            obj.transform.position = this.transform.position;
            //Запускаємо в рух
            Bullet bullet = obj.GetComponent<Bullet>();
        }
    }
}
