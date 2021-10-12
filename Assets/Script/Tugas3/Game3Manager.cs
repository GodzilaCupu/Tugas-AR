using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Vuforia;

public class Game3Manager : MonoBehaviour,IVirtualButtonEventHandler
{
    [SerializeField] private VirtualButtonBehaviour[] vbs = new VirtualButtonBehaviour[3];

    [SerializeField] private GameObject[] foto = new GameObject[3];
    [SerializeField] private GameObject video;
    [SerializeField] private Material[] materialfoto;

    void Start()
    {
        //for (int i = 0; i <= foto.Length; i++)
        //    foto[i].SetActive(false);

        //for (int i = 0; i <= vbs.Length; i++)
        //    vbs[i].RegisterEventHandler(this);
        vbs[0].RegisterEventHandler(this);
        vbs[1].RegisterEventHandler(this);
        vbs[2].RegisterEventHandler(this);

        video.GetComponent<VideoPlayer>().Stop();
        video.SetActive(false);
        foto[0].SetActive(false);
        foto[1].SetActive(false);
        foto[2].SetActive(false);
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if(vb.VirtualButtonName == "BTN_Name")
        {
            video.SetActive(true);
            video.GetComponent<VideoPlayer>().Play();

            for (int i = 0; i <= foto.Length; i++)
                foto[i].SetActive(false);
        }
        else if( vb.VirtualButtonName == "BTN_Job")
        {
            video.GetComponent<VideoPlayer>().Stop();
            video.SetActive(false);

            for (int i = 0; i <= foto.Length; i++)
            {
                foto[i].SetActive(true);

                foto[0].GetComponent<MeshRenderer>().material = materialfoto[0];
                foto[1].GetComponent<MeshRenderer>().material = materialfoto[1];
                foto[2].GetComponent<MeshRenderer>().material = materialfoto[2];
            }
        }else if (vb.VirtualButtonName == "BTN_Anggota")
        {
            video.SetActive(false);
            video.GetComponent<VideoPlayer>().Stop();

            for (int i = 0; i <= foto.Length; i++)
            {
                foto[i].SetActive(true);
                foto[0].GetComponent<MeshRenderer>().material = materialfoto[3];
                foto[1].GetComponent<MeshRenderer>().material = materialfoto[4];
                foto[2].GetComponent<MeshRenderer>().material = materialfoto[5];
            }
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("Test");
    }
}
