using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ReadSceneNames : MonoBehaviour
{
    public string[] scenes;
    private  string[] ReadNames(string sceneCue)
    {
        List<string> temp = new List<string>();
        foreach (UnityEditor.EditorBuildSettingsScene S in UnityEditor.EditorBuildSettings.scenes)
        {
            if (S.enabled)
            {
                string name = S.path.Substring(S.path.LastIndexOf('/')+1);
                name = name.Substring(0, name.Length - 6);
                if(name.Contains(sceneCue)) temp.Add(name);
            }
        }
        return temp.ToArray();
    }
    
    
    public string[] PrintScenes(string input)
    {
        if (input == null) return null;
        return ReadNames(input);
    }
    
}