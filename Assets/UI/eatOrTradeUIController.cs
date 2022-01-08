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
