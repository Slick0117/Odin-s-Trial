using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchScript : MonoBehaviour
{
    public ParticleSystem fire;
    public playerInteract player;
    public bool istorchLit;
    public fireLife firepit;
    public GameObject nofire;
    // Start is called before the first frame update
    void Start()
    {
        fire = GetComponent<ParticleSystem>();
        fire.Stop();
        nofire.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        lightFire();
        isitLit();
    }

    void lightFire() 
    {

        if (Input.GetKeyDown(KeyCode.F) && player.playeriswithDistance == true && firepit.fireisOn == true)
        {


            Debug.Log("Light em up");
            fire.Play();
          
        }

        if (Input.GetKeyDown(KeyCode.F) && player.playeriswithDistance == true && firepit.fireisOn == false)
        {

            nofire.SetActive(true);
            removeText();


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

    void removeText()
    {

        StartCoroutine(RemoveAfterSeconds(3, nofire));
    }

    IEnumerator RemoveAfterSeconds(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
    }

}
