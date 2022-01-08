using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Target_Type_All_Enemies : Move_Target_Type
{
  public override string description{
    get{
      return "Targets all enemies";
    }
  }

  // Methods

  public override bool Valid_Target(GameObject TargetGO){
      Battle_Manager BM = Get_Battle_Manager();
      GameObject this_moves_roguemon = transform.parent.gameObject;

      return BM.Is_Enemy_Of(this_moves_roguemon, TargetGO);
  }

  // This Target Type returns the Roguemon that used the Move.
  public override List <GameObject> Get_Targets(GameObject TargetGO){
    List<GameObject> Targets = new List<GameObject>();
    GameObject this_moves_roguemon = transform.parent.gameObject;
    Battle_Manager BM = Get_Battle_Manager();
    foreach(int position in BM.Get_Enemies_Position(BM.Get_Position(this_moves_roguemon))){
      Targets.Add(BM.Get_Roguemon(position));
    }

    return Targets;
  }
}
