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

    public void switchMoveDescription(string moveDescription, Label label){
        if(moveDescription != null){
            if(label.text != "")
                        label.text = "";
                    else
                        label.text = moveDescription;
        }
        
    }

    public void setAllMoveDescriptors(List<Label> moveDescriptors, List<GameObject> moves){
        if(moveDescriptors != null && moves != null){
            int i = 0;
            foreach(GameObject move in moves){   
                moveDescriptors[i].text = move.GetComponent<Move_Behaviour>().Get_Move_Description();
                i ++;
            }
        }
        
    }

    public void setAllAttackButtons(List<Button> attackButtons, List<GameObject> moves){
        if (attackButtons != null && moves != null){
            int i = 0;
            foreach(GameObject move in moves){
                attackButtons[i].text = move.name;
                i++;
            }

        }

    }

    
}
