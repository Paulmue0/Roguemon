using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Target_Type_Surrounding : Effect_Target_Type
{
  public override string description{
    get{
      return "surrounding roguemon";
    }
  }

  // This Effect_Target_Type affects the roguemon opposing the user
  public override List <GameObject> Get_Affected(GameObject Target){
    Battle_Manager BM = Get_Battle_Manager();
    GameObject this_moves_roguemon = transform.parent.parent.gameObject;

    return BM.Get_Roguemons(BM.Get_Surrounding_Position(BM.Get_Position(this_moves_roguemon)));
  }
}
