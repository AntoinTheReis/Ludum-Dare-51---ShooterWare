using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BombEvent : MonoBehaviour
{

    bool dropped = false;

    public double initialTime = 5;
    public double currentTime;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = initialTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            if (!dropped)
            {
                SceneManager.LoadScene(1);
            }
        }
        if (currentTime < -.02)
        {
            Object.Destroy(this.gameObject);
        }

        if (Input.GetMouseButtonDown(0))
        {
            dropped = true;
            gameObject.tag = "bomb";
        }

            if (!dropped)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
            transform.position = mousePosition;
        }
    }
}
