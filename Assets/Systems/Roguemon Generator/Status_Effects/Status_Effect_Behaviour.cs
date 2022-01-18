using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Status_Effect_Behaviour : MonoBehaviour
{
    public float strength;
    public float strength_multiplier = 1;
    public int duration;
    public GameObject roguemonGO; // the affected roguemon
    public string description = "Does nothing each turn!";
    public string status_effect_name = "Generic Status Effect";

    // Called when the effect is initialy applied. If child classes overwrite this, they should
    // call the parent method at the end.
    public virtual void Initialize_Status_Effect(GameObject target, int initial_duration, float strength_so_far){
      duration = initial_duration;
      strength = strength_so_far * strength_multiplier;
      roguemonGO = target;
      roguemonGO.GetComponent<Roguemon_Behaviour>().Add_Status_Effect(gameObject);
    }

    // should be called each time the roguemon starts a turn. If child classes overwrite this, they should
    // call the parent method at the end.
    public virtual void Tick_Down(){
        duration -= 1;
        if(duration <= 0){
          End_Status_Effect();
        }
    }

    // called when the attack ends. If child classes overwrite this, they should
    // call the parent method at the end.
    public virtual void End_Status_Effect(){
        this.roguemonGO.GetComponent<Roguemon_Behaviour>().Remove_Status_Effect(gameObject);
    }
}
