using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Behaviour : MonoBehaviour
{
    // Getter and Setter

    public string Get_Name(){
      return name;
    }

    public void Set_Name(string new_name){
      name = new_name;
    }

    public string Get_Move_Description(){
      List<GameObject> Effects = Get_Effects();

      string full_description = "";
      Move_Target_Type mttype = Get_Move_Target_Type();
      full_description += "[" + mttype.description + "]\n";
      foreach(GameObject EffectGO in Effects){
        Effect Effect = EffectGO.GetComponent(typeof(Effect)) as Effect;
        Effect_Target_Type ettype = Effect.Get_Effect_Target_Type();
        full_description += Effect.description + " " + ettype.description + ".";
      }
      return full_description;
    }

    public Move_Target_Type Get_Move_Target_Type(){
      return gameObject.GetComponent(typeof(Move_Target_Type)) as Move_Target_Type;
    }

    // returns list of all children gameObjects with component of type Effect
    public List<GameObject> Get_Effects(){
      List<GameObject> Effects = new List<GameObject>();
      foreach (Effect child in GetComponentsInChildren<Effect>()){
            Effects.Add(child.gameObject);
        }
      return Effects;
    }

    // Methods

    // Gets the targeted Roguemon from the Target_Type and then applies all Effects
    // assigned to this move to them.
    public void Do_Move(GameObject clicked_GO, float strength_so_far){
      Move_Target_Type Target_Type = GetComponent(typeof(Move_Target_Type)) as Move_Target_Type;
      List <GameObject> Targets = Target_Type.Get_Targets(clicked_GO);

      strength_so_far = strength_so_far * Target_Type.strength_multiplier;
      // Check each child of this if it is an effect and if yes, then activate
      // it on the Targets returned by the Target_Type
      foreach (Transform child in transform) {
        Effect effect = child.gameObject.GetComponent(typeof(Effect)) as Effect;

        if (effect != null) {
          effect.Affect(Targets, strength_so_far);
        }
      }
    }

    public void Make_Log_Entry(){
      string roguemon_name = transform.parent.gameObject.name;
      string move_name = gameObject.name;

      //Debug.Log(roguemon_name + " uses " + move_name + "!");
    }
}
