using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Generator : MonoBehaviour
{
  public GameObject Generic_Move;

    public GameObject Generate_Generic_Move(Transform parent){
      GameObject New_Move = Instantiate(Generic_Move, parent);
      return New_Move;
    }

    public GameObject Generate_Effect(Transform parent, string effect, string ttype){
      GameObject New_Effect = new GameObject("Effect", System.Type.GetType(effect), System.Type.GetType(ttype));
      New_Effect.transform.parent = parent;

      return New_Effect;
    }

}
