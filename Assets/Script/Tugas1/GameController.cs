using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Text")]
    // 0 = title ; 1 = Button
    [SerializeField] private Text[] text; 
    private string[] _text;

    [Header("Button")]
    [SerializeField] private GameObject btn;

    private Animator anim;
    private bool isOpen;

    private void Start()
    {
        GameObject _anim = GameObject.Find("Anim");
        anim = _anim.GetComponent<Animator>();

        isOpen = false;
        ValueText();
        SetText();

    }

    private void Update()
    {
        if(isOpen == false)
            btn.GetComponent<Button>().onClick.AddListener(SetAnimOn);
        if(isOpen == true)
            btn.GetComponent<Button>().onClick.AddListener(SetAnimOff);

    }

    private void ValueText()
    {
        _text = new string[4];
        _text[0] = "Selamat Datang\nDi\nWuhan China";
        _text[1] = "Buka Angpao";
        _text[2] = "Selamat Menikmati Corona <3";
        _text[3] = "Kembali Keawal";
    }

    private void SetText()
    {
        for (int i = 0; i < text.Length; i++)
            text[i].text = _text[i];
    }

    private void SetAnimOff()
    {
        anim.SetBool("_virusKeluar", false);
        text[0].text = _text[0];
        text[1].text = _text[1];
        isOpen = false;
    }

    private void SetAnimOn()
    {
        anim.SetBool("_virusKeluar", true);
        text[0].text = _text[2];
        text[1].text = _text[3];
        isOpen = true;

    }
}
