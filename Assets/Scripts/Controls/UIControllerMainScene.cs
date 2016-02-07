using UnityEngine;
using System.Collections;

public class UIControllerMainScene : MonoBehaviour {

    public GameObject office;
    public GameObject bedroom;

    private Player player;
    private const string OFFICE = "office";
    private const string BEDROOM = "bedroom";

    void Start () {
        this.player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}

    void Update() {
        foreach (Collectible item in player.inventory.items) {
            if (item.identifier == OFFICE) {
                office.SetActive(true);
            } else if (item.identifier == BEDROOM) {
                bedroom.SetActive(true);
            }
        }
    }

}
