using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roguemon_Behaviour : MonoBehaviour
{
   // Stats
   public float Damage;
   public float Defense;
   public float Speed;
   public float Health;

   public bool Alive = true;

   public List<GameObject> status_effects = new List<GameObject>();
   public Animator animator;

    // Constructor
    public Roguemon_Behaviour(float dmg, float def, float spd, float hp){
      Set_Stats(new float[]{dmg, def, spd, hp});
    }

    // Getter and Setter

    public float[] Get_Stats(){
      return new float[]{Damage, Defense, Speed, Health};
    }

    public void Set_Stats(float[] stats){
      if (stats.Length != 4){
        throw new ArgumentException("Setting stats requires an array with four floats");
      }

      if (stats[0] < 0 || stats[1] < 0 || stats[2] < 0){
        throw new ArgumentException("Can't set a stat to a negative value");
      }

      Damage = stats[0];
      Defense = stats[1];
      Speed = stats[2];
      Health = stats[3];

      if(Health <= 0){
        Die();
      }
    }

    public void Add_Status_Effect(GameObject new_status_effect){
      status_effects.Add(new_status_effect);
      new_status_effect.transform.parent = transform;
    }

    public void Remove_Status_Effect(GameObject new_status_effect){
      status_effects.Remove(new_status_effect);
    }

    // returns list of all children GameObjects with component of type Move_Behaviour
    public List<GameObject> Get_Moves(){
      List<GameObject> Moves = new List<GameObject>();
      foreach (Move_Behaviour child in GetComponentsInChildren<Move_Behaviour>()){
          Moves.Add(child.gameObject);
      }
      return Moves;
    }

    public bool Is_Alive(){
      return Alive;
    }

    // Methods
    public void Trigger_Status_Effects(){
      foreach(GameObject status_effect in status_effects){
        status_effect.GetComponent<Status_Effect_Behaviour>().Tick_Down();
      }
    }

    // checks if a target is valid for a move (move is given as int)
    public bool Is_Valid_Move(int move_pos, GameObject targetGO){
      return Is_Valid_Move(Get_Moves()[move_pos], targetGO);
    }

    // checks if a target is valid for a move (move is given as GameObject)
    public bool Is_Valid_Move(GameObject moveGO, GameObject targetGO){
      return moveGO.GetComponent<Move_Target_Type>().Valid_Target(targetGO);
    }

    // uses a move on a target (move is given as int)
    public void Use_Move(int move_pos, GameObject targetGO){
      Use_Move(Get_Moves()[move_pos], targetGO);
    }

    // uses a move on a target (move is given as GameObject)
    public bool Use_Move(GameObject moveGO, GameObject targetGO){
      if(Is_Valid_Move(moveGO, targetGO)){
        animator.SetTrigger("Attack");
        if(moveGO.transform.parent != transform){
          throw new ArgumentException("Roguemon can't use move that is not assigned to it (=> child)");
        } else {
          StartCoroutine(Use_Move_Coroutine(moveGO, targetGO));
        }
        return true;
      } else {
        return false;
      }
    }

    // need to be able to delay (in order to wait for the anim)
    public IEnumerator Use_Move_Coroutine(GameObject moveGO, GameObject targetGO){
      yield return new WaitForSeconds(.25f);
      moveGO.GetComponent<Move_Behaviour>().Do_Move(targetGO, this.Damage);
    }

    public void Heal(float amount){
      float[] stats = Get_Stats();
      stats[3] = stats[3] + amount;
      Set_Stats(stats);
    }

    public void Take_Damage(float amount){
      float[] stats = Get_Stats();
      stats[3] = stats[3] - amount;
      Set_Stats(stats);
      animator.SetTrigger("Take_Damage");
    }

    public void Die(){
      if(Alive){
        animator.SetTrigger("Die");
        Alive = false;
      }
    }

}
