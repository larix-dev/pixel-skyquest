using UnityEngine;

namespace Handlers {
public class ObjectBreakHandler : HitHandler {
    public GameObject drop;
    public AudioClip breakSound;

    public delegate void BreakAction();

    public event BreakAction OnBreak;

    public override void HandleHit() {
        AudioSource.PlayClipAtPoint(breakSound, gameObject.transform.position, 0.25f);
        OnBreak?.Invoke();
        DropItem();
        Destroy(gameObject);
    }

    private void DropItem() {
        if (!drop) return;
        var o = gameObject;
        drop.transform.position = o.transform.position;
        drop.layer = o.layer;
        foreach (var sr in drop.GetComponentsInChildren<SpriteRenderer>()) {
            sr.sortingLayerName = GetComponent<SpriteRenderer>().sortingLayerName;
        }

        Instantiate(drop);
    }
}
}