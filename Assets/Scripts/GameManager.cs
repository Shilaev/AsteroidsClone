using CameraFeatures;
using ObjectPool;
using UnityEngine;
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

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
    }

    private void Start()
    {
        SetUpGame();
        Debug.Log("Press f to start game");
    }

    private void Update()
    {
        if (Keyboard.current.fKey.wasReleasedThisFrame)
        {
            StartGame();
        }
    }

    private void SetGameState(GameState gameState)
    {
    }

    public void SetUpGame()
    {
        // Create and prepare all object pools
        _pool.Initialise();

        // show menu text
        _menu.StartGameText.gameObject.SetActive(true);

        // set up ui
        _ui.UserHp.text = _userSpaceShip.Hp.ToString();
        _userSpaceShip.OnHpChanged.AddListener(delegate
        {
            _ui.UserHp.text = _userSpaceShip.Hp.ToString();
        });
        
    }

    public void StartGame()
    {
        // hide menu text
        _menu.StartGameText.gameObject.SetActive(false);

        // Spawn asteroids
        var asteroidStartPosition = new Vector2(CameraBordersChecker.screenInCameraCoordsX + 20f,
                   CameraBordersChecker.screenInCameraCoordsY + 20f);
        AsteroidSpawner.SpawnAsteroid(_numberOfAsteroids, "BigAsteroids", asteroidStartPosition);
    }

    public void StopGame()
    {
        
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