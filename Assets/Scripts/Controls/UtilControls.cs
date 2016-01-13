using UnityEngine;
using System.Collections;

public static class UtilControls {

    public static bool running = true;

    public static void Freeze() {
        running = false;
    }

    public static void Unfreeze() {
        running = true;
    }

    public static IEnumerator OneSecFreeze() {
        running = false;
        yield return new WaitForSeconds(0.2f);
        running = true;
    }

    public static IEnumerator CameraShake(float duration, float power) {
        Vector3 originalPosition = Camera.main.transform.position;

        while (duration > 0) {
            duration -= Time.deltaTime;
            Vector3 shake = new Vector3((Random.value - 0.5f) * power, (Random.value - 0.5f) * power, 0);
            Camera.main.transform.position = originalPosition + shake;
            yield return null;
        }
    }

}
