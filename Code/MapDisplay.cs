using BepInEx;
using HarmonyLib;
using UnboundLib;
using UnityEngine;

namespace MapDisplay
{
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInPlugin(ModId, ModName, Version)]
    [BepInProcess("Rounds.exe")]

    public class MapDisplay : BaseUnityPlugin
    {
        public const string ModInitials = "MD";
        private const string ModId = "koala.map.display";
        private const string ModName = "Map Display";
        public const string Version = "1.0.0";

        
        public static MapDisplay instance { get; private set; }
        public GameObject MapNamer;
        public void Awake()
        {
            instance = this;
            Unbound.RegisterClientSideMod(ModId);
            var harmony = new Harmony(ModId);
            harmony.PatchAll();
        }
        public void Start()
        {
            MapNamer = new GameObject();
            MapNamer.name = "MapNamer";
            MapNamer.AddComponent<MapNamer>();
            DontDestroyOnLoad(MapNamer);
        }
    }
}
