using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlah : MonoBehaviour
{
    public bool alive = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "eyes"){
            other.transform.GetComponent<Fenrirs_Brain>().CheckSight();            
        }

    }
}
