using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class BattleUIController : UIController
{


    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

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

        // Define Move-Foldouts
        att_1_foldout = root.Q<Foldout>("Foldout-Attck-1");
        att_2_foldout = root.Q<Foldout>("Foldout-Attck-2");
        att_3_foldout = root.Q<Foldout>("Foldout-Attck-3");
        att_4_foldout = root.Q<Foldout>("Foldout-Attck-4");

        // Define Attack-Labels
        att_1_label = root.Q<Label>("att-1-label");
        att_2_label = root.Q<Label>("att-2-label");
        att_3_label = root.Q<Label>("att-3-label");
        att_4_label = root.Q<Label>("att-4-label");

        /* Example for Event Listener (Button)
        if(switchToPickButton != null)
            switchToPickButton.clicked += switchToPickScene;
        if(switchToBattleButton != null)
            switchToBattleButton.clicked += switchToBattleScene;
        */
    }
}
