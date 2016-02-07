using UnityEngine;
using System.Collections;

public class UIControllerBullethell : MonoBehaviour {

    private Player player;

    public GameObject third;
    public GameObject second;
    public GameObject first;

    void Start () {
        this.player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        third.SetActive(true);
        second.SetActive(true);
        first.SetActive(true);
    }
	
	void Update () {
        if (player.Hits < 3) {
            third.SetActive(false);
        }
        if (player.Hits < 2) {
            second.SetActive(false);
        }
        if (player.Hits < 1) {
            first.SetActive(false);
        }
    }
}
