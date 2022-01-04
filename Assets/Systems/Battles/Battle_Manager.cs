using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_Manager : MonoBehaviour
{
   public Roguemon_Generator Roguemon_Generator;
   public Move_Generator Move_Generator;

    // Start is called before the first frame update
    void Start()
    {
        GameObject Test = Roguemon_Generator.Generate_Generic_Roguemon();
        foreach(Transform child in transform){
          Move_Behaviour move = child.GetComponent(typeof(Move_Behaviour)) as Move_Behaviour;
          move.Do_Move();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
