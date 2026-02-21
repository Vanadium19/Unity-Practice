using ComponentsModule;
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
        [SerializeField] private float lookXLimit;

        [Header("Health")] [SerializeField] private int maxHealth;

        // [Header("Health")]
        // [SerializeField] private HealthView healthView;

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
                .WithArguments(mouseSensitivity, lookXLimit);

            Container.Bind(typeof(IHealthComponent), typeof(IDamageable))
                .To<HealthComponent>()
                .AsSingle()
                .WithArguments(maxHealth);

            // Container.Bind<HealthView>()
            //     .FromInstance(healthView)
            //     .AsSingle();
            //
            // Container.BindInterfacesTo<HealthPresenter>()
            //     .AsSingle()
            //     .NonLazy();
            //
            Container.BindInterfacesTo<PlayerMovementController>()
                .AsSingle()
                .NonLazy();
        }
    }
}