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

   private GameObject active_RoguemonGO;
   private Queue<GameObject> turn_Queue;
   private bool players_turn;

    // Start is called before the first frame update
    void Start()
    {
      Set_Player(Trainer_Generator.Generate_Test_Trainer("Player"));
      Set_Opponent(Trainer_Generator.Generate_Test_Trainer("Opponent"));
      Setup_Turn_Queue();

      StartCoroutine(Next_Turn());
    }

    IEnumerator Next_Turn(){
      yield return new WaitForSeconds(1.0f);
      if(Battle_Over_Check() == 0){
        Set_Next_Active_RoguemonGO();
        if(!players_turn){
          Opponent.GetComponent<Trainer_Behaviour>().Take_Turn(active_RoguemonGO);
          yield return new WaitForSeconds(1.25f);
          StartCoroutine(Next_Turn());
        }
      }else{
        Debug.Log("Game Over!");
      }
    }

    // Getter and Setter

    public void Set_Opponent(GameObject new_Opponent){
      if(new_Opponent.GetComponent(typeof(Trainer_Behaviour)) as Trainer_Behaviour == null){
        throw new ArgumentException("The Opponent must be a Trainer. (GameObject missing Trainer_Behaviour)");
      }
      Opponent = new_Opponent;
      Opponent.transform.SetParent(gameObject.transform);
      Opponent.transform.position = new Vector3(0, 4.25f, 0);

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
      Player.transform.position = new Vector3(0, 2.25f, 0);
    }

    public GameObject Get_Player(){
      return Player;
    }

    public GameObject Get_Active_Roguemon(){
      return active_RoguemonGO;
    }

    public bool Is_Active_Roguemon(GameObject Roguemon){
      return Roguemon.Equals(active_RoguemonGO);
    }

    public GameObject Get_Trainer_Of(GameObject roguemonGO){
      if(Get_Position(roguemonGO) < 3){
        return Player;
      }else{
        return Opponent;
      }
    }

    public bool Belongs_To_Player(GameObject roguemonGO){
      if(Get_Trainer_Of(roguemonGO) == Player){
        return true;
      }else{
        return false;
      }
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

    //
    public void Start_Attack(int target_pos, int move_pos){
      if(Is_Valid_Move(target_pos, move_pos)){
        GameObject target = Get_Roguemon(target_pos);
        active_RoguemonGO.GetComponent<Roguemon_Behaviour>().Use_Move(move_pos, target);
        StartCoroutine(Next_Turn());
      }
    }

    public bool Is_Valid_Move(int target_pos, int move_pos){
      GameObject target = Get_Roguemon(target_pos);
      return active_RoguemonGO.GetComponent<Roguemon_Behaviour>().Is_Valid_Move(move_pos, target);
    }

    // creates a turn queue from the two trainer lineups. TODO: Make it depend on speed stat
    public void Setup_Turn_Queue(){
      GameObject[] player_lineup = Player.GetComponent<Trainer_Behaviour>().Get_Lineup();
      GameObject[] opponent_lineup = Opponent.GetComponent<Trainer_Behaviour>().Get_Lineup();
      turn_Queue = new Queue<GameObject>();
      for(int i=0; i< 3;i++){
        player_lineup[i].name += "P" + i.ToString(); // TODO: Remove renaming
        opponent_lineup[i].name += "O" + i.ToString(); //
        turn_Queue.Enqueue(player_lineup[i]);
        turn_Queue.Enqueue(opponent_lineup[i]);
      }
    }

    // checks if there are dead roguemon in the queue, if there are removes them
    public void Check_Turn_Queue(){
      Queue<GameObject> temp_Queue = new Queue<GameObject>();

      while (turn_Queue.Count > 0){
        GameObject current_roguemon = turn_Queue.Dequeue();
        if(current_roguemon.GetComponent<Roguemon_Behaviour>().Is_Alive()){
          temp_Queue.Enqueue(current_roguemon);
        }
      }

      while (temp_Queue.Count > 0){
        turn_Queue.Enqueue(temp_Queue.Dequeue());
      }
    }

    // checks if all roguemon of one trainer are dead. Returns 1 for player wins, -1 for player loses and 0 for neither.
    public int Battle_Over_Check(){
      GameObject[] player_lineup = Player.GetComponent<Trainer_Behaviour>().Get_Lineup();
      bool one_player_roguemon_still_alive = false;
      for(int i = 0; i < player_lineup.Length; i++){
        one_player_roguemon_still_alive = one_player_roguemon_still_alive || player_lineup[i].GetComponent<Roguemon_Behaviour>().Is_Alive();
      }

      GameObject[] opponent_lineup = Opponent.GetComponent<Trainer_Behaviour>().Get_Lineup();
      bool one_opponent_roguemon_still_alive = false;
      for(int i = 0; i < opponent_lineup.Length; i++){
        one_opponent_roguemon_still_alive = one_opponent_roguemon_still_alive || opponent_lineup[i].GetComponent<Roguemon_Behaviour>().Is_Alive();
      }

      if(one_player_roguemon_still_alive && one_opponent_roguemon_still_alive){
        return 0;
      } else if(one_opponent_roguemon_still_alive){
        Debug.Log("Player loses!");
        return -1;
      } else if(one_player_roguemon_still_alive){
        Debug.Log("Player wins!");
        return 1;
      } else {
        return -1;
      }
    }

    // sets active_roguemon to the next one in the turn queue
    public void Set_Next_Active_RoguemonGO(){
      Check_Turn_Queue();
      if(active_RoguemonGO != null)
        turn_Queue.Enqueue(active_RoguemonGO);
      active_RoguemonGO = turn_Queue.Dequeue();
      if(Get_Trainer_Of(active_RoguemonGO) == Player){
        players_turn = true;
      } else {
        players_turn = false;
      }
      Debug.Log("Its now " + active_RoguemonGO.name + "s turn!");
      battleUI.setBattleDialog("Its now " + active_RoguemonGO.name + "s turn!");
      active_RoguemonGO.GetComponent<Roguemon_Behaviour>().Trigger_Status_Effects();
      //battleUI. TODO: Tell UI the next active roguemon
      battleUI.loadRoguemonInBattleUI(active_RoguemonGO);
    }

    // takes two roguemon and returns true if they belong to opposing trainers
    public bool Is_Enemy_Of(GameObject roguemon, GameObject potential_enemy){
      if(Get_Enemies_Position(Get_Position(roguemon)).Contains(Get_Position(potential_enemy))){
        return true;
      }else{
        return false;
      }
    }

      // takes two roguemon and returns true if they belong to the same trainer
    public bool Is_Ally_Of(GameObject roguemon, GameObject potential_ally){
      if(Get_Allies_Position(Get_Position(roguemon)).Contains(Get_Position(potential_ally))){
        return true;
      }else{
        return false;
      }
    }
  }
