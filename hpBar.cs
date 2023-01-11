using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpBar : MonoBehaviour
{

    Image current;
    public Sprite threeHp;
    public Sprite twoHp;
    public Sprite oneHp;

    public GameObject playerObject;
    PlayerHandler playerHandler;
    int health;

    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        playerHandler = playerObject.GetComponent<PlayerHandler>();
        health = playerHandler.currentHealth; 

        current = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        health = playerHandler.currentHealth;

        if (health == 3)
        {
            current.sprite = threeHp;
        }
        else if(health == 2)
        {
            current.sprite = twoHp;
        }
        else
        {
            current.sprite = oneHp;
        }
    }
}
