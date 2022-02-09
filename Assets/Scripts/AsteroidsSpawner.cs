using CameraFeatures;
using ObjectPool;
using UnityEngine;
using UnityEngine.InputSystem;

public class AsteroidsSpawner : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        if (Keyboard.current.fKey.wasReleasedThisFrame)
        {
            var elem = Pool.GetElementFromPoolWithTag("asteroids");

            elem.transform.position = new Vector2(CameraBordersChecker.screenInCameraCoordsX + 20f,
                CameraBordersChecker.screenInCameraCoordsY + 20f);

            var randomForceDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            elem.GetComponent<Rigidbody2D>().AddForce(randomForceDirection * _speed, ForceMode2D.Impulse);

            elem.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
        }
    }
}