using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Target_Type_Opposing_Of_Target : Effect_Target_Type
{
  public override string description{
    get{
      return "the roguemon opposing the target";
    }
  }

  // This Effect_Target_Type affects the roguemon opposing the user
  public override List <GameObject> Get_Affected(GameObject Target){
    Battle_Manager BM = Get_Battle_Manager();

    return BM.Get_Roguemons(BM.Get_Opposing_Position(BM.Get_Position(Target)));
  }
}
