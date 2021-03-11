using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchScript : MonoBehaviour
{
    public ParticleSystem fire;
    public playerInteract player;
    public bool istorchLit;
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
        isitLit();
    }

    void lightFire() 
    {

        if (Input.GetKeyDown(KeyCode.E) && player.playeriswithDistance == true)
        {


            Debug.Log("Light em up");
            fire.Play();
          
        }
      
    
    
    }

    void isitLit() 
    
    {

        if (fire.isPlaying)
        {

            istorchLit = true;


        }
        else 
        {

            istorchLit = false;
        
        }
    
    }

}
