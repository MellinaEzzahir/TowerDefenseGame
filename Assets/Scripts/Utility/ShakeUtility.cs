using UnityEngine;
using System.Collections;

public static class ShakeUtility
{
    public enum ShakeSize { Small, Medium, Big }
    public static void Shake(GameObject obj, ShakeSize size)
    {
        float duration = 0.1f;
        float magnitude = 0.05f;

        switch (size)
        {
            case ShakeSize.Medium:
                duration = 0.2f;
                magnitude = 0.1f;
                break;

            case ShakeSize.Big:
                duration = 0.3f;
                magnitude = 10f;
                break;

        }
        obj.GetComponent<MonoBehaviour>().StartCoroutine(ShakeCoroutine(obj.transform, duration, magnitude));
    }

    private static IEnumerator ShakeCoroutine(Transform target, float duration, float magnitude)
    {
        Vector3 originalPos = target.localPosition;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            target.localPosition = originalPos + new Vector3(x, y, 0);

            elapsed += Time.deltaTime;
            yield return null;
        }

        target.localPosition = originalPos;
    }
}
