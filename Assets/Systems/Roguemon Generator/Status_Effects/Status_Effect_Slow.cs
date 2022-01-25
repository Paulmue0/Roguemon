using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status_Effect_Slow : Status_Effect_Behaviour
{

  public override float strength_multiplier{
    get{return 2.0f;}
  }
  public override string status_effect_name{
    get{return "Slow";}
  }
  public override string description{
    get{return "Reduces the speed of the affected roguemon";}
  }
  public float amount_of_speed_reduced;

  // Called when the effect is initialy applied.
  public override void Initialize_Status_Effect(GameObject target, int initial_duration, float strength_so_far){
    base.Initialize_Status_Effect(target, initial_duration, strength_so_far);

    Roguemon_Behaviour roguemon = roguemonGO.GetComponent<Roguemon_Behaviour>();
    float[] stats = roguemon.Get_Stats();
    stats[2] = stats[2] - strength;
    if(stats[2] < 0) stats[2] = 0;
    roguemon.Set_Stats(stats);
  }

  // called when the attack ends.
  public override void End_Status_Effect(){
    Roguemon_Behaviour roguemon = roguemonGO.GetComponent<Roguemon_Behaviour>();
    float[] stats = roguemon.Get_Stats();
    stats[2] = stats[2] + strength;
    roguemon.Set_Stats(stats);

    base.End_Status_Effect();
  }
}
