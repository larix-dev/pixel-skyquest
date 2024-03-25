using TMPro;
using UnityEngine;

namespace UI.Scripts {
public class TutorialHud : MonoBehaviour {
    public TextAsset messages;
    public GameObject messageBox;
    public TextMeshProUGUI messageText;

    private string[] _messages;
    private int _curr;

    private class MessageData {
        public string[] Messages;
    }
    
    private void Start() {
        _messages = JsonUtility.FromJson<MessageData>(messages.text).Messages;
        UpdateText();
    }

    public void ShowHide() {
        messageBox.SetActive(!messageBox.activeSelf);
    }

    public void Cycle(int direction) {
        _curr = Mathf.Clamp(_curr + direction, 0, _messages.Length - 1);
        UpdateText();
    }

    private void UpdateText() {
        messageText.text = _messages[_curr];
    }
}
}