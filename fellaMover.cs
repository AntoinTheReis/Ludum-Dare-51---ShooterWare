using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fellaMover : MonoBehaviour
{

    public Rigidbody2D theRB;
    private Camera theCam;
    public float speed;

    public double initialTime = 5;
    public double currentTime;

    public GameObject maze;

    public GameObject playerObject;
    PlayerHandler playerHandler;
    int health;

    // Start is called before the first frame update
    void Start()
    {
        theCam = Camera.main;
        currentTime = initialTime;

        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerHandler = playerObject.GetComponent<PlayerHandler>();
        health = playerHandler.currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed;

        Vector3 minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        currentTime -= Time.deltaTime;

        if(currentTime <= 0)
        {
            if(transform.position.x < 14.91)
            {
                playerHandler.currentHealth--;
                Debug.Log("didn't reach the end");
            }
            Destroy(maze);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "labyrinth")
        {
            playerHandler.currentHealth--;
            Debug.Log("hit the wall");
        }
    }
}
