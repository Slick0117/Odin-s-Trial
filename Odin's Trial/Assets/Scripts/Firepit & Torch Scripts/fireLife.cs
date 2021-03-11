using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class fireLife : MonoBehaviour
{
    public playerInventory Inventory;
    public ParticleSystem fire;
    public bool fireisOn;
    public GameObject safeLight;
    private bool playerHasWood;
    public GameObject noWood;
    public playerInteract player;
    public bool playerInteracted;
    AudioSource fireAudio;
  

    // Start is called before the first frame update
    void Start()
    {

        fire = GetComponent<ParticleSystem>();
        noWood.SetActive(false);
        fireAudio = GetComponent<AudioSource>();
    
    }

    
    // Update is called once per frame
    void Update()
    {
        
        doesPlayerHaveWood();
        turnoffLight();
        startFire();

        checkifFireisOn();
    }

    void turnoffLight()
    {
        if (fire.isPlaying)
        {

            safeLight.SetActive(true);

        }
        if (fire.isStopped)
        {

            safeLight.SetActive(false);


        }


    }

    void startFire()
    {

        if (Input.GetKeyDown(KeyCode.E) && playerHasWood == true && player.playeriswithDistance == true)
        {

            fire.Play();
            playerInteracted = true;
            fireAudio.Play();

        }
        else if (Input.GetKeyDown(KeyCode.E) && playerHasWood == false && player.playeriswithDistance == true)
        {

            noWood.SetActive(true);
            removeText();
        }

    }

    void removeText()
    {

        StartCoroutine(RemoveAfterSeconds(3, noWood));
    }

    IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
    }


    void doesPlayerHaveWood()
    {
        if (Inventory.woodCount == 1)
        {

            playerHasWood = true;


        }

        if (Inventory.woodCount <= 0)
        {

            playerHasWood = false;
        }



    }

    void checkifFireisOn() 
    {

        if (fire.isPlaying)
        {

            fireisOn = true;
        
        }

        if (fire.isStopped) 
        {


            fireisOn = false;
            fireAudio.Pause();
        
        }
    
    
    }

}
