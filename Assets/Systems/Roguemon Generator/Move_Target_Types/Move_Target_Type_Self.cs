using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Target_Type_Self : Move_Target_Type
{

  public override string description{
    get{
      return "Self-targeting";
    }
  }

  // Methods

  public override bool Valid_Target(GameObject TargetGO){
      Battle_Manager BM = Get_Battle_Manager();
      GameObject this_moves_roguemon = transform.parent.gameObject;

      if(TargetGO == this_moves_roguemon){
        return true;
      }else{
        return false;
      }
  }

  // This Target Type returns the Roguemon that used the Move.
  public override List <GameObject> Get_Targets(GameObject TargetGO){
    List<GameObject> Targets = new List<GameObject>();
    Targets.Add(TargetGO);

    return Targets;
  }

}
