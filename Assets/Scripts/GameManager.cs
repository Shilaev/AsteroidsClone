using CameraFeatures;
using ObjectPool;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
    }

    public static GameManager instance;

    [SerializeField] private Pool _pool;
    [SerializeField] private int _numberOfAsteroids;
    [SerializeField] private Menu _menu;
    [SerializeField] private UI _ui;
    [SerializeField] private SpaceShip _userSpaceShip;

    public UnityEvent OnGameStoped;
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
        if (Keyboard.current.yKey.wasReleasedThisFrame) StopGame();
    }

    private void SetGameState(GameState gameState)
    {
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
    }

    public void StopGame()
    {
        OnGameStoped?.Invoke();
    }

    public void RestartGame()
    {
    }

    private void PauseGame()
    {
    }

    private void NextLevel()
    {
    }

    private void ChangeScene()
    {
    }
}