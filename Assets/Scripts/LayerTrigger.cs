using UnityEngine;

public class LayerTrigger : MonoBehaviour {
    public string layer;
    public string sortingLayer;

    private void OnTriggerExit2D(Collider2D other) {
        other.gameObject.layer = LayerMask.NameToLayer(layer);
        other.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = sortingLayer;
        
        var srs = other.gameObject.GetComponentsInChildren<SpriteRenderer>();
        foreach (var sr in srs) {
            sr.sortingLayerName = sortingLayer;
        }
    }
}