using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Generator : MonoBehaviour
{
    private string[] move_target_types_lists = new string[]{
      "Move_Target_Type_All_Allies",
      "Move_Target_Type_All_Enemies",
      "Move_Target_Type_Ally",
      "Move_Target_Type_Any",
      "Move_Target_Type_Enemy",
      "Move_Target_Type_Self"
    };

    private string[] effect_lists = new string[]{
      "Effect_Apply_Poison",
      "Effect_Apply_Regeneration",
      "Effect_Apply_Slow",
      "Effect_Damage"
    };

    private string[] effect_target_types_lists = new string[]{
      "Effect_Target_Type_Adjacent",
      "Effect_Target_Type_Adjacent_To_Target",
      "Effect_Target_Type_All_Allies",
      "Effect_Target_Type_All_Enemies",
      "Effect_Target_Type_Opposing",
      "Effect_Target_Type_Opposing_Of_Target",
      "Effect_Target_Type_Same_As_Target",
      "Effect_Target_Type_Surrounding",
      "Effect_Target_Type_Surrounding_The_Target"
    };


  public GameObject Generic_Move;

    public GameObject Generate_Generic_Move(Transform parent){
      GameObject New_Move = Instantiate(Generic_Move, parent);
      return New_Move;
    }

    public GameObject Generate_Random_Move(Transform parent){
      string ttype = move_target_types_lists[Random.Range(0, move_target_types_lists.Length)];
      GameObject New_Move = new GameObject(Get_Random_Move_Name(), System.Type.GetType(ttype));
      New_Move.transform.parent = parent;
      Generate_Random_Effect(New_Move.transform);
      Generate_Random_Effect(New_Move.transform);
      Generate_Random_Effect(New_Move.transform);
      return New_Move;
    }

    public string Get_Random_Move_Name(){
      string[] adjectives = new string[]{
        "Immense",
        "Unbelievable",
        "Godlike",
        "Awe-Inspiring",
        "Legendary",
        "Renowned",
        "Colossal",
        "Limitless",
        "Monumental"
      };
      string[] nouns = new string[]{
        "Blast",
        "Punch",
        "Kick",
        "Bite",
        "Scratch",
        "Touch",
        "Stare",
        "Blow",
        "Roar"
      };
      string[] of_sths= new string[]{
        "Legend",
        "Devastation",
        "the Ancients",
        "Ruin",
        "Havoc",
        "Extinction",
        "Atrophy",
        "Decay",
        "Happiness"
      };

      string name = adjectives[Random.Range(0, adjectives.Length)] + " " + nouns[Random.Range(0, nouns.Length)] + " of " + of_sths[Random.Range(0, of_sths.Length)];
      return name;
    }

    public GameObject Generate_Random_Effect(Transform parent){
      string effect = effect_lists[Random.Range(0, effect_lists.Length)];
      string ttype = effect_target_types_lists[Random.Range(0, effect_target_types_lists.Length)];
      GameObject New_Effect = new GameObject("Effect", System.Type.GetType(effect), System.Type.GetType(ttype));
      New_Effect.transform.parent = parent;

      return New_Effect;
    }

}
