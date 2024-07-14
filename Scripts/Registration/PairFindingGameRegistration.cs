using Core.Game;
using Core.Services;
using Infrastructure.Core;
using PairFindingGame.Services;
using UnityEngine;

namespace PairFindingGame
{
    public class PairFindingGameRegistration : RegistrationBase
    {
        [SerializeField] public GameConfigurationService GameConfigurationService;

        public override int Order => 3;

        protected override void RegisterServices(IServicesRegistrar registrar)
        {
            registrar.Register<IConfigurationService, GameConfigurationService>(GameConfigurationService);
            registrar.Register<IGameService, PairFindingGame>();
            registrar.Register<ChipTypesService>();
        }
    }
}