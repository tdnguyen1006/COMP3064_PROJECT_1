using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {
    private Transform _transform;
    private Vector2 _currentSpeed;
    private Vector2 _currentPos;

    public int score;
    public GameController gameController;

    //Source Lab
    // Use this for initialization
    void Start()
    {
        _transform = gameObject.GetComponent<Transform>();
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        _currentPos = _transform.position;
        _currentPos -= _currentSpeed;

        _transform.position = _currentPos;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); //Get the bottom-left screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); //Get the top-right screen
        if (_currentPos.x < min.x || _currentPos.y < min.y || _currentPos.x > max.x || _currentPos.y > max.y)
        {
            Reset(); //Respawn if object is outside of the screen
        }
    }

    //Respawn the rock. Object can float up, down and left 
    void Reset()
    {
        float verticalSpeed = Random.Range(-2f * Time.deltaTime, 2f * Time.deltaTime);

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        _currentSpeed = new Vector2(2f * Time.deltaTime, verticalSpeed);
        float y = Random.Range(-1f, 1f);
        _transform.position = new Vector2(max.x, y);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerTag")
        {
            Reset(); //Reset the coin after picking up
            GetComponent<AudioSource>().Play(); //Sound Play
            gameController.AddScore(5); //Add score
        }
    }
}
