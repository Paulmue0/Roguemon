using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Target_Type_Surrounding_The_Target : Effect_Target_Type
{
  public override string description{
    get{
      return "roguemon surrounding the target";
    }
  }

  // This Effect_Target_Type affects the roguemon opposing the user
  public override List <GameObject> Get_Affected(GameObject Target){
    Battle_Manager BM = Get_Battle_Manager();

    return BM.Get_Roguemons(BM.Get_Surrounding_Position(BM.Get_Position(Target)));
  }
}
