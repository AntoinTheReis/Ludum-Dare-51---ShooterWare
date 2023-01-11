using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEvent : MonoBehaviour
{

    Vector2 difference = Vector2.zero;
    int totalTime = 5;
    double currentTime;

    public AudioSource gotHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = totalTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if( currentTime <=0)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)(transform.position);
    }
    private void OnMouseDrag()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(gameObject);
            Debug.Log("health destroyed");
        }
        if(collision.tag == "Player")
        {
            Destroy(gameObject);
            gotHealth.Play();
        }
    }
}
