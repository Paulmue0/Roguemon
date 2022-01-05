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

  // This Target Type returns the Roguemon that used the Move.
  public override List <GameObject> Choose_Targets(){
    List<GameObject> Targets = new List<GameObject>();

    GameObject Target = transform.parent.gameObject;
    Targets.Add(Target);

    return Targets;
  }

}
