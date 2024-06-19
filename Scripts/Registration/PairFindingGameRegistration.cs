using Core.Game;
using Core.Services;
using Infrastructure.Core;
using PairFindingGame.Services;
using UnityEngine;

namespace PairFindingGame
{
    public class PairFindingGameRegistration : RegistrationBase
    {
        [SerializeField] private GameConfigurationService ConfigurationService;
        
        protected override void RegisterServices(IRegistrar registrar)
        {
            registrar.Register<IConfigurationService, GameConfigurationService>(ConfigurationService);
            registrar.Register<IGameService, PairFindingGame>();
            registrar.Register<ChipTypesService>();
        }
    }
}