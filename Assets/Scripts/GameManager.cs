using System;
using CameraFeatures;
using ObjectPool;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private Pool _pool;
    [SerializeField] private int _numberOfAsteroids;
    [SerializeField] private Menu _menu;
    [SerializeField] private UI _ui;
    [SerializeField] private SpaceShip _userSpaceShip;

    public UnityEvent OnGameStop;
    public UnityEvent OnGamePaused;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
    }

    private void Start()
    {
        SetUpGame();
    }

    private void Update()
    {
        if (Keyboard.current.fKey.wasReleasedThisFrame) StartGame();
        if (Keyboard.current.escapeKey.wasReleasedThisFrame) StopGame();
    }

    public void SetUpGame()
    {
        // Create and prepare all object pools
        _pool.Initialise();

        // show start game text
        _menu.StartGameText.gameObject.SetActive(true);

        // Space ship hp setup
        _ui.UserHp.text = _userSpaceShip.Hp.ToString();
        _userSpaceShip.OnHpChanged.AddListener(delegate { _ui.UserHp.text = _userSpaceShip.Hp.ToString(); });
    }

    public void StartGame()
    {
        // hide start game text
        _menu.StartGameText.gameObject.SetActive(false);

        // Spawn asteroids
        var spawnPoint = new Vector2(CameraBordersChecker.screenInCameraCoordsX + 20f,
            CameraBordersChecker.screenInCameraCoordsY + 20f);
        AsteroidManager.SpawnAsteroid(_numberOfAsteroids, "BigAsteroids", spawnPoint);

        // Asteroids count hp setup
        _ui.EnableAsteroids.text = (_numberOfAsteroids * 2).ToString();
        _ui.AllAsteroidsCount.text = (_numberOfAsteroids * 2).ToString();
    }

    public void SubstractOneAsteroidFromUi()
    {
        var value = Convert.ToInt32(_ui.EnableAsteroids.text);
        value--;
        _ui.EnableAsteroids.text = value.ToString();
    }

    public void StopGame()
    {
        _menu.StartGameText.gameObject.SetActive(true);
        OnGameStop?.Invoke();
    }
}