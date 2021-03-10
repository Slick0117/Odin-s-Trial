using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateSticks : MonoBehaviour
{
    public GameObject Prefab;
    private int minxrange = 300;
    private int maxxrange = 700;

    private List<Transform> _instances = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject wood = Instantiate(Prefab, new Vector3(transform.position.x + 1, 0, transform.position.z + 1)) as GameObject;
            wood.transform.parent = transform;
        }
    }
}
