using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Target_Type_All_Enemies : Effect_Target_Type
{
  public override string description{
    get{
      return "all enemies";
    }
  }

  // This Effect_Target_Type affects all enemies of the roguemon that
  // used the move.
  public override List <GameObject> Get_Affected(GameObject Target){
    Battle_Manager BM = Get_Battle_Manager();
    GameObject this_moves_roguemon = transform.parent.parent.gameObject;

    return BM.Get_Roguemons(BM.Get_Enemies_Position(BM.Get_Position(this_moves_roguemon)));
  }
}
