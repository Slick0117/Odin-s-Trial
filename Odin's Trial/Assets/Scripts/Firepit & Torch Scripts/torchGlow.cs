using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchGlow : MonoBehaviour
{
    ParticleSystem glow;
   public playerInteract player;
   public  bool isitGlowing;
    // Start is called before the first frame update
    void Start()
    {
        glow = GetComponent<ParticleSystem>();
        glow.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        playParticles();
        isGlowOn();
    }

    void playParticles() 
    {

        if (Input.GetKeyDown(KeyCode.F) && player.playeriswithDistance == true)
        {


            Debug.Log("Light em up");
            glow.Play();

        }


    }

    void isGlowOn ()
    {

        if (glow.isPlaying) 
        {

            isitGlowing = true;
        
        }

        if (glow.isStopped) 
        {

            isitGlowing = false;
        
        
        }
    
    
    }




}
