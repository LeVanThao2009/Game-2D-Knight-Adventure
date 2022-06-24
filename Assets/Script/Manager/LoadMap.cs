using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMap : MonoBehaviour
{
    public string nameScene;
   
    // Update is called once per frame
    void Update()
    {

    }
    public void Click()
    {
        SceneManager.LoadScene(nameScene);
    }
    
}
