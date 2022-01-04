using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Target_Type_Same_As_Target : Effect_Target_Type
{

  // This Effect_Target_Type affects the same Roguemon that where also
  // targeted by the Move_Target_Type of the corresponding move.
  public override List <GameObject> Get_Affected(GameObject Target){
    List<GameObject> Targets = new List<GameObject>();
    Targets.Add(Target);
    return Targets;
  }
}
