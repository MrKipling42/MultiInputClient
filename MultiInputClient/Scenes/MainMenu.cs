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
        Return @return = new Return(SceneId.MainMenu);
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