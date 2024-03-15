using UnityEngine;

namespace Cursor {
public class Cursor : MonoBehaviour {
    public Texture2D cursor;

    public void Start() {
        UnityEngine.Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }
}
}