using _Scripts.Game.Services.Settings;
using _Scripts.Game.Services.Sound;
using _Scripts.Infrastructure.Singleton;
using _Scripts.Infrastructure.StateMachines.App.FSM;
using _Scripts.Infrastructure.StateMachines.Common.States;
using DG.Tweening;

namespace _Scripts.Infrastructure.StateMachines.App.States
{
    public class InitializationState : IState, IService
    {
        private readonly IAppStateMachine _appStateMachine;
        private readonly ISoundService _soundService;
        
        public InitializationState(IAppStateMachine appStateMachine,
            ISoundService soundService)
        {
            _appStateMachine = appStateMachine;
            _soundService = soundService;
        }

        public void Enter()
        {
            DOTween.Init();
            
            _soundService.PlaySoundInLoop(SoundID.SoundTrack, SoundGroupID.Music);
            _appStateMachine.Enter<StartState>();
        }

        public void Exit()
        {
        }
    }
}