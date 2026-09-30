using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MultiInputClient.CustomElements.Buttons;
using MultiInputClient.Enums;
using MultiInputClient.Interfaces;

namespace MultiInputClient.Scenes;

public class MainMenu : IScene
{
    public List<UIElement> Elements { get; set; } = [];
    public SceneId SceneId { get; set; } = SceneId.MainMenu;
    
    public void Initialize(){
        TextBlock mainText = new TextBlock(){
            Text = $"MultiinputGui",
            FontSize = 48
        };
        Elements.Add(mainText);
        
        List<UIElement> returnButton = new ReturnButton(SceneId.Custom).Children;
        foreach (var uiElement in returnButton) Elements.Add(uiElement);

        List<UIElement> hostButton = new HostButton(SceneId.Host).Children;
        foreach (var uiElement in hostButton) Elements.Add(uiElement);
    }

    

    public void Load(){
        if (MainWindow.Window is null) {
            //SomeDebug stuff
            return;
        }

        foreach (var element in Elements) {
            MainWindow.Window.MainGrid.Children.Add(element);
        }
        
    }

    public void UnLoad(){
        if (MainWindow.Window is null) {
            //SomeDebug stuff
            return;
        }

        foreach (var element in Elements) {
            MainWindow.Window.MainGrid.Children.Remove(element);
        }
    }
}