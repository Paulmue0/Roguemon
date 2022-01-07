using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class eatOrTradeUIController : UIController
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

        // Define Eat and Trade Button
        eatButton = root.Q<Button>("eat-button");
        tradeButton = root.Q<Button>("trade-button");

        /* Example for Event Listener (Button)
        if(switchToPickButton != null)
            switchToPickButton.clicked += switchToPickScene;
        if(switchToBattleButton != null)
            switchToBattleButton.clicked += switchToBattleScene;
        */
    }
}
