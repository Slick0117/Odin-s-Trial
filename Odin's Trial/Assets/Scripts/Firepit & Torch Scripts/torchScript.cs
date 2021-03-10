using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchScript : MonoBehaviour
{
    public ParticleSystem fire;
    public playerInteract player;
    // Start is called before the first frame update
    void Start()
    {
        fire = GetComponent<ParticleSystem>();
        fire.Stop();
        
    }

    // Update is called once per frame
    void Update()
    {
        lightFire();
    }

    void lightFire() 
    {

        if (Input.GetKeyDown(KeyCode.F) && player.playeriswithDistance == true) 
        {


            Debug.Log("Light em up");
            fire.Play();


        }
    
    
    }

}
