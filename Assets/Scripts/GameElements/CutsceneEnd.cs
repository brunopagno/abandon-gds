using UnityEngine;
using System.Collections;

public class CutsceneEnd : MonoBehaviour {

    public void OnCutsceneEnd() {
        StartCoroutine(Camera.main.GetComponent<FadeScene>().FadeOutToScene("main"));
    }

    public void OnEndGame() {
        Destroy(GameObject.FindGameObjectWithTag("ThingsController"));
        StartCoroutine(Camera.main.GetComponent<FadeScene>().FadeOutToScene("opening"));
    }

}
