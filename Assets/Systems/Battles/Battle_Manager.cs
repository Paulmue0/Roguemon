using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_Manager : MonoBehaviour
{
   public Roguemon_Generator Roguemon_Generator;
   public Move_Generator Move_Generator;

   public GameObject Roguemon;

    // Start is called before the first frame update
    void Start()
    {
        GameObject missigno = Roguemon_Generator.Generate_Generic_Roguemon();
        missigno.name = "Missigno";
        Debug.Log("Created " + missigno.name + "!");

        Move_Generator.Generate_Effect(Move_Generator.Generate_Generic_Move(missigno.transform).transform, "Effect_Damage", "Effect_Target_Type_Same_As_Target");

        Roguemon_Behaviour missigno_rb = missigno.GetComponent(typeof(Roguemon_Behaviour)) as Roguemon_Behaviour;
        foreach(GameObject moveGO in missigno_rb.Get_Moves()){
          Move_Behaviour move = moveGO.GetComponent(typeof(Move_Behaviour)) as Move_Behaviour;
          Debug.Log(move.Get_Move_Description());
        }

        foreach(Transform child in missigno.transform){
          Move_Behaviour move = child.GetComponent(typeof(Move_Behaviour)) as Move_Behaviour;
          move.Do_Move();
        }

        Roguemon = missigno;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject getRoguemon(){
      return Roguemon;
    }
}
