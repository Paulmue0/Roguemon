using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Damage : Effect
{
  public float strength = 10;

  public override string description{
    get{
      return "Does damage";
    }
  }

  public override void Apply_Effect(GameObject Affected){
    Roguemon_Behaviour affected_roguemon =  Affected.GetComponent(typeof(Roguemon_Behaviour)) as Roguemon_Behaviour;
    affected_roguemon.Take_Damage(strength);
  }
}
