using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientLight : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
