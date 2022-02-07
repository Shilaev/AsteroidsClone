using System.Collections;
using UnityEngine;

namespace ObjectPool
{
    [AddComponentMenu("Object Pool/Pool element")]
    public class PoolElement : MonoBehaviour
    {
        private void Update()
        {
            StartCoroutine(WaitSomeTime());
        }

        private IEnumerator WaitSomeTime()
        {
            yield return new WaitForSeconds(3);
            gameObject.SetActive(false);
        }
    }
}