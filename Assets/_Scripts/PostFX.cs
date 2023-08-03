using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UIElements;

public class PostFX : MonoBehaviour
{
    [SerializeField] PostProcessVolume fxVolume;

    [SerializeField] bool enableFX = default;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ToggleFX(ref enableFX, ref fxVolume);
        }
    }

    private void ToggleFX(ref bool a, ref PostProcessVolume b)
    {
        a = !a;
        print("FXX");
        if(a)
        {
            b.enabled = true;
        }
        else
        {
            b.enabled = false;
        }
    }
}
