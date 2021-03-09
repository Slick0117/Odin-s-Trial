using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteract : MonoBehaviour
{
    public bool playeriswithDistance = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)

    {
        if (other.gameObject.tag == "interactLevel")
        {
            Debug.Log("COLLISION");
            playeriswithDistance = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        playeriswithDistance = false;
    }

}
