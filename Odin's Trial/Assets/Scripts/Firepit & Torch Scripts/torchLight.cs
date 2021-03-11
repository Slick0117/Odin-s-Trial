using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchLight : MonoBehaviour
{
    Light lightsource;
    public torchScript torch;
    public torchGlow glow;
    public bool isTorchON;
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
            lightsource.range = 3.0f;
            lightsource.intensity = 16.0f;
            isTorchON = true;


        }
        else if (torch.istorchLit == false && glow.isitGlowing == true)
        {

            lightsource.range = 2.0f;
            lightsource.intensity = 8.0f;
            isTorchON = true;


        }

        else if (torch.istorchLit == false && glow.isitGlowing == false)
        {


            lightsource.intensity = 0.0f;
            isTorchON = false;

        }
    
    }
}
