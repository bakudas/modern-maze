using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class quadroSelect : MonoBehaviour
{

    public Text _text;
    private string _level;
    private bool _podeJogar;
    public bool PodeJogar
    {
        get => _podeJogar;
        set => _podeJogar = value;
    }

    private void Start()
    {
        _level = gameObject.name;
    }

    private void Update()
    {
        if (PodeJogar)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("lvl01");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _podeJogar = true;
        _text.text = $"Level {_level}\nPressione \"e\" para jogar";
        Debug.Log("estou no olhando para o nível");
    }

    private void OnTriggerExit(Collider other)
    {
        _text.text = "";
        _podeJogar = false;
    }
}
