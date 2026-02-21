using ComponentsModule;
using UIModule;
using UnityEngine;
using Zenject;

namespace PlayerModule
{
    public class PlayerInstaller : MonoInstaller
    {
        [Header("References")] [SerializeField] private CharacterController characterController;
        [SerializeField] private Transform cameraRoot;
        [SerializeField] private Transform player;

        [Header("Movement")] [SerializeField] private float walkSpeed;
        [SerializeField] private float jumpHeight;
        [SerializeField] private float gravity;

        [SerializeField] private float mouseSensitivity;
        [SerializeField] private float lookMinX = 15;
        [SerializeField] private float lookMaxX = 30;

        [Header("Health")] [SerializeField] private int maxHealth;
        [SerializeField] private HealthView healthView;

        [Header("Wallet")] [SerializeField] private TextView wallet;

        private void OnValidate()
        {
            player ??= transform;
            characterController ??= GetComponent<CharacterController>();
        }

        public override void InstallBindings()
        {
            Container.Bind<CharacterController>()
                .FromInstance(characterController)
                .AsSingle();

            Container.Bind<Transform>()
                .FromInstance(player)
                .AsSingle();

            Container.Bind<IMoveComponent>()
                .To<MoveComponent>()
                .AsSingle()
                .WithArguments(walkSpeed, jumpHeight, gravity);

            Container.Bind<IRotationComponent>()
                .To<RotationComponent>()
                .AsSingle()
                .WithArguments(mouseSensitivity, lookMaxX, lookMinX);

            Container.Bind<IWallet>()
                .To<Wallet>()
                .AsSingle();

            Container.Bind(typeof(IHealthComponent), typeof(IDamageable))
                .To<HealthComponent>()
                .AsSingle()
                .WithArguments(maxHealth);

            Container.Bind<HealthView>()
                .FromInstance(healthView)
                .AsSingle();

            Container.BindInterfacesTo<HealthPresenter>()
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesTo<WalletPresenter>()
                .AsSingle()
                .WithArguments(wallet)
                .NonLazy();

            Container.BindInterfacesTo<PlayerMovementController>()
                .AsSingle()
                .NonLazy();
        }
    }
}