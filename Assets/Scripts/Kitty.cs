using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Kitty : MonoBehaviour {

    public static Kitty current;
    public GameObject flower;

    public Image life1;
    public Image life2;
    public Image life3;

    public Rigidbody2D myBody = null;
    public float speed = 2;
    public bool isGrounded = false;
    //float JumpTime = 0f;
    //public float MaxJumpTime = 0f;
    //public float JumpSpeed = 0f;
    public float jumpHeight = 20;

    public Transform groundPrefab;

    int health = 3;

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

        if (isGrounded)
        {
            Vector2 vel = myBody.velocity;
            vel.y = jumpHeight;
            myBody.velocity = vel;
        }

        Vector3 from = transform.position + Vector3.up * 0.2f;// * 0.03f;
        Vector3 to = transform.position + Vector3.down * 0.6f;//* 0.01f;
        Debug.DrawLine(from, to);
        int layer_id = 1 << LayerMask.NameToLayer("Ground");
        RaycastHit2D hit = Physics2D.Linecast(from, to, layer_id);
        if (hit)
            isGrounded = true;
        else
            isGrounded = false;

        if (Input.GetKeyDown("space")){
            if(LevelController.current.amountOfFlowers() !=0)
            {
                GameObject obj = GameObject.Instantiate(this.flower);
                //Розміщуємо в просторі
                obj.transform.position = this.transform.position;
                //Запускаємо в рух
                Bullet bullet = obj.GetComponent<Bullet>();
                LevelController.current.removeFlower();
            }
        }
    }

    public void removeHealth()
    {
        if (!isDead())
        {
            health--;
            if (health == 2)
                life3.enabled = false;
            else if (health == 1)
                life2.enabled = false;
            else if (health == 0)
                life1.enabled = false;
        }
        else
        {
            SceneManager.LoadScene("gameplay");
        }

        LevelController.current.onKittyDeath(current);
    }

    public bool isDead() { return health == 0; }

    public void addHealth()
    {
        if (health == 2)
            life3.enabled = true;
        else if (health == 1)
            life2.enabled = true;
        else if (health == 0)
            life1.enabled = true;
        if (health < 3)
            health++;
    }

}
