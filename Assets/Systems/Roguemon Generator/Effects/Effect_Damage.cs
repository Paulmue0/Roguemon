using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Damage : Effect
{
  public float strength = 10;

  public override void Apply_Effect(GameObject Affected){
    Debug.Log("Incoming damage: " + strength);
    foreach(Transform child in Affected.transform){
      Roguemon_Behaviour affected_roguemon =  child.GetComponent(typeof(Roguemon_Behaviour)) as Roguemon_Behaviour;
      affected_roguemon.Take_Damage(strength);
    }
  }
}
