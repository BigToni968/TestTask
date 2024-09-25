using UnityEngine;
using Zenject;
using Game;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private Path _path;
    [SerializeField] private Audio _audio;

    public override void InstallBindings()
    {
        Container.BindInstance<IPath>(_path).AsSingle();
        Container.BindInstance(_audio).AsSingle();
    }
}