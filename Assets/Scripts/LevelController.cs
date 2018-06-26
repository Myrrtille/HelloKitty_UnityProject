using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {

    public static LevelController current;

    int flowers = 0;
    int candies = 0;
    public int total_amount_of_candies = 0;

    public Text flowers_counter;
    public Text candies_counter;

    // Use this for initialization
    void Start () {
        candies_counter.text = candies + "/" + total_amount_of_candies;
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

    public void onKittyDeath(Kitty kitty)
    {
        kitty.transform.position = this.startingPosition;
    }

    public void addFlower()
    {
        flowers++;
        flowers_counter.text = ""+flowers;
    }

    public void removeFlower()
    {
        flowers--;
        flowers_counter.text = "" + flowers;
    }

    public int amountOfFlowers() { return flowers; }

    public void addCandy()
    {
        candies++;
        candies_counter.text = candies + "/" + total_amount_of_candies;
    }
}
