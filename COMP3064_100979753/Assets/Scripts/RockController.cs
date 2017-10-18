using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour {

    private Transform _transform;
    private Vector2 _currentSpeed;
    private Vector2 _currentPos;

    public GameObject Explosion;

    public int score;
    public GameController gameController;

    //Source Lab
    // Use this for initialization
    void Start () {        
        _transform = gameObject.GetComponent<Transform>();
        Reset();
    }
	
	// Update is called once per frame
	void Update () {
        _currentPos = _transform.position;
        _currentPos -= _currentSpeed;

        _transform.position = _currentPos;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); //Get the bottom-left screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); //Get the top-right screen
        if (_currentPos.x < min.x || _currentPos.y < min.y || _currentPos.x > max.x || _currentPos.y > max.y)
        {
            Reset(); //Respawn if rock is outside of the screen
        }
    }

    //Respawn the rock. Rock can float up, down and left 
    void Reset()
    {
        float horizontalSpeed = Random.Range(2f * Time.deltaTime, 3f * Time.deltaTime);
        float verticalSpeed = Random.Range(-3f * Time.deltaTime, 3f * Time.deltaTime);
        
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        _currentSpeed = new Vector2(horizontalSpeed, verticalSpeed);
        float y = Random.Range(-1f, 1f);
        _transform.position = new Vector2(max.x, y);
    }


    //Source Unity - 2D Space Shooter Tutorial Part 6 - Explosion Animation and Collision Detection - https://www.youtube.com/watch?v=iTHEXMF0hpc&index=6&list=PLRN2Qvxmju0Mf1GB1hXsT-x1GQJQ0pwE0
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerTag" || collision.tag == "PlayerBulletTag")
        {
            Explode();
            gameController.AddScore(1); //add score
            GetComponent<AudioSource>().Play();//play the explosion sound
            Reset(); //respawn the rock
        }
    }

    void Explode()
    {
        //display explosion when collided
        GameObject explosion = Instantiate(Explosion);
        explosion.transform.position = transform.position;
    }
}
