using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//Source: Unity - 2D Space Shooter Tutorial Part 2 - Player Input Movement - https://www.youtube.com/watch?v=Om00FwLg-eg

public class PlayerController : MonoBehaviour {

    public GameObject PlayerBullet;
    public GameObject BulletPos1;
    public GameObject BulletPos2;
    public GameObject Explosion;
    public float speed = 5f;

    [SerializeField]
    GameController gameController;

    [SerializeField]
    Text scoreText;

    public Text LifeText;
    const int maxLives = 3;
    int remainingLives;

    // Use this for initialization
    void Start ()
    {
        remainingLives = maxLives;
        LifeText.text = remainingLives.ToString();
        gameObject.SetActive(true);        
    }
	
	// Update is called once per frame
	void Update ()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(x, y).normalized;
        Move(movement);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Shot", 0, 0.5f); //Repeat shot action every 0.5s when press space
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Shot"); //Cancel shot action when release space
        }
    }

    void Move(Vector2 movement)
    {
        //Get the screen limit
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //set the screen limit
        max.x = max.x - 1f;
        min.x = min.x + 1f;
        max.y = max.y - 1f;
        min.y = min.y + 1f;

        //Current position
        Vector2 pos = transform.position;
        pos += movement * speed * Time.deltaTime;

        //Restrict the position is not outside of the screen
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        //Update the position
        transform.position = pos;
    }

    void Shot()
    {
        //Set the position of the first bullet
        GameObject bullet1 = Instantiate(PlayerBullet);
        bullet1.transform.position = BulletPos1.transform.position;

        //Set the position of the second bullet
        GameObject bullet2 = Instantiate(PlayerBullet);
        bullet2.transform.position = BulletPos2.transform.position;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //trigger when collide with enemy
        if (collision.tag == "EnemyTag")
        {
            remainingLives--;
            LifeText.text = remainingLives.ToString();

            if(remainingLives == 0)
            {
                Explode();
                SceneManager.LoadScene("Win");
            }
        }
        
    }

    void Explode()
    {
        //display explosion when colliding
        GameObject explosion = Instantiate(Explosion);
        explosion.transform.position = transform.position;
    }
}
