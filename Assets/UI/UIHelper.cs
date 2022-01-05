using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHelper : MonoBehaviour
{

    void switchToScene(string scene){
        try
        {
            SceneManager.LoadScene(scene); 
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}
