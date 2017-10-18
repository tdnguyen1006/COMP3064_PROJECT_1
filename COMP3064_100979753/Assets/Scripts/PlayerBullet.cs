using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Source Unity - 2D Space Shooter Tutorial Part 3 - Player Bullet and Player Shooting - https://www.youtube.com/watch?v=2WlY0dL5Qrg

public class PlayerBullet : MonoBehaviour {

    public float speed;
	// Use this for initialization
	void Start () {
        speed = 5f;
	}
	
	// Update is called once per frame
	void Update () {

        //Set the bullet movement
        Vector2 pos = transform.position;
        pos = new Vector2(pos.x + speed * Time.deltaTime, pos.y);
        transform.position = pos;

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //If the bullets go out of the screen, it's destroyed automatically
        if(transform.position.x > max.x)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyTag")
        {
            Destroy(gameObject); //Destroy the bullet when hit the rock
        }
    }
}
