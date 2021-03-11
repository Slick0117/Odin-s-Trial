using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchSafeArea : MonoBehaviour
{
    public torchLight torch;
    public Collider safe;
    // Start is called before the first frame update
    void Start()
    {
        safe = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        turnoffSafeArea();
    }


    void turnoffSafeArea()
    {
        if (torch.isTorchON == true)
        {

            safe.enabled = true;

        }

        if (torch.isTorchON == false)
        {

            safe.enabled = false;

        }


    }
}
