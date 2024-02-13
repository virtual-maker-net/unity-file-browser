using System.Collections;
using UnityEngine;
using SFB;

public class BasicSample : MonoBehaviour {
    private string _path;

    void OnGUI() {
        var guiScale = new Vector3(Screen.width / 800.0f, Screen.height / 600.0f, 1.0f);
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, guiScale);

        GUILayout.Space(20);
        GUILayout.BeginHorizontal();
        GUILayout.Space(20);
        GUILayout.BeginVertical();

        // Open File Samples

        if (GUILayout.Button("Open File")) {
            WriteResult(SFB.OpenFilePanel("Open File", "", "", false));
        }
        GUILayout.Space(5);
        if (GUILayout.Button("Open File Async")) {
            SFB.OpenFilePanelAsync("Open File", "", "", false, (string[] paths) => { WriteResult(paths); });
        }
        GUILayout.Space(5);
        if (GUILayout.Button("Open File Multiple")) {
            WriteResult(SFB.OpenFilePanel("Open File", "", "", true));
        }
        GUILayout.Space(5);
        if (GUILayout.Button("Open File Extension")) {
            WriteResult(SFB.OpenFilePanel("Open File", "", "txt", true));
        }
        GUILayout.Space(5);
        if (GUILayout.Button("Open File Directory")) {
            WriteResult(SFB.OpenFilePanel("Open File", Application.dataPath, "", true));
        }
        GUILayout.Space(5);
        if (GUILayout.Button("Open File Filter")) {
            var extensions = new [] {
                new ExtensionFilter("Image Files", "png", "jpg", "jpeg" ),
                new ExtensionFilter("Sound Files", "mp3", "wav" ),
                new ExtensionFilter("All Files", "*" ),
            };
            WriteResult(SFB.OpenFilePanel("Open File", "", extensions, true));
        }

        GUILayout.Space(15);

        // Open Folder Samples

        if (GUILayout.Button("Open Folder")) {
            var paths = SFB.OpenFolderPanel("Select Folder", "", true);
            WriteResult(paths);
        }
        GUILayout.Space(5);
        if (GUILayout.Button("Open Folder Async")) {
            SFB.OpenFolderPanelAsync("Select Folder", "", true, (string[] paths) => { WriteResult(paths); });
        }
        GUILayout.Space(5);
        if (GUILayout.Button("Open Folder Directory")) {
            var paths = SFB.OpenFolderPanel("Select Folder", Application.dataPath, true);
            WriteResult(paths);
        }

        GUILayout.Space(15);

        // Save File Samples

        if (GUILayout.Button("Save File")) {
            _path = SFB.SaveFilePanel("Save File", "", "", "");
        }
        GUILayout.Space(5);
        if (GUILayout.Button("Save File Async")) {
            SFB.SaveFilePanelAsync("Save File", "", "", "", (string path) => { WriteResult(path); });
        }
        GUILayout.Space(5);
        if (GUILayout.Button("Save File Default Name")) {
            _path = SFB.SaveFilePanel("Save File", "", "MySaveFile", "");
        }
        GUILayout.Space(5);
        if (GUILayout.Button("Save File Default Name Ext")) {
            _path = SFB.SaveFilePanel("Save File", "", "MySaveFile", "dat");
        }
        GUILayout.Space(5);
        if (GUILayout.Button("Save File Directory")) {
            _path = SFB.SaveFilePanel("Save File", Application.dataPath, "", "");
        }
        GUILayout.Space(5);
        if (GUILayout.Button("Save File Filter")) {
            // Multiple save extension filters with more than one extension support.
            var extensionList = new [] {
                new ExtensionFilter("Binary", "bin"),
                new ExtensionFilter("Text", "txt"),
            };
            _path = SFB.SaveFilePanel("Save File", "", "MySaveFile", extensionList);
        }

        GUILayout.EndVertical();
        GUILayout.Space(20);
        GUILayout.Label(_path);
        GUILayout.EndHorizontal();
    }

    public void WriteResult(string[] paths) {
        if (paths.Length == 0) {
            return;
        }

        _path = "";
        foreach (var p in paths) {
            _path += p + "\n";
        }
    }

    public void WriteResult(string path) {
        _path = path;
    }
}
