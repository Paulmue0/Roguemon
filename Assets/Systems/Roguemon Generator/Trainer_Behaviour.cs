using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trainer_Behaviour : MonoBehaviour
{

    public GameObject[] lineup = new GameObject[3];

    public GameObject[] Get_Lineup(){
      return lineup;
    }

    public void Set_Lineup(GameObject[] new_lineup){
      if(new_lineup.Length != 3){
        throw new ArgumentException("The lineup must be an array of size 3");
      }

      foreach(GameObject roguemonGO in new_lineup){
        if(roguemonGO.GetComponent(typeof(Roguemon_Behaviour)) as Roguemon_Behaviour == null){
          throw new ArgumentException("The lineup must consist of roguemon. (GameObject missing Roguemon_Behaviour)");
        }
      }
      lineup = new_lineup;
      Fix_Local_Position();
    }

    public void Fix_Local_Position(){
      for(int i = 0;i < lineup.Length;i++){
        GameObject roguemonGO = lineup[i];
        roguemonGO.transform.SetParent(gameObject.transform);
        roguemonGO.transform.localPosition += new Vector3(-1 + i*1, 0, 0);
      }
    }

    public GameObject Get_Roguemon(int position){
      if((position >= 3) || (position < 0)){
        throw new ArgumentException("Only 0 to 2 are valid positions");
      }
      return lineup[position];
    }

    public void Set_Name(string new_name){
      gameObject.name = new_name;
    }

    public string Get_Name(){
      return gameObject.name;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
