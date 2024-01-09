using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ExitApp()
    {
        Application.Quit();
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(0);
    }
}
