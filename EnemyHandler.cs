using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float inHealth = 10f;
    [SerializeField] float health;
    [SerializeField] float moveSpeed = 5f;

    public GameObject playerObject;
    public Transform player;
    private Rigidbody2D rb;
    public AudioSource damage;
    private Vector2 movement;
    private bool playing;
    private double time;
    private bool countingDown = false;
    PlayerHandler playerHandler;


    void Start()
    {
        health = inHealth;
        rb = GetComponent<Rigidbody2D>();
        playerObject = GameObject.FindGameObjectWithTag("Player");

        player = playerObject.transform;
        playerHandler = playerObject.GetComponent<PlayerHandler>();
        playing = playerHandler.playing;
        time = playerHandler.currentTime;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


        rb.rotation = angle;
        direction.Normalize();
        movement = direction;

        playing = playerHandler.playing;

        if (playing && health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)(transform.position) + (direction * moveSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            health -= 1;
        }

        if(collision.tag == "bomb")
        {
            Debug.Log("enemy in bomb");
        }

        if (health < 1)
        {
            Destroy(gameObject);
        }
        
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "bomb" && !countingDown)
        {
            health -= 4;
            Debug.Log(health);
            countingDown = true;
        }
    }

    private void FixedUpdate()
    {
        if (playing)
        {
            if(time <= 7 && time > 6)
            {
                countingDown = false;
            }
            moveCharacter(movement);
        }
    }

}

