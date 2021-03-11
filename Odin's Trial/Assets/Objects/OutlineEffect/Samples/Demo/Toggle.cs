using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace cakeslice
{
    public class Toggle : MonoBehaviour
    {
        public GameObject logs;
        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
            
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "wood")
            {

                logs.GetComponent<Outline>().enabled = true;


            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.tag == "wood") 
            {

                logs.GetComponent<Outline>().enabled = false;
            
            }
        }
    }

}