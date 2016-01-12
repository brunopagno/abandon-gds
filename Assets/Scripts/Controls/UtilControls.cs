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

}
