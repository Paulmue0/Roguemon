using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect_Target_Type : MonoBehaviour
{
  // Constructor
  public Effect_Target_Type(){
  }

  // Based on a list of Roguemon that are targeted by the assigned move, this function
  // returns a list of Roguemon that the effect should affect. Must be overwritten
  // by derived classes.
  public abstract List <GameObject> Get_Affected(GameObject Target);
}
