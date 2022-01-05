using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class whoAreYouUIController : UIController
{
    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        // Define the enter Name Text Field
        enterName = root.Q<TextField>("enterNameTextField");
        
        // Define dialogLabel
        dialogLabel = root.Q<Label>("DialogLabel");

    }
}
