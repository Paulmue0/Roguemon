using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Damage : Effect
{

  public override string description{
    get{
      return "Does damage to";
    }
  }

  public override void Apply_Effect(GameObject Affected, float strength_so_far){
    Roguemon_Behaviour affected_roguemon =  Affected.GetComponent(typeof(Roguemon_Behaviour)) as Roguemon_Behaviour;
    affected_roguemon.Take_Damage(strength_so_far);
  }
}
