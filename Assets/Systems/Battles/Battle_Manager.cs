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

   private GameObject active_Roguemon;
   private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
      Set_Player(Trainer_Generator.Generate_Test_Trainer("Player"));
      Set_Opponent(Trainer_Generator.Generate_Test_Trainer("Opponent"));
      active_Roguemon = Player.GetComponent<Trainer_Behaviour>().Get_Lineup()[0];
    }

    void Update(){
      timer += Time.deltaTime;
      if (timer > 4){
        active_Roguemon.GetComponent<Roguemon_Behaviour>().Get_Moves()[0].GetComponent<Move_Behaviour>().Do_Move();
        timer = 0f;
      }
    }

    // Getter and Setter

    public void Set_Opponent(GameObject new_Opponent){
      if(new_Opponent.GetComponent(typeof(Trainer_Behaviour)) as Trainer_Behaviour == null){
        throw new ArgumentException("The Opponent must be a Trainer. (GameObject missing Trainer_Behaviour)");
      }
      Opponent = new_Opponent;
      Opponent.transform.SetParent(gameObject.transform);
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
      Player.transform.SetParent(gameObject.transform);
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

    public int Get_Position(GameObject roguemonGO){
      int i = 0;
      Trainer_Behaviour player_TB = Player.GetComponent(typeof(Trainer_Behaviour)) as Trainer_Behaviour;
      foreach(GameObject player_roguemon in player_TB.Get_Lineup()){
        if(player_roguemon == roguemonGO) return i;
        i++;
      }
      Trainer_Behaviour opponent_TB = Opponent.GetComponent(typeof(Trainer_Behaviour)) as Trainer_Behaviour;
      foreach(GameObject opponent_roguemon in opponent_TB.Get_Lineup()){
        if(opponent_roguemon == roguemonGO) return i;
        i++;
      }
      return -1;
    }

    // Methods

    public List<int> Get_Adjacent_Position(int position){
      List<int> adjacent_positions = new List<int>();

      if(position == 0 || position == 3) adjacent_positions.Add(position+1);
      if(position == 1 || position == 4){
         adjacent_positions.Add(position+1);
         adjacent_positions.Add(position-1);
       }
      if(position == 2 || position == 5) adjacent_positions.Add(position-1);
      return adjacent_positions;
    }

    public List<int> Get_Opposing_Position(int position){
      List<int> opposing_positions = new List<int>();

      if(position > 2) opposing_positions.Add(position - 3);
      else opposing_positions.Add(position + 3);
      return opposing_positions;
    }

    public List<int> Get_Surrounding_Position(int position){
      List<int> opposing_positions = Get_Adjacent_Position(position);
      List<int> surrounding_positions = Get_Opposing_Position(position);

      foreach(int entry in opposing_positions){
        surrounding_positions.Add(entry);
      }
      return surrounding_positions;
    }

    public List<int> Get_Allies_Position(int position){
      List<int> allies_positions = Get_Adjacent_Position(position);

      if(position > 2){
        allies_positions.Add(0);
        allies_positions.Add(1);
        allies_positions.Add(2);
        allies_positions.Remove(position);
      }
      else{
        allies_positions.Add(3);
        allies_positions.Add(4);
        allies_positions.Add(5);
        allies_positions.Remove(position);
      }

      return allies_positions;
    }

    public List<int> Get_Enemies_Position(int position){
      List<int> enemies_positions = Get_Adjacent_Position(position);

      if(position > 2){
        enemies_positions.Add(3);
        enemies_positions.Add(4);
        enemies_positions.Add(5);
      }
      else{
        enemies_positions.Add(0);
        enemies_positions.Add(1);
        enemies_positions.Add(2);
      }

      return enemies_positions;
    }

    public List<GameObject> Get_Roguemons(List<int> positions){
      List<GameObject> roguemons = new List<GameObject>();

      foreach(int position in positions){
        roguemons.Add(Get_Roguemon(position));
      }
      return roguemons;
    }

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
