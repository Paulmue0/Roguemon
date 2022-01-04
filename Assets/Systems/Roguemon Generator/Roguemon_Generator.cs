using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roguemon_Generator : MonoBehaviour
{
  public GameObject Generic_Roguemon;

    public GameObject Generate_Generic_Roguemon(){
      GameObject New_Roguemon = Instantiate(Generic_Roguemon);
      return New_Roguemon;
    }

    public void Add_Move(GameObject roguemon, GameObject move){
      move.transform.parent = roguemon.transform;
    }
}
