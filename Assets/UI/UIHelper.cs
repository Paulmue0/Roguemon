using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

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

    public string getRoguemonName(GameObject roguemon){
        return roguemon.name;
    }
    public string getMoveName(GameObject roguemon, int i){
        return roguemon.name;
    }

    public string getXValueOfButton(Button button){
        Debug.Log(button.transform.ToString());
        return button.transform.position.ToString();

     
    }
    
}
