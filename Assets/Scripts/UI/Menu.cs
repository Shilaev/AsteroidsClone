using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Text _StartGameText;

    public Text StartGameText => _StartGameText;
}