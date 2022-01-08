using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class BattleUIController : UIController
{

    public UIHelper helper;
    public Roguemon_Behaviour roguemon_behaviour;
    public Battle_Manager battleManager;
    public GameObject selectedRoguemon;
    public List<GameObject> movesOfSelectedRoguemon; 
    public List<Label> MoveDescriptors;
    public List<Button> AttackButtons;
    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        
        MoveDescriptors = new List<Label>();
        AttackButtons = new List<Button>();
        //selectedRoguemon = battleManager.Get_Roguemon(0);
        

        // Define the 3 RogueButtons from your team
        roguemonButton_0 = root.Q<Button>("mon-1");
        roguemonButton_1 = root.Q<Button>("mon-2");
        roguemonButton_2 = root.Q<Button>("mon-3");

        // Define the 3 RogueButtons from enemy trainer team
        roguemonButton_3 = root.Q<Button>("mon-3");
        roguemonButton_4 = root.Q<Button>("mon-4");
        roguemonButton_5 = root.Q<Button>("mon-5");

        // Define dialogLabel
        dialogLabel = root.Q<Label>("DialogLabel");

        // Define Components for Attack 1
        att_1_button = root.Q<Button>("att-1-button");
        //att_1_button.text = movesOfSelectedRoguemon[0].name;
        switch_move_description_1 = root.Q<Button>("switch-move-description-1");

        att_1_description_label = root.Q<Label>("att-1-description-label");
        //att_1_description_label.text = movesOfSelectedRoguemon[0].GetComponent<Move_Behaviour>().Get_Move_Description();

        // Define Components for Attack 2
        att_2_button = root.Q<Button>("att-2-button");
        switch_move_description_2 = root.Q<Button>("switch-move-description-2");
        att_2_description_label = root.Q<Label>("att-2-description-label");

        // Define Components for Attack 3
        att_3_button = root.Q<Button>("att-3-button");
        switch_move_description_3 = root.Q<Button>("switch-move-description-3");
        att_3_description_label = root.Q<Label>("att-3-description-label");

        // Define Components for Attack 4
        att_4_button = root.Q<Button>("att-4-button");
        switch_move_description_4 = root.Q<Button>("switch-move-description-4");
        att_4_description_label = root.Q<Label>("att-4-description-label");
    	
        // Define List of Move Descriptors for dynamical linking to UIHelper
        MoveDescriptors.Add(att_1_description_label);
        MoveDescriptors.Add(att_2_description_label);
        MoveDescriptors.Add(att_3_description_label);
        MoveDescriptors.Add(att_4_description_label);

        // Define List of Attack Buttons for dynamical linking to UIHelper
        AttackButtons.Add(att_1_button);
        AttackButtons.Add(att_2_button);
        AttackButtons.Add(att_3_button);
        AttackButtons.Add(att_4_button);


        

        /* 
        BUTTON EVENTS
        */

        
        if(att_4_button != null)
           att_4_button.clicked += () => {
                selectedRoguemon = battleManager.Get_Roguemon(0);
                movesOfSelectedRoguemon = selectedRoguemon.GetComponent<Roguemon_Behaviour>().Get_Moves();
                Debug.Log(selectedRoguemon.name);
                helper.setAllMoveDescriptors(MoveDescriptors, movesOfSelectedRoguemon);
                helper.setAllAttackButtons(AttackButtons, movesOfSelectedRoguemon);

           };

        // Events for Move Descriptor Labels
        if (switch_move_description_1 != null)
            
                switch_move_description_1.clicked += () => {
                    try
                    {
                        helper.switchMoveDescription(movesOfSelectedRoguemon[0].GetComponent<Move_Behaviour>().Get_Move_Description(), att_1_description_label);
  
                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                        
                        Debug.Log("Roguemon apparently does not have a move in this slot");
                    }
                };

        if (switch_move_description_2 != null)
            
                switch_move_description_2.clicked += () => {
                    try
                    {
                        helper.switchMoveDescription(movesOfSelectedRoguemon[1].GetComponent<Move_Behaviour>().Get_Move_Description(), att_2_description_label);
  
                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                        
                        Debug.Log("Roguemon apparently does not have a move in this slot");
                    }
                };

        if (switch_move_description_3 != null)
            
                switch_move_description_3.clicked += () => {
                    try
                    {
                        helper.switchMoveDescription(movesOfSelectedRoguemon[2].GetComponent<Move_Behaviour>().Get_Move_Description(), att_3_description_label);
  
                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                        
                        Debug.Log("Roguemon apparently does not have a move in this slot");
                    }
                };
        if (switch_move_description_4 != null)
            
                switch_move_description_4.clicked += () => {
                    try
                    {
                        helper.switchMoveDescription(movesOfSelectedRoguemon[3].GetComponent<Move_Behaviour>().Get_Move_Description(), att_4_description_label);
  
                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                        
                        Debug.Log("Roguemon apparently does not have a move in this slot");
                    }
                };
        

                    


        /* Example for Event Listener (Button)
        if(switchToPickButton != null)
            switchToPickButton.clicked += switchToPickScene;
        if(switchToBattleButton != null)
            switchToBattleButton.clicked += switchToBattleScene;
        */
    }
    GameObject getSelectedPokemon(){
            return selectedRoguemon;
        }

    public void loadBattleRoguemon(GameObject Roguemon){
                List<GameObject> moves = Roguemon.GetComponent<Roguemon_Behaviour>().Get_Moves();
                Debug.Log(Roguemon.name);
                Debug.Log("moomomomomomomin");
                helper.setAllMoveDescriptors(MoveDescriptors, movesOfSelectedRoguemon);
                helper.setAllAttackButtons(AttackButtons, movesOfSelectedRoguemon);
    }
}
