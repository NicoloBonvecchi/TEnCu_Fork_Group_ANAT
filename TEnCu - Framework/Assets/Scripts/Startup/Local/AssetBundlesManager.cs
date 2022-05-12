using System.IO;
using UnityEngine;

namespace Startup.Local
{
    public static class AssetBundlesManager
    {
        private const string AssetBundlePath = "AssetBundles/";
        public static void LoadAllAssetBundlesFromStorage()
        {
            var fileList = Directory.GetFiles(AssetBundlePath);
            foreach (var filename in fileList)
            {
                var assetBundle = AssetBundle.LoadFromFile(filename);
                if (assetBundle == null)
                {
                    Debug.LogError("Failed to load asset bundle: " + filename);
                    continue;
                }
                Utility.LocalStorageManager.AssetBundleManager.Instance.
                    SaveAssetBundle(assetBundle.name, assetBundle);
            }
        }
    }
}