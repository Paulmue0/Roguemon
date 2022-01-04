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

      if(Health < 0){
        Die();
      }
    }

    public void Take_Damage(float amount){
      Debug.Log(name + " takes " + amount + " damage!");

      float[] stats = Get_Stats();
      stats[3] = stats[3] - amount;
      Set_Stats(stats);

    }

    public void Die(){
      Alive = false;
      Debug.Log(name + " has died :(");
    }

}
