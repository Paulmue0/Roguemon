using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trainer_Generator : MonoBehaviour
{

    public Roguemon_Generator Roguemon_Generator;
    public GameObject Generic_Trainer;

    public GameObject Generate_Test_Trainer(string name){
      GameObject New_TrainerGO = Instantiate(Generic_Trainer);
      New_TrainerGO.name = name;

      GameObject[] lineup = new GameObject[3];
      for (int i=0; i < lineup.Length; i++){
        lineup[i] = Roguemon_Generator.Generate_Missigno();
      }
      Trainer_Behaviour New_Trainer = New_TrainerGO.GetComponent(typeof(Trainer_Behaviour)) as Trainer_Behaviour;

      New_Trainer.Set_Lineup(lineup);

      return New_TrainerGO;
    }
}
