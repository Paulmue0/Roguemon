using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
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

    // shows which attack is currently selected
        // -1 = no attack is selected
        // 0-3 represent attack 1-4
    int selectedAttack;

    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        
        MoveDescriptors = new List<Label>();
        AttackButtons = new List<Button>();

        // Define StyleSheets
        //btn_clicked = GetComponent<UIDocument>().rootVisualElement.styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/styles.uss"));
        btn_clicked = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/btn_clicked.uss");
        btn_not_clicked = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/btn_not_clicked.uss");

        // Define the 3 RogueButtons from your team
        roguemonButton_0 = root.Q<Button>("mon-0");
        roguemonButton_1 = root.Q<Button>("mon-1");
        roguemonButton_2 = root.Q<Button>("mon-2");

        // Define the 3 RogueButtons from enemy trainer team
        roguemonButton_3 = root.Q<Button>("mon-3");
        roguemonButton_4 = root.Q<Button>("mon-4");
        roguemonButton_5 = root.Q<Button>("mon-5");

        // Define dialogLabel
        dialogLabel = root.Q<Label>("DialogLabel");

        // TODO: not necesarry at this point?
        selectedAttack = -1;

        // Define Components for Attack 1
        att_1_button = root.Q<Button>("att-1-button");
        switch_move_description_1 = root.Q<Button>("switch-move-description-1");
        att_1_description_label = root.Q<Label>("att-1-description-label");

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

        if(roguemonButton_0 != null)
            roguemonButton_0.clicked += () => {
                RoguemonButtonPressed(0);
            };
        if(roguemonButton_1 != null)
            roguemonButton_1.clicked += () => {
                RoguemonButtonPressed(1);
            };
        if(roguemonButton_2 != null)
            roguemonButton_2.clicked += () => {
                RoguemonButtonPressed(2);
            };

        if(roguemonButton_3 != null)
            roguemonButton_3.clicked += () => {
                RoguemonButtonPressed(3);
            };
        if(roguemonButton_4 != null)
            roguemonButton_4.clicked += () => {
                RoguemonButtonPressed(4);
            };
        if(roguemonButton_5 != null)
            roguemonButton_5.clicked += () => {
                RoguemonButtonPressed(5);
            };


        if(att_1_button != null)
           att_1_button.clicked += () => {
               attackButtonPressed(0);
           };
        if(att_2_button != null)
           att_2_button.clicked += () => {
               attackButtonPressed(1);
           };
        if(att_3_button != null)
           att_3_button.clicked += () => {
               attackButtonPressed(2);
           };
        if(att_4_button != null)
           att_4_button.clicked += () => {
                attackButtonPressed(3);
           };

        // Events for Move Descriptor Labels
        if (switch_move_description_1 != null)
            
                switch_move_description_1.clicked += () => {
                   switchMoves(0);
                };

        if (switch_move_description_2 != null)
            
                switch_move_description_2.clicked += () => {
                    switchMoves(1);
                };

        if (switch_move_description_3 != null)
            
                switch_move_description_3.clicked += () => {
                    switchMoves(2);  
                };
        if (switch_move_description_4 != null)
            
                switch_move_description_4.clicked += () => {
                    switchMoves(3);
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

    public void loadRoguemonInBattleUI(GameObject Roguemon){
        List<GameObject> moves = Roguemon.GetComponent<Roguemon_Behaviour>().Get_Moves();
        Debug.Log("Loading: " + Roguemon.name);
        helper.setAllMoveDescriptors(MoveDescriptors, moves);
        helper.setAllAttackButtons(AttackButtons, moves, battleManager.Is_Active_Roguemon(Roguemon));
        selectedRoguemon =  Roguemon;
        selectedAttack = -1;
    }

    private void RoguemonButtonPressed(int targetPos){
        if(selectedAttack >= 0){
            Debug.Log("starting attack on " + targetPos + " with move " + selectedAttack);
            battleManager.Start_Attack(targetPos, selectedAttack);
        }
        else{
            Debug.Log("Showing Attributes of Roguemon " + targetPos);
            loadRoguemonInBattleUI(battleManager.Get_Roguemon(targetPos));
        }
    }

    private void attackButtonPressed(int movePos){
        if (battleManager.Is_Active_Roguemon(selectedRoguemon)){
            if(selectedAttack == movePos){
                AttackButtons[selectedAttack].style.backgroundColor = Color.grey;
                selectedAttack = -1;
                AttackButtons[movePos].style.backgroundColor = Color.grey;
            }
            
            
            else{
                if (selectedAttack >= 0)
                    AttackButtons[selectedAttack].style.backgroundColor = Color.grey;
                selectedAttack = movePos;
                AttackButtons[movePos].style.backgroundColor = Color.red;
            } 
        }
            
    }

    public void setBattleDialog(string dialogText){
        helper.setDialogWindowText(dialogLabel, dialogText);
    }

    private void switchMoves(int moveLabelPos){
        try
        {
        //helper.switchMoveDescription(selectedRoguemon.GetComponent<Roguemon_Behaviour>().Get_Moves()[moveLabelPos].GetComponent<Move_Behaviour>().Get_Move_Description(), MoveDescriptors[moveLabelPos]);
        helper.switchMoveDescription(MoveDescriptors[moveLabelPos]); 
        }
        catch (System.ArgumentOutOfRangeException)
        {   
            Debug.Log("Roguemon apparently does not have a move in this slot");
        }

    }
}
