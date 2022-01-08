using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Target_Type_Ally : Move_Target_Type
{
  public override string description{
    get{
      return "Targets one ally";
    }
  }

  // Methods

  public override bool Valid_Target(GameObject TargetGO){
      Battle_Manager BM = Get_Battle_Manager();
      GameObject this_moves_roguemon = transform.parent.gameObject;

      return BM.Is_Ally_Of(this_moves_roguemon, TargetGO);
  }

  // This Target Type returns the Roguemon that used the Move.
  public override List <GameObject> Get_Targets(GameObject TargetGO){
    List<GameObject> Targets = new List<GameObject>();
    Targets.Add(TargetGO);

    return Targets;
  }
}
