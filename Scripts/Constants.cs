namespace Infrastructure.Common
{
    public static partial class Constants
    {
#if UNITY_EDITOR
        public static partial class Tools
        {
            public const string AssignPairFindingGameScripts = "Tools/Assign Pair Finding Game Scripts To Configs";
            public const string CollectPairFindingConfiguration = "Tools/Collect Pair Finding Game Configuration Settings";
        }

        public static partial class Configurations
        {
            public const string PairFindingGameConfiguration = "_GameConfiguration";
        }

#endif
    }
}