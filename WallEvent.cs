using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallEvent : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] wallsVertical;
    public GameObject[] wallsHorizontal;
    public Transform[] leftSide;
    public Transform[] rightSide;

    int side;
    int topOrBottom;
    int horVert;

    void Start()
    {
        side = Random.Range(0, 2);
        topOrBottom = Random.Range(0, 2);
        horVert = Random.Range(0, 2);


        if (topOrBottom == 0)
        {
            if(side == 0)
            {
                if(horVert == 0)
                {
                    Instantiate(wallsHorizontal[0], leftSide[0].position, transform.rotation);
                }
                else
                {
                    Instantiate(wallsVertical[0], leftSide[0].position, transform.rotation);
                }
            }
            else
            {
                if (horVert == 0)
                {
                    Instantiate(wallsHorizontal[0], rightSide[0].position, transform.rotation);
                }
                else
                {
                    Instantiate(wallsVertical[1], rightSide[0].position, transform.rotation);
                }
            }
        }
        else
        {
            if (side == 0)
            {
                if (horVert == 0)
                {
                    Instantiate(wallsHorizontal[1], leftSide[1].position, transform.rotation);
                }
                else
                {
                    Instantiate(wallsVertical[0], leftSide[1].position, transform.rotation);
                }
            }
            else
            {
                if (horVert == 0)
                {
                    Instantiate(wallsHorizontal[1], rightSide[1].position, transform.rotation);
                }
                else
                {
                    Instantiate(wallsVertical[1], rightSide[1].position, transform.rotation);
                }
            }
        }

        Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
