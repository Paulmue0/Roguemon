using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : MonoBehaviour
{
  public float strength_multiplier = 1;

  // Getter and Setter

  public abstract string description{
    get;
  }

  public Effect_Target_Type Get_Effect_Target_Type(){
    return gameObject.GetComponent(typeof(Effect_Target_Type)) as Effect_Target_Type;
  }

  // Methods

  // Gets the Roguemon that this effect should affect, based on a list of
  // targets that the parent move was used on. Then calls apply_effect on
  // all of them.
  public void Affect(List <GameObject> Targets, float strength_so_far){
    Effect_Target_Type Target_Type = gameObject.GetComponent(typeof(Effect_Target_Type)) as Effect_Target_Type;
    strength_so_far = strength_so_far * strength_multiplier * Target_Type.strength_multiplier;

    foreach(GameObject Target in Targets){
      List <GameObject> All_Affected = Target_Type.Get_Affected(Target);
      foreach(GameObject Affected in All_Affected){
        Apply_Effect(Affected, strength_so_far);
      }
    }
  }

  // What this effect does to a pokemon that is affected. Should be
  // overwritten in derived classes.
  public abstract void Apply_Effect(GameObject Affected, float strength_so_far);
}
