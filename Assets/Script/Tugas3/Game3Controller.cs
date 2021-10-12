using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class Game3Controller : MonoBehaviour,IVirtualButtonEventHandler
{
    public GameObject sphereGo, cubeGo;
    [SerializeField] private VirtualButtonBehaviour vbs1;
    // Start is called before the first frame update
    void Start()
    {
        vbs1.RegisterEventHandler(this); 

        sphereGo.SetActive(true);
        cubeGo.SetActive(true);
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        sphereGo.SetActive(true);
        cubeGo.SetActive(false);
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        cubeGo.SetActive(true);
        sphereGo.SetActive(false);
    }
}
