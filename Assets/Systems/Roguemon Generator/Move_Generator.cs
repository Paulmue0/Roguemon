using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Generator : MonoBehaviour
{
  public GameObject Generic_Move;
  public GameObject Generic_Effect;

    public GameObject Generate_Generic_Move(){
      GameObject New_Move = Instantiate(Generic_Move);
      Debug.Log("Generated generic move..");
      return New_Move;
    }

    public GameObject Generate_Effect(Effect effect, Effect_Target_Type ttype){
      GameObject New_Effect = Instantiate(Generic_Effect);
      Destroy(New_Effect.gameObject.GetComponent<Effect>());
      Destroy(New_Effect.gameObject.GetComponent<Effect_Target_Type>());
      effect.transform.parent = New_Effect.transform;
      ttype.transform.parent = New_Effect.transform;

      Debug.Log("Generated effect..");
      return New_Effect;
    }

    public void Add_Effect(GameObject move, GameObject effect){
      Debug.Log("Added effect to move..");
      effect.transform.parent = move.transform;
    }
}
