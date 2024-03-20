using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;
using System;

public class InfoItem : MonoBehaviour
{
    private bool showText = false;
   [SerializeField]
    public AudioClip _audioClip;
    public AudioSource _audioSource;
    public Animation _animation;
    public string ObjeInfo;


    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        if (!showText)
            showText = true;
        if (_audioSource == null)
        {
            Debug.LogError("The AudioSource in the player NULL");
        }
        else
        {
            _audioSource.clip = _audioClip;
        }
        //_audioSource.Play();
    }
}
