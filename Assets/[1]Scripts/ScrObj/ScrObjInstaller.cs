using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SoInstaller", menuName = "Create SoInstaller")]
public class ScrObjInstaller : ScriptableObjectInstaller
{
    public ScrObjConfiguration configuration;
    public ScrObjPrefabs scrObjPrefabs;

    public override void InstallBindings()
    {
        Container.BindInstance(configuration);
        Container.BindInstance(scrObjPrefabs);
    }
}