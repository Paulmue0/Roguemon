using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Damage : Effect
{
  public float strength = 100;

  public override void Apply_Effect(GameObject Affected){
    Debug.Log("Incoming damage: " + strength);
    Roguemon_Behaviour affected_roguemon =  Affected.GetComponent(typeof(Roguemon_Behaviour)) as Roguemon_Behaviour;
    affected_roguemon.Take_Damage(strength);
  }
}
