using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Generic : Effect
{
  public override string description{
    get{
      return "Does nothing";
    }
  }

  public override void Apply_Effect(GameObject Affected, float strength_so_far){
    Debug.Log("Nothing happened to " + Affected.name);
  }
}
