using MultiInputClient.Enums;
using MultiInputClient.Interfaces;
using SDL3;

namespace MultiInputClient.SceneLogic;

public class HostSceneLogic
{
    private IScene? _scene;
    public void Initialize(object? o){
        _scene = o as IScene;
        Awake();
        while (MainWindow.ActiveScene == _scene) {
            Update();
        }
    }

    private void Awake(){
        
    }

    private void Update(){
        
    }
}