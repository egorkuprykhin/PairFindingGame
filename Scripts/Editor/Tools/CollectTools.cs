using Editor;
using Infrastructure.Common;
using UnityEditor;
using UnityEngine;
using Logger = Editor.Logger;

namespace PairFindingGame.Editor.Tools
{
    public static class CollectTools
    {
        [MenuItem(Constants.Tools.CollectPairFindingConfiguration)]
        public static void CollectPairFindingGameConfiguration()
        {
            var configuration = EditorExtensions.GetSingleByName<Configuration>(Constants.Configurations.PairFindingGameConfiguration);
            if (configuration)
            {
                var assetPath = AssetDatabase.GetAssetPath(configuration);
                configuration.CollectSettings(assetPath);
                
                Logger.LogColored("Done", Color.green);
            }
        }
    }
}