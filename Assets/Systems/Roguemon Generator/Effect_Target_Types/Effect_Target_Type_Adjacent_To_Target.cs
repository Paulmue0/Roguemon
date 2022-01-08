using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Target_Type_Adjacent_To_Target : Effect_Target_Type
{
  public override string description{
    get{
      return "roguemon adjacent to the target";
    }
  }

  // This Effect_Target_Type affects all enemies adjacent to the target
  public override List <GameObject> Get_Affected(GameObject Target){
    Battle_Manager BM = Get_Battle_Manager();

    return BM.Get_Roguemons(BM.Get_Adjacent_Position(BM.Get_Position(Target)));
  }
}
