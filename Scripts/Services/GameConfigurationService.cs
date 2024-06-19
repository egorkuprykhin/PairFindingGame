using Core.Services;
using Infrastructure.Common;
using Infrastructure.Core;
using Infrastructure.Services;
using Services.Core;
using UnityEngine;

namespace PairFindingGame
{
    public class GameConfigurationService : MonoService, IConfigurationService, IInitializableService
    {
        [SerializeField] private Configuration GameConfiguration;
        public ConfigurationProxy Configuration { get; private set; }

        public void Initialize()
        {
            Configuration = new ConfigurationProxy(GameConfiguration);
        }
    }
}