using System.Windows;
using MultiInputClient.Enums;

namespace MultiInputClient.Interfaces;

public interface IScene
{
    public List<UIElement> Elements { get; set; }
    public SceneId SceneId { get; set; }
    void Initialize();
    void Load();
    void UnLoad();
}