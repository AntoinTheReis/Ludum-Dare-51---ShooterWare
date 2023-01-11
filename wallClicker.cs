using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallClicker : MonoBehaviour
{

    [SerializeField] public GameObject wall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Instantiate(wall, Vector2.zero, transform.rotation);
        }
    }
}
