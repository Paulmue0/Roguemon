using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status_Effect_Poison : Status_Effect_Behaviour
{
  public override float strength_multiplier{
    get{return 1.5f;}
  }
  public override string status_effect_name{
    get{return "Poison";}
  }
  public override string description{
      get{return "The affected roguemon takes damage at the start of its turn.";}
    }

  // only takes effect when its the roguemons turn. Deals damage.
  public override void Tick_Down(){
    roguemonGO.GetComponent<Roguemon_Behaviour>().Take_Damage(strength);
    base.Tick_Down();
  }
}
