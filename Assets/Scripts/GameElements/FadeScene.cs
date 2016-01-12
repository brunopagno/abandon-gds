using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FadeScene : MonoBehaviour {

    public Texture2D fadeTexture;
    public float fadeSpeed;

    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDir = -1;

    void OnGUI() {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
    }

    public IEnumerator FadeOutToScene(string scene) {
        UtilControls.Freeze();
        float fadeTime = BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(scene);
    }

    void OnLevelWasLoaded() {
        UtilControls.Unfreeze();
        BeginFade(-1);
    }

    private float BeginFade(int direction) {
        fadeDir = direction;
        return fadeSpeed;
    }

}
