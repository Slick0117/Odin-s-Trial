using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firepitSafeArea : MonoBehaviour
{
    public fireLife firepit;
    public Collider safe;
    // Start is called before the first frame update
    void Start()
    {
        safe = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        turnoffSafeSpace();
    }

    void turnoffSafeSpace()
    {


        if (firepit.fireisOn == true)
        {


            safe.enabled = true;


        }

        if (firepit.fireisOn == false)
        {


            safe.enabled = false;

        }

    }
}
