using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine;

public class Fenrir_Prefab : MonoBehaviour
{
    //*******************DECLARIATIONS*******************//

    ////public VAR
    public GameObject player;
    //public AudioClip[] footsteps;
    //public AudioSource growl;
    //public GameObject deathCam;
    //public Transform camPos;
    //public Animator anim;
    ////public MeshRenderer mesh;

    ////private VAR
    private NavMeshAgent nav;
    //private AudioSource sound;

    //private float wait = 0f;

    //private string state = "chase";
    //private bool active = true;
    //private bool highAlert = false;
    //private float alertness = 20f;

    //***************************************************//
    // Start is called before the first frame update
    void Start()
    {
        //NAV: gets NavMesh component 
        //allows for adjustable speed
        nav = GetComponent<NavMeshAgent>();
        nav.speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(player.transform.position);
    }
}
