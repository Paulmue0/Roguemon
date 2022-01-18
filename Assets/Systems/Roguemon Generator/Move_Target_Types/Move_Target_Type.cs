using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Move_Target_Type : MonoBehaviour
{
  public float strength_multiplier = 1;

  public abstract string description{
    get;
  }

  // returns the Battle Manager Component that this move is assigned to
  // (via  move -> roguemon -> trainer -> battle)
  public Battle_Manager Get_Battle_Manager(){
    return transform.parent.parent.parent.gameObject.GetComponent<Battle_Manager>() as Battle_Manager;
  }

  // Methods

  // Checks if a given roguemon is a valid target
  public abstract bool Valid_Target(GameObject TargetGO);

  // Returns a List of Roguemon that the Move targets. Must be overwritten
  // by derived classes.
  public abstract List <GameObject> Get_Targets(GameObject targetGO);


}
