using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Target_Type_Any : Move_Target_Type
{
  public override string description{
    get{
      return "Free targeting";
    }
  }

  // Methods

  public override bool Valid_Target(GameObject TargetGO){
      return true;
  }

  // This Target Type returns the Roguemon that used the Move.
  public override List <GameObject> Get_Targets(GameObject TargetGO){
    List<GameObject> Targets = new List<GameObject>();
    Targets.Add(TargetGO);

    return Targets;
  }
}
