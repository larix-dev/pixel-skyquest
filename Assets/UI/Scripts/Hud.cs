using Objectives;
using TMPro;
using UnityEngine;

namespace UI.Scripts {
public class Hud : MonoBehaviour {
    private static readonly int ShowText = Animator.StringToHash("ShowText");

    public int floorNumber;
    public string floorName;

    private GameObject _menu;
    private GameObject _tutorialHud;
    private SceneLoader _sceneLoader;

    private void Start() {
        var levelDisplay = Helpers.FindChild(gameObject, "LevelDisplay").GetComponent<TextMeshProUGUI>();
        levelDisplay.SetText($"Floor {floorNumber}: {floorName}");

        var player = GameObject.FindWithTag("Player").GetComponent<Player>();
        if (player) {
            var keyIcon = Helpers.FindChild(gameObject, "HUDKeyIcon");
            player.KeyEvent += keyIcon.SetActive;
        }

        var objectiveHandler = FindAnyObjectByType<ObjectiveHandler>();
        if (objectiveHandler) {
            var objectiveAnim = Helpers.FindChild(gameObject, "ObjectiveDisplay").GetComponent<Animator>();
            foreach (var objective in objectiveHandler.objectives) {
                objective.OnComplete += () => objectiveAnim.SetTrigger(ShowText);
            }
        }

        _menu = Helpers.FindChild(gameObject, "Menu");
        _tutorialHud = GameObject.Find("TutorialHUD");
        _sceneLoader = FindAnyObjectByType<SceneLoader>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            ToggleMenu(!_menu.activeSelf);
        }
    }

    public void ToggleMenu(bool active) {
        _menu.SetActive(active);
        if (_tutorialHud) {
            _tutorialHud.SetActive(!active);
        }
    }

    public void QuitToTitle() {
        _sceneLoader.LoadScene("TitleScreen");
    }
}
}