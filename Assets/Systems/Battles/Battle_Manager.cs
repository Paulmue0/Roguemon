using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle_Manager : MonoBehaviour
{
   public Trainer_Generator Trainer_Generator;
   public Roguemon_Generator Roguemon_Generator;
   public Move_Generator Move_Generator;

   public BattleUIController battleUI;

   public GameObject Player;
   public GameObject Opponent;

    // Start is called before the first frame update
    void Start()
    {
      Set_Player(Trainer_Generator.Generate_Test_Trainer("Player"));
      Set_Opponent(Trainer_Generator.Generate_Test_Trainer("Opponent"));
    }

    // Getter and Setter

    public void Set_Opponent(GameObject new_Opponent){
      if(new_Opponent.GetComponent(typeof(Trainer_Behaviour)) as Trainer_Behaviour == null){
        throw new ArgumentException("The Opponent must be a Trainer. (GameObject missing Trainer_Behaviour)");
      }
      Opponent = new_Opponent;
      Opponent.transform.position = new Vector3(0, 3.25f, 0);
    }

    public GameObject Get_Opponent(){
      return Opponent;
    }

    public void Set_Player(GameObject new_Player){
      if(new_Player.GetComponent(typeof(Trainer_Behaviour)) as Trainer_Behaviour == null){
        throw new ArgumentException("The Player must be a Trainer. (GameObject missing Trainer_Behaviour)");
      }
      Player = new_Player;
      Player.transform.position = new Vector3(0, 1.5f, 0);
    }

    public GameObject Get_Player(){
      return Player;
    }

    // positions are:
    // OPPONENT: 3 | 4 | 5
    // PLAYER:   0 | 1 | 2
    public GameObject Get_Roguemon(int position){
      if(position < 0 || position > 5){
        throw new ArgumentException("Only 0 to 5 are valid positions");
      }

      if (position > 2){
        Trainer_Behaviour Opponent_TB = Opponent.GetComponent(typeof(Trainer_Behaviour)) as Trainer_Behaviour;
        return Opponent_TB.Get_Roguemon(position - 3);
      }else{
        Trainer_Behaviour Player_TB = Player.GetComponent(typeof(Trainer_Behaviour)) as Trainer_Behaviour;
        return Player_TB.Get_Roguemon(position);
      }
    }

    // Methods

    public void Test_Function(){
      GameObject missigno = Roguemon_Generator.Generate_Missigno();
      
      Roguemon_Behaviour missigno_rb = missigno.GetComponent(typeof(Roguemon_Behaviour)) as Roguemon_Behaviour;
      foreach(GameObject moveGO in missigno_rb.Get_Moves()){
        Move_Behaviour move = moveGO.GetComponent(typeof(Move_Behaviour)) as Move_Behaviour;
        Debug.Log(move.Get_Move_Description());
      }

      foreach(Transform child in missigno.transform){
        Move_Behaviour move = child.GetComponent(typeof(Move_Behaviour)) as Move_Behaviour;
        move.Do_Move();
      }
      Debug.Log("sdfdsfds");
      battleUI.loadBattleRoguemon(missigno);
    }
}
