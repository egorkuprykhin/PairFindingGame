namespace Infrastructure.Common
{
    public static partial class Constants
    {
#if UNITY_EDITOR
        public static class PairFinding
        {
            public const string GameConfiguration = "_GameConfiguration";
            
            public static class Tools
            {
                public const string AssignGameScripts = "Tools/Assign Game Scripts To Configs";
                public const string CollectGameConfiguration = "Tools/Collect Game Configuration Settings";
                public const string BuildGameLogic = "Tools/Build Game Logic";
            }
        }
#endif
    }
}