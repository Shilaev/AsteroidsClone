using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("UI Elements/Menu")]
public class Menu : MonoBehaviour
{
    [SerializeField] private Text _StartGameText;

    public Text StartGameText => _StartGameText;
}