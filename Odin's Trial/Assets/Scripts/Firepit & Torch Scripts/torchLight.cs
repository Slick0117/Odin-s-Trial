using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchLight : MonoBehaviour
{
    Light lightsource;
    public torchScript torch;
    // Start is called before the first frame update
    void Start()
    {
        lightsource = GetComponent<Light>();
       
    }

    // Update is called once per frame
    void Update()
    {
        changeIntensity();
    }

    void changeIntensity() 
    {

        if (torch.istorchLit == true)
        {

            lightsource.intensity = 16.0f;


        }

        if (torch.istorchLit == false)
        {


            lightsource.intensity = 0.0f;
        
        
        }
    
    }
}
