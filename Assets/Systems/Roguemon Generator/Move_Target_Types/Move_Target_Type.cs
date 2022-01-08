using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Move_Target_Type : MonoBehaviour
{

  public abstract string description{
    get;
  }

  // Methods

  // Returns a List of Roguemon that the Move targets. Must be overwritten
  // by derived classes.
  public abstract List <GameObject> Choose_Targets();

}
