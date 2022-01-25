using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roguemon_Generator : MonoBehaviour
{
  public Move_Generator Move_Generator;
  public GameObject Generic_Roguemon;

    public GameObject Generate_Generic_Roguemon(){
      GameObject New_Roguemon = Instantiate(Generic_Roguemon);
      return New_Roguemon;
    }

    public void Add_Move(Transform parent, Transform move){
      move.parent = parent;
    }

    public GameObject Generate_Missigno(){
      GameObject New_Roguemon = Instantiate(Generic_Roguemon);
      New_Roguemon.name = "Missigno";
      Add_Move(New_Roguemon.transform, Move_Generator.Generate_Random_Move(New_Roguemon.transform).transform);
      Add_Move(New_Roguemon.transform, Move_Generator.Generate_Random_Move(New_Roguemon.transform).transform);
      Add_Move(New_Roguemon.transform, Move_Generator.Generate_Random_Move(New_Roguemon.transform).transform);
      Add_Move(New_Roguemon.transform, Move_Generator.Generate_Random_Move(New_Roguemon.transform).transform);

      return New_Roguemon;
    }
}
