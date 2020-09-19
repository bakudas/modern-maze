using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dispositivo : MonoBehaviour
{

    public Transform _water;
    public Text _text;
    
    private AudioSource _audio;
    private Animator _animator;
    public bool _ativado;
    private bool _podeUsar;
    private bool PodeUsar
    {
        get => _podeUsar;
        set => _podeUsar = value;
    }


    private void Start()
    {
        _ativado = true;
        _audio = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
        _water = _water.GetComponent<Transform>();
    }

    private void Update()
    {
        if (PodeUsar && _ativado)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                AtivaDispositivo();
            }
        }
    }

    private void AtivaDispositivo()
    {
        _audio.Play();
        _animator.Play("DESATIVADO");
        _ativado = false;
        Vector3 position = new Vector3(_water.position.x, _water.position.y - 1f, _water.position.z);
        _water.position = Vector3.Lerp(_water.position, position, 2);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        PodeUsar = true;
        _text.text = "Ativar dispositivo\n \"E\"";
    }

    private void OnTriggerExit(Collider other)
    {
        PodeUsar = false;
        _text.text = "";
    }
}
