using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    // Start is called before the first frame update

    public int sceneToChangeTo;
    public AudioSource buttonPress;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToScene(int sceneToChangeTo)
    {
        press();
        SceneManager.LoadScene(sceneToChangeTo);
    }

    public void leaveGame()
    {
        press();
        Application.Quit();
    }

    public void press()
    {
        buttonPress.Play();
    }

}
