using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class pickRoguemonUIController : UIController
{
    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        // Define the 3 Pick Roguemon Buttons
        pickRoguemon_1 = root.Q<Button>("pick-mon1");
        pickRoguemon_2 = root.Q<Button>("pick-mon2");
        pickRoguemon_3 = root.Q<Button>("pick-mon3");
        
        // Define dialogLabel
        dialogLabel = root.Q<Label>("DialogLabel");

        // Define StatsLabel
        statsLabel = root.Q<Label>("StatsLabel");
    }
}
