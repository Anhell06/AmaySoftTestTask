using Assets.CodeBase.AssetLoader;
using Assets.CodeBase.Infracstructure;
using Assets.CodeBase.StaticData;
using System;
using UnityEngine;

namespace Assets.CodeBase.StateMachine.State
{
    public class BootstrapState : IEnterInState
    {
        private IGameStateMachine _stateMachine;
        private IServiceLocator _services;

        public BootstrapState(IGameStateMachine stateMachine, IServiceLocator services)
        {
            _stateMachine = stateMachine;
            _services = services;
            RegestrateService();
        }

        private void RegestrateService()
        {
            _services.RegestrateService<IAssetProvider>(new AssetProvider());
            _services.RegestrateService<IStaticDataService>(new StaticDataService(_services.GetService<IAssetProvider>()));
            _services.RegestrateService<IGameFactory>(new GameFactory(_services.GetService<IStaticDataService>(), _services.GetService<IAssetProvider>()));
        }

        public void Enter()
        {
            _stateMachine.Enter<LoadLevelState>();
        }

        public void Exit()
        {
        }
    }
}