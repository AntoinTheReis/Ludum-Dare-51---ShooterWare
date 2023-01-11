using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHandler : MonoBehaviour
{

    public Rigidbody2D theRB;
    private Camera theCam;
    public float cooldown;
    public float lastShot;
    public GameObject bulletToFire;
    public Transform firePoint;
    public int maxHealth = 3;
    public int currentHealth;
    [SerializeField] public float speed = 2f;
    Vector3 ScreenPosition;
    Vector3 mouse;
    Vector2 offset;
    public double initialTime1 = 10;
    public double initialTime2 = 5;
    public double currentTime;
    [SerializeField] public bool playing = true;
    private bool countingDown = false;
    int prevHealth;

    public AudioSource shoot;
    public AudioSource damage;
    public AudioSource health;


    void Start()
    {
        theCam = Camera.main;
        currentHealth = maxHealth;
        currentTime = initialTime1;
        prevHealth = currentHealth;
    }

    
    void Update()
    {

        if(currentHealth < prevHealth)
        {
            damage.Play();
            prevHealth = currentHealth;
        }

        theRB.angularVelocity = 0;

        if (currentHealth < 1)
        {
            SceneManager.LoadScene(2);
        }

        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }

        if (currentTime < 0)
        {
            playing = !playing;
            if (playing)
            {
                currentTime = initialTime1;
            }
            else
            {
                currentTime = initialTime2;
            }
        }

        if (playing)
        {
            if(currentTime <= 9 && currentTime > 6)
            {
                countingDown = false;
            }

            theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed;

            Vector3 ScreenPoint = theCam.WorldToScreenPoint(transform.localPosition);
            Vector3 mouse = Input.mousePosition;
            Vector2 offset = new Vector2(mouse.x - ScreenPoint.x, mouse.y - ScreenPoint.y);

            float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);

            if (Input.GetMouseButtonDown(0))
            {
                if (Time.time - lastShot < cooldown)
                {
                    return;
                }
                else
                {
                    Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
                    shoot.Play();
                }
            }

            Vector3 minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
            Vector3 maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minScreenBounds.x + 1, maxScreenBounds.x - 1), Mathf.Clamp(transform.position.y, minScreenBounds.y + 1, maxScreenBounds.y - 1), transform.position.z);
        }
        else
        {
            theRB.velocity = new Vector2(0, 0);
            Vector3 minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
            Vector3 maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            currentHealth--;
            Debug.Log("Player Health" + currentHealth);
        }

        if (collision.tag == "heal")
        {
            health.Play();
            if (currentHealth < 3)
            {
                currentHealth++;
                Debug.Log("health recovered!");
            }
            else
            {
                Debug.Log("health was full!");
            }
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "bomb" && !countingDown)
        {
            currentHealth--;
            Debug.Log("Player Health" + currentHealth);
            countingDown = true;
        }
    }

}
