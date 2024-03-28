using UnityEngine;

public class AltarTrigger : MonoBehaviour {
    public GameObject altar;
    public Sprite altarActiveSprite;
    public GameObject portal;

    private SpriteRenderer _altarSr;

    public void Start() {
        _altarSr = altar.GetComponent<SpriteRenderer>();
    }

    public void TriggerAltar() {
        portal.SetActive(true);
        _altarSr.sprite = altarActiveSprite;
    }
}