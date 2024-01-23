using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTextController : MonoBehaviour
{
    [SerializeField] private Text timetext;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timetext.text = DateTime.Now.ToString("hh:mm");
    }
}
