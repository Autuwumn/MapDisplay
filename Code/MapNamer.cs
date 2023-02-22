using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using UnboundLib;
using UnboundLib.GameModes;
using UnboundLib.Utils.UI;
using TMPro;

namespace MapDisplay
{
    public class MapNamer : MonoBehaviour
    {
        private string mapName;
        private static TextMeshProUGUI mapnamer;
        public void Start()
        {
            mapnamer = new GameObject().AddComponent<TextMeshProUGUI>();
            mapnamer.gameObject.name = "Map God";
            mapnamer.gameObject.transform.position = new Vector3(32f, -18.5f, 0f);
            mapnamer.gameObject.AddComponent<Canvas>().sortingLayerName = "MostFront";
            mapnamer.gameObject.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
            DontDestroyOnLoad(mapnamer.gameObject);
        }
        public void Update()
        {
            mapName = "placeHolderNameForNullChecks";
            for (var i = 0; i < SceneManager.sceneCount; i++)
            {
                var scene = SceneManager.GetSceneAt(i);
                if (!(scene.name == "Main" || scene.name == "DontDestroyOnLoad" || scene.name == "HideAndDontSave"))
                {
                    mapName = scene.name;
                }
            }
            if (mapName == "placeHolderNameForNullChecks")
            {
                mapnamer.alpha = 0f;
            }
            else
            {
                mapnamer.alpha = 1f;
            }
            mapnamer.text = "Current Map:\n" + mapName;
            mapnamer.fontSize = 18; 
        }
    }
}
