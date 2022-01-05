using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public Button switchToPickButton;
    public Button switchToBattleButton;

    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        switchToPickButton = root.Q<Button>("switch-to-pick-scene-button");
        switchToBattleButton = root.Q<Button>("switch-to-battle-scene-button");

        if(switchToPickButton != null)
            switchToPickButton.clicked += switchToPickScene;
        if(switchToBattleButton != null)
            switchToBattleButton.clicked += switchToBattleScene;

    }

    void switchToWhoAreYouScene(){
        SceneManager.LoadScene("whoAreYouScene");
    }
    void switchToPickScene(){
        SceneManager.LoadScene("pickRoguemon");
    }

    void switchToBattleScene(){
        SceneManager.LoadScene("battleScene");
    }
}
