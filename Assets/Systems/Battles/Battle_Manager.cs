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
        GameObject missigno = Roguemon_Generator.Generate_Generic_Roguemon();
        missigno.name = "Missigno";
        Debug.Log("Created " + missigno.name + "!");

        GameObject dmg_move = Move_Generator.Generate_Generic_Move();
        GameObject dmg_effect = Move_Generator.Generate_Effect(gameObject.AddComponent(typeof(Effect_Damage)) as Effect_Damage, gameObject.AddComponent(typeof(Effect_Target_Type_Same_As_Target)) as Effect_Target_Type_Same_As_Target);
        Move_Generator.Add_Effect(dmg_move, dmg_effect);
        Roguemon_Generator.Add_Move(missigno, dmg_move);

        foreach(Transform child in missigno.transform){
          Move_Behaviour move = child.GetComponent(typeof(Move_Behaviour)) as Move_Behaviour;
          move.Do_Move();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
