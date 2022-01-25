using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status_Effect_Regeneration : Status_Effect_Behaviour
{

  public override float strength_multiplier{
    get{return 0.5f;}
  }
  public override string status_effect_name{
    get{return "Regeneration";}
  }
  public override string description{
    get{return "The affected roguemon regenerates health at the start of its turn";}
  }
  public float amount_of_speed_reduced;

  // only takes effect when its the roguemons turn. Heals.
  public override void Tick_Down(){
    roguemonGO.GetComponent<Roguemon_Behaviour>().Heal(strength);
    base.Tick_Down();
  }
}
