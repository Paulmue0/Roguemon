using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    [SerializeField] GameObject health_container;

    public void setHP(float hpNormalized){
        health_container.transform.transform.localScale = new Vector3(hpNormalized, 1f);
    }
}
