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

    // Constructor
    public Roguemon_Behaviour(float Dmg, float Def, float Spd, float HP){
      Set_Stats(new float[]{Dmg, Def, Spd, HP});
    }

    // Getter and Setter
    public float[] Get_Stats(){
      return new float[]{Damage, Defense, Speed, Health};
    }

    public void Set_Stats(float[] Stats){
      if (Stats.Length != 4){
        throw new ArgumentException("Setting stats requires an array with four floats");
      }

      if (Stats[0] < 0 || Stats[1] < 0 || Stats[2] < 0 || Stats[3] < 0){
        throw new ArgumentException("Can't set a stat to a negative value");
      }

      Damage = Stats[0];
      Defense = Stats[1];
      Speed = Stats[2];
      Health = Stats[3];
    }

}
