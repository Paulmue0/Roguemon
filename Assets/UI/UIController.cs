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

    // Foldout containing the Moves of the Roguemon
    public Foldout att_1_foldout;
    public Foldout att_2_foldout;
    public Foldout att_3_foldout;
    public Foldout att_4_foldout;
    // Label inside the Foldout. 
    // Description of the moves of the Roguemon
    public Label att_1_label;
    public Label att_2_label;
    public Label att_3_label;
    public Label att_4_label;

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
