using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    // Buttons for the 3 Roguemon of your team
    public Button roguemonButton_0;
    public Button roguemonButton_1;
    public Button roguemonButton_2;

    // Buttons for the 3 Roguemon of enemy trainer team
    public Button roguemonButton_3;
    public Button roguemonButton_4;
    public Button roguemonButton_5;
    
    // Label for Dialog-Window
    public Label dialogLabel;

    // Components for Attack 1
    public Button att_1_button;
    public Button switch_move_description_1;
    public Label att_1_description_label;
 
    // Components for Attack 2
    public Button att_2_button;
    public Button switch_move_description_2;
    public Label att_2_description_label;

     // Components for Attack 3
    public Button att_3_button;
    public Button switch_move_description_3;
    public Label att_3_description_label;

    // Components for Attack 4
    public Button att_4_button;
    public Button switch_move_description_4;
    public Label att_4_description_label;

    // Label showing the Stats
    public Label statsLabel;

    /*
    EAT OR TRADE SPECIFICS
    */
    public Button eatButton;
    public Button tradeButton;

    /*
    PICK ROGUEMON SPECIFICS
    */
    public Button pickRoguemon_1;
    public Button pickRoguemon_2;
    public Button pickRoguemon_3;

     /*
    SELECT BADGE SPECIFICS
    */
    public Button pickBadge_1;
    public Button pickBadge_2;
    public Button pickBadge_3;

    public Label badgeDescriptionLabel;

     /*
    WHO ARE YOU SPECIFICS
    */
    public TextField enterName;
}
