using UnityEditor;
using UnityEngine;

namespace Editor {
[InitializeOnLoad]
public class PixelSnap {
    private static int _ppu = 32;

    private static float Snap(float value) {
        return Mathf.Round(value * _ppu) / _ppu;
    }

    [MenuItem("Tools/Snap To Pixel Grid %#m")]
    private static void SnapToPixelGrid() {
        foreach (var t in Selection.transforms) {
            var pos = t.position;
            t.position = new Vector3(Snap(pos.x), Snap(pos.y), pos.z);
        }
    }

    [MenuItem("Tools/Configure Pixel Grid Snap PPU")]
    private static void ConfigurePpu() {
        PpuConfigWindow.OpenWindow();
    }

    private class PpuConfigWindow : EditorWindow {
        private int _configPpu = _ppu;

        public static void OpenWindow() {
            var window = GetWindow<PpuConfigWindow>();
            window.titleContent = new GUIContent("PPU Config");
            window.minSize = new Vector2(300, 80);
            window.maxSize = new Vector2(300, 80);
            window.Show();
        }

        private void OnGUI() {
            GUILayout.Label("Configure Pixel Grid Snap PPU");

            EditorGUILayout.BeginHorizontal();
            _configPpu = EditorGUILayout.IntField("PPU", _configPpu);
            if (GUILayout.Button("Apply") && _configPpu > 0) {
                _ppu = _configPpu;
                Close();
            }

            EditorGUILayout.EndHorizontal();

            if (_configPpu <= 0) {
                GUILayout.Label("PPU must be greater than zero");
            }
        }
    }
}
}