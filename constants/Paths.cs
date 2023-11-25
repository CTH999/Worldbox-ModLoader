using System.Reflection;
using UnityEngine;

namespace NeoModLoader.constants;

public static class Paths
{
    public static readonly string NMLModPath = Assembly.GetExecutingAssembly().Location;

    //public static readonly string NMLModPath =
    //    @"C:\Program Files (x86)\Steam\steamapps\common\worldbox\worldbox_Data\StreamingAssets\mods\NeoModLoader.dll";
    public static readonly string NMLPath = Combine(NMLModPath, "..", "NML");

    public static readonly string PersistentDataPath = Combine(Application.persistentDataPath);
    public static readonly string StreamingAssetsPath = Combine(Application.streamingAssetsPath);
    public static readonly string ManagedPath = Combine(StreamingAssetsPath, "..", "Managed");
    public static string GamePath => Application.platform switch {
        RuntimePlatform.WindowsPlayer => Combine(StreamingAssetsPath, "..", ".."),
        RuntimePlatform.LinuxPlayer => Combine(StreamingAssetsPath, "..", ".."),
        RuntimePlatform.OSXPlayer => Combine(StreamingAssetsPath, "..", "..", "..", "..", ".."),
        _ => Combine(StreamingAssetsPath, "..", "..")
    };

    public static readonly string ModsConfigPath = Combine(PersistentDataPath, "mods_config");

    public static readonly string BepInExPluginsPath = Combine(GamePath, "BepInEx", "plugins");
    public static readonly string ModsPath = Combine(GamePath , "Mods");

    public static readonly string NMLAssembliesPath = Combine(NMLPath, "Assemblies");
    public static readonly string CompiledModsPath = Combine(NMLPath , "CompiledMods");
    public static readonly string ModCompileRecordPath = Combine(NMLPath, "mod_compile_records.json");
    public static readonly string ModsDisabledRecordPath = Combine(NMLPath, "disabled_mods.txt");
    public static readonly string ModDeclarationFileName = "mod.json";
    public static readonly string ModDefaultConfigFileName = "default_config.json";
    public static readonly string ModResourceFolderName = "GameResources";
    public static readonly string CommonModsWorkshopPath = Combine(GamePath, "..", "..", "workshop", "content", CoreConstants.GameId.ToString());
    public static readonly string NCMSModEmbededResourceFolderName = "EmbededResources"; // note that this typo in "Embedded" has to stay, as NCMS also has it
    public static readonly HashSet<string> IgnoreSearchDirectories = new HashSet<string>()
    {
        "bin", "obj", "Properties", "packages", "packages.config", "packages-lock.json", "packages-lock.xml",
    };
    
    internal static readonly string LinuxSteamLocalConfigPath = "~/.local/share/Steam/userdata/{0}/config/localconfig.vdf";
    private static string Combine(params string [] paths) => new FileInfo(paths.Aggregate("", Path.Combine)).FullName;
}