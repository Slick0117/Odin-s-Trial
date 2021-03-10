using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateSticks : MonoBehaviour
{
    public GameObject Prefab;
    private float interval = 0.1f;
    public int woodCount;
    public int maxwoodCount;
    // Start is called before the first frame update
    void Start()
    {
        woodCount = 0;

       if (maxwoodCount <= 0) return; 

        InvokeRepeating("generateSticks", 0f, interval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void generateSticks()
    {


            GameObject wood = Instantiate(Prefab, new Vector3(UnityEngine.Random.Range(0.0f, 1000.0f), 0.01f, UnityEngine.Random.Range(0.0f, 1000.0f)), Quaternion.identity) as GameObject;
            wood.transform.parent = transform;
             woodCount++;

        if (woodCount >= maxwoodCount) 
        { CancelInvoke(); }

    }
}
