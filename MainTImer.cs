using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainTImer : MonoBehaviour
{

    public Text txt;
    public double initialTime1 = 10;
    public double initialTime2 = 5;
    public double currentTime;
    [SerializeField] public bool playing = true;

    public GameObject[] wareEvents;
    public Transform[] spawnPoints;


    // Start is called before the first frame update
    void Start()
    {
        currentTime = initialTime1;
    }

    // Update is called once per frame
    void Update()
    {

        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }


        txt.text = (((int)currentTime)+1).ToString();

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

                int randEvent = Random.Range(0, wareEvents.Length);
                int randSpawn = Random.Range(0, spawnPoints.Length);
                
                if(randEvent == 1)
                {
                    Instantiate(wareEvents[randEvent], spawnPoints[randSpawn].position, transform.rotation);
                }
                else
                {
                    Instantiate(wareEvents[randEvent]);
                }
            }
        }
    }
}
