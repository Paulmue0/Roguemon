using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class selectBadgesUIController : UIController
{
    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        // Define the 3 Pick Roguemon Buttons
        pickBadge_1 = root.Q<Button>("pick-badge1");
        pickBadge_2 = root.Q<Button>("pick-badge2");
        pickBadge_3 = root.Q<Button>("pick-badge3");
        
        // Define dialogLabel
        dialogLabel = root.Q<Label>("DialogLabel");

        // Define Badge Description Label
        badgeDescriptionLabel = root.Q<Label>("badgeDescription");
    }
}
