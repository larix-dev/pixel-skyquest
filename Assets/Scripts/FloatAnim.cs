using UnityEngine;

public class FloatAnim : MonoBehaviour {
    public float amplitude;
    public float speed;
    
    private GameObject _shadow;
    
    public void Awake() {
        _shadow = Helpers.FindChild(gameObject, "Shadow");
    }

    public void FixedUpdate() {
        var y = amplitude * Mathf.Sin(Time.time * speed);
        transform.localPosition = new Vector3(0, y, 0);
        _shadow.transform.localPosition = new Vector3(0, -y, 0);
    }
}