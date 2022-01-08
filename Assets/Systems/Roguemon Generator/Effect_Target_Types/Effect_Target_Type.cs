using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect_Target_Type : MonoBehaviour
{
  public abstract string description{
    get;
  }

  // Constructor
  public Effect_Target_Type(){
  }

  // Getter and Setter
  // returns the Battle Manager Component that this effect is assigned to
  // (via effect -> move -> roguemon -> battle)
  public Battle_Manager Get_Battle_Manager(){
    return transform.parent.parent.parent.gameObject.GetComponent<Battle_Manager>() as Battle_Manager;
  }

  // Based on a list of Roguemon that are targeted by the assigned move, this function
  // returns a list of Roguemon that the effect should affect. Must be overwritten
  // by derived classes.
  public abstract List <GameObject> Get_Affected(GameObject Target);
}
