using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ToggleWeigh : MonoBehaviour
{
    public bool toggleWeight = false;
    public Rig weightRig;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)) {
            toggleWeight = !toggleWeight;
        }
        if(toggleWeight)
        {
            weightRig.weight = 1;
        }
        else if(!toggleWeight) 
        { 
            weightRig.weight = 0;
        }
    }
}
