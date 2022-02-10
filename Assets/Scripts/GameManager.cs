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
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            AsteroidSpawner.SpawnAsteroid(1, "BigAsteroids", Vector3.zero);
        }

        if (Keyboard.current.fKey.wasReleasedThisFrame)
        {
            StartGame();
        }
    }

    private void SetGameState(GameState gameState)
    {
    }

    private void SetUpGame()
    {
        // Create and prepare all object pools
        _pool.Initialise();
    }

    private void StartGame()
    {
        // Spawn asteroids
        var asteroidStartPosition = new Vector2(CameraBordersChecker.screenInCameraCoordsX + 20f,
                   CameraBordersChecker.screenInCameraCoordsY + 20f);
        AsteroidSpawner.SpawnAsteroid(_numberOfAsteroids, "BigAsteroids", asteroidStartPosition);
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