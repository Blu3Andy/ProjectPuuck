using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class ReadSceneNames : MonoBehaviour
{
    public string[] scenes;
    private  string[] ReadNames(string sceneCue)
    {
        List<string> temp = new List<string>();
        // Scene[] scenes = SceneManager.GetAllScenes();
        var regex = new Regex(@"([^/]*/)*([\w\d\-]*)\.unity");
        
        // foreach (Scene S in scenes)
        // {
           
        //     if (S != null)
        //     {
        //         print(Time.time);
        //         string name = S.path.Substring(S.path.LastIndexOf('/')+1);
        //         name = name.Substring(0, name.Length - 6);
        //         print(sceneCue);
        //         if(name.Contains(sceneCue)) temp.Add(name);
        //         print(name);
        //     }
        // }

        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            var path = SceneUtility.GetScenePathByBuildIndex(i);
            string name = regex.Replace(path, "$2");
            print(name);
            if(name.Contains(sceneCue)) temp.Add(name);
        }
        print(temp.Count);
        return temp.ToArray();
    }
    
    
    public string[] PrintScenes(string input)
    {
        if (input == null) return null;
        return ReadNames(input);
    }
    
}