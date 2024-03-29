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

    public void switchMoveDescription(Label label){
            if (label.style.display == DisplayStyle.Flex)
                label.style.display = DisplayStyle.None;
            else
                label.style.display = DisplayStyle.Flex;
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
    // Sets all attack Buttons; If roguemon is not the active one the attack buttons wont be clickable;
    public void setAllAttackButtons(List<Button> attackButtons, List<GameObject> moves, bool isActive){
        if (attackButtons != null && moves != null){
            int i = 0;
            foreach(GameObject move in moves){
                attackButtons[i].text = move.name;
                attackButtons[i].style.backgroundColor = Color.grey;
                i++;
            }

        }

    }

    // changes the dialog text
    public void setDialogWindowText(Label dialogLabel, string dialogText){
        dialogLabel.text = dialogText;
    }
}
