using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger: MonoBehaviour
{
    public string SampleScene;  

    void Update()
    {
        if (Input.anyKeyDown)  
        {
            SceneManager.LoadScene("SampleScene"); 
        }
    }
}
