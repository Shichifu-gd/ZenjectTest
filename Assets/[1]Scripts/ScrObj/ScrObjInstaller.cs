using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SoInstaller", menuName = "Create SoInstaller")]
public class ScrObjInstaller : ScriptableObjectInstaller
{
    [SerializeField]
    private Configuration configuration;

    [SerializeField]
    private GameObject HeroPre;

    public override void InstallBindings()
    {
        Container.BindInstance(configuration);
        Container.BindInstance(HeroPre);
    }
}