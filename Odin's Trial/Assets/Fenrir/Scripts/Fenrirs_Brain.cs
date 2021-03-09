using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine;

public class Fenrirs_Brain : MonoBehaviour
{
    //*******************DECLARIATIONS*******************//

    //public VAR
    public GameObject player;
    public AudioClip[] footsteps;
    public Transform eyes;
    public AudioSource growl;
    public GameObject deathCam;
    public Transform camPos;

    //private VAR
    private NavMeshAgent nav;
    private AudioSource sound;
    private Animator anim;

    private float wait = 0f;

    private string state = "idle";
    private bool active = true;
    private bool hightAlert = false;
    private float alertness = 20f;

    //***************************************************//



    //*********************MAIN CODE*********************//

    //START FN
    void Start()
    {
        //NAV: gets NavMesh component 
        //allows for adjustable speed
        nav = GetComponent<NavMeshAgent>();
        nav.speed = 10f;

        //ANIM: gets animator component 
        //allows for adjustable animation speed
        anim = GetComponent<Animator>();
        anim.speed = 10f;

        //SOUND: gets sound component
        sound = GetComponent<AudioSource>();
    }


    //FOOTSTEPS FN
    public void Footsteps(int num)
    {
        //Allows for multiple footstep audio 
        //clips for all four feet
        sound.clip = footsteps[num];
        sound.Play();
    }


    //CHECKSIGHT FN
    public void CheckSight()
    {
        //Checks if the player is in view and changes state accordingly
        if (active) {
            RaycastHit rayHit;
            if (Physics.Linecast(eyes.position, player.transform.position, out rayHit)) {
                if(rayHit.collider.gameObject.name == "Player") {
                    if (state != "kill") {
                        state = "Chase";
                        nav.speed = 15f;
                        anim.speed = 15f;
                        growl.Play(); } } } } }


    //UPDATE FN
    void Update()
    {
        if (active)
        {
            anim.SetFloat("Velocity", nav.velocity.magnitude);


            //IDLE STATE: Allows Fenrir to wander around while "idle"
            if (state == "idle")
            {
                Vector3 randomPos = Random.insideUnitSphere * alertness;
                NavMeshHit navHit;
                NavMesh.SamplePosition(transform.position + randomPos, out navHit, 20f, NavMesh.AllAreas);

                if (hightAlert)
                {
                    NavMesh.SamplePosition(player.transform.position + randomPos, out navHit, 20f, NavMesh.AllAreas);
                    alertness += 5f;
                    if (alertness > 20f)
                    {
                        hightAlert = false;
                        anim.speed = 10f;
                        nav.speed = 10f;
                    }
                }

                nav.SetDestination(navHit.position);
                state = "walk";
            }


            //WALK STATE: Fenrir walks around
            if (state == "walk")
            {

                if (nav.remainingDistance <= nav.stoppingDistance && !nav.pathPending)
                {
                    state = "search";
                    wait = 5f;
                }
            }


            //SEARCH STATE: Fenrir searches for player
            if (state == "search")
            {
                if (wait > 0f)
                {
                    wait -= Time.deltaTime;
                    transform.Rotate(0f, 120f * Time.deltaTime, 0f);
                }
                else
                {
                    state = "idle";
                }
            }


            //CHASE STATE: Fenrir chases player
            if (state == "chase")
            {
                nav.SetDestination(player.transform.position);
                float distance = Vector3.Distance(transform.position, player.transform.position);
                if (distance > 10f)
                {
                    state = "hunt";
                }
                //KILLS PLAYER IF CAUGHT
                else if (nav.remainingDistance <= nav.stoppingDistance + 1 && !nav.pathPending)
                {
                    if (player.GetComponent<PlayerBlah>().alive)
                    {
                        state = "kill";
                        player.GetComponent<PlayerBlah>().alive = false;
                        // ***DISABLE PLAYER CONTROLLER*** // player.GetComponent<PlayerBlah>().enabled = false;
                        deathCam.SetActive(true);
                        deathCam.transform.position = Camera.main.transform.position;
                        deathCam.transform.rotation = Camera.main.transform.rotation;
                        Camera.main.gameObject.SetActive(false);
                        growl.pitch = 0.7f;
                        growl.Play();
                        Invoke("reset", 1f);
                    }
                }
            }
            
            
            //HUNT STATE: Fenrir hunts player
            if (state == "hunt")
            {
                if (nav.remainingDistance <= nav.stoppingDistance && !nav.pathPending)
                {
                    state = "search";
                    wait = 5f;
                    hightAlert = true;
                    alertness = 5f;
                    CheckSight();
                }
            }


            //KILL STATE: Fenrir kills player
            if (state == "kill")
            {
                deathCam.transform.position = Vector3.Slerp(deathCam.transform.position, camPos.position, 10f * Time.deltaTime);
                deathCam.transform.rotation = Quaternion.Slerp(deathCam.transform.rotation, camPos.rotation, 10f * Time.deltaTime);
                anim.speed = 1f;
                nav.SetDestination(deathCam.transform.position);
            }



        }
    }

    private void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    //***************************************************//
}
