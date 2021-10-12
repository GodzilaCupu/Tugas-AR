using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    [Header("Text")]
    // 0 = title ; 1 = Button
    [SerializeField] private Text[] text;
    private string[] _text;

    [Header("Button")]
    [SerializeField] private GameObject btn;
    [SerializeField] private GameObject obj;

    private Animator anim;
    private AudioSource audio;
    private bool isOpen,isRotate;


    // Start is called before the first frame update
    void Start()
    {
        GameObject _controller = GameObject.Find("GameManager");
        GameObject _anim = GameObject.Find("Cube");
        anim = _anim.GetComponent<Animator>();
        audio = _controller.GetComponent<AudioSource>();

        isOpen = false;
        isRotate = false;
        ValueText();
        SetText();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen == false)
            btn.GetComponent<Button>().onClick.AddListener(Mulai);
        if (isOpen == true)
            btn.GetComponent<Button>().onClick.AddListener(Setop);

        Debug.Log(isOpen + "open");
        Debug.Log(isRotate + "rotate");
    }

    private void ValueText()
    {
        _text = new string[4];
        _text[0] = "go xi fa cai \n1442H";
        _text[1] = "Play";
        _text[2] = "Kembali Ke awal";
    }

    private void SetText()
    {
        for (int i = 0; i < text.Length; i++)
            text[i].text = _text[i];
    }

    private void Mulai()
    {
        anim.SetBool("Putar", true);
        audio.Play();
        isRotate = true;
        isOpen = true;
        text[1].text = _text[2];

    }

    private void Setop()
    {
        anim.SetBool("Putar", false);
        audio.Stop();
        text[1].text = _text[1];
        isRotate = false;
        isOpen = false;
        obj.transform.Rotate(0, 0, 0);
    }
}
