using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DefendEarth()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void DefendOutpost()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}
