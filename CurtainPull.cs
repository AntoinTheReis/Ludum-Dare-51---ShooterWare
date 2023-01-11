using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainPull : MonoBehaviour
{

    public GameObject playerObject;
    PlayerHandler playerHandler;
    private bool playing;

    // Start is called before the first frame update
    void Start()
    {
        playerHandler = playerObject.GetComponent<PlayerHandler>();
        playing = playerHandler.playing;
    }

    // Update is called once per frame
    void Update()
    {
        playing = playerHandler.playing;

        if (!playing)
        {
            GetComponent<Renderer>().enabled = true;
        }
        else
        {
            GetComponent<Renderer>().enabled = false;
        }

    }
}
