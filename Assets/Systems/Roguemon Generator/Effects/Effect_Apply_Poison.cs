using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Apply_Poison : Effect
{

  public override string description{
    get{
      return "Poisons";
    }
  }

  public override void Apply_Effect(GameObject Affected, float strength_so_far){
    GameObject New_Status_Effect = new GameObject("Status_Effect_Poison", System.Type.GetType("Status_Effect_Poison"));
    New_Status_Effect.GetComponent<Status_Effect_Behaviour>().Initialize_Status_Effect(Affected, 3, strength_so_far);
  }
}
