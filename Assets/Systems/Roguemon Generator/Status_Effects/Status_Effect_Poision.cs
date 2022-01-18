using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status_Effect_Poison : Status_Effect_Behaviour
{
  new public float strength_multiplier = 1.5f;

  // only takes effect when its the roguemons turn. Deals damage.
  public override void Tick_Down(){
    roguemonGO.GetComponent<Roguemon_Behaviour>().Take_Damage(strength);
    base.Tick_Down();
  }
}
