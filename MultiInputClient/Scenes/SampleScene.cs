using System.Windows;
using System.Windows.Controls;
using MultiInputClient.Enums;
using MultiInputClient.Interfaces;
using SDL3;

namespace MultiInputClient.Scenes;

public class SampleScene : IScene
{
    //Testing Scene for stuff Real
    public List<UIElement> Elements { get; set; } = new List<UIElement>();

    public TextBlock TextBlock { get; set; } = new TextBlock();
    public SceneId SceneId { get; set; } = SceneId.Custom;
    
    public void Initialize(){
        TextBlock.Text = $"Controllers:";
        TextBlock.FontSize = 16;
        TextBlock.TextWrapping = TextWrapping.Wrap;
        Elements.Add(TextBlock);
    }

    public void Load(){
        if (MainWindow.Window is null) {
            //SomeDebug stuff
            return;
        }

        foreach (var element in Elements) {
            MainWindow.Window.MainGrid.Children.Add(element);
        }
        Test();
    }
    
    
    public void Test(){
        uint[]? gamepads = SDL.GetGamepads(out var count);
        if (gamepads is null) {
            Console.WriteLine($"GamePads Null");
            return;
        }   

        if (count is 0) {
            Console.WriteLine($"No Controller Found");
            return;
        }

        foreach (var gamepad in gamepads) {
            nint gamepadId = SDL.OpenGamepad(gamepad);
            
            string? gamepadName = SDL.GetGamepadName(gamepadId);
            TextBlock.Text += $" ~{gamepadName}~\n";
            Console.WriteLine($"ControllerName: {gamepadName ?? "ctr_null"}");
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