using System.Windows;
using System.Windows.Controls;
using MultiInputClient.Enums;
using MultiInputClient.Interfaces;
using MultiInputClient.SceneLogic;

namespace MultiInputClient.Scenes;

public class HostScene : IScene
{
    public List<UIElement> Elements { get; set; } = new List<UIElement>();
    public SceneId SceneId { get; set; } = SceneId.Host;
    private Thread? Thread;
    public void Initialize(){
        TextBlock titleblock = new TextBlock();
        titleblock.Text = $"MultiInput Host";
        
    }

    public void Load(){
        Thread = new Thread(new HostSceneLogic().Initialize);
        Thread.Start(this);
    }

    public void UnLoad(){
    }
}