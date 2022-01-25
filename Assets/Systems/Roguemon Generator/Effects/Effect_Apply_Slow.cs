using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Apply_Slow : Effect
{

  public override string description{
    get{
      return "Slows";
    }
  }

  public override void Apply_Effect(GameObject Affected, float strength_so_far){
    GameObject New_Status_Effect = new GameObject("Status_Effect_Slow", System.Type.GetType("Status_Effect_Slow"));
    New_Status_Effect.GetComponent<Status_Effect_Behaviour>().Initialize_Status_Effect(Affected, 3, strength_so_far);
  }
}
