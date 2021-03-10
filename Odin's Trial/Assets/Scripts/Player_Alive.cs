using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Alive : MonoBehaviour
{
    public bool alive = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Eyes")
        {
            other.transform.parent.GetComponent<Fenrir_AI>().CheckSight();
        }

    }
}
