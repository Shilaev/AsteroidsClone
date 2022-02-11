using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("UI Elements/UI")]
public class UI : MonoBehaviour
{
    [SerializeField] private Text _userHp;
    [SerializeField] private Text  _enableAsteroids;
    [SerializeField] private Text _allAsteroidsCount;

    public Text UserHp
    {
        get => _userHp;
        set => _userHp = value;
    }

    public Text EnableAsteroids
    {
        get => _enableAsteroids;
        set => _enableAsteroids = value;
    }

    public Text AllAsteroidsCount
    {
        get => _allAsteroidsCount;
        set => _allAsteroidsCount = value;
    }
}
