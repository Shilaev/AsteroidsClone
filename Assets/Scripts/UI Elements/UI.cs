using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("UI Elements/UI")]
public class UI : MonoBehaviour
{
    [SerializeField] private Text _userHp;

    public Text UserHp
    {
        get => _userHp;
        set => _userHp = value;
    }
}
