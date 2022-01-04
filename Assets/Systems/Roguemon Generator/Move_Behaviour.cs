using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Behaviour : MonoBehaviour
{
    // Methods

    // Gets the targeted Roguemon from the Target_Type and then applies all Effects
    // assigned to this move to them.
    public void Do_Move(){
      Move_Target_Type Target_Type = GetComponent(typeof(Move_Target_Type)) as Move_Target_Type;
      List <GameObject> Targets = Target_Type.Choose_Targets();

      Make_Log_Entry();

      // Check each child of this if it is an effect and if yet, then activate
      // it on the Targets returned by the Target_Type
      foreach (Transform child in transform) {
        Effect effect = child.gameObject.GetComponent(typeof(Effect)) as Effect;

        if (effect != null) {
          effect.Affect(Targets);
        }
      }
    }

    public void Make_Log_Entry(){
      string roguemon_name = transform.parent.gameObject.name;
      string move_name = gameObject.name;

      Debug.Log(roguemon_name + " uses " + move_name + "!");
    }
}
