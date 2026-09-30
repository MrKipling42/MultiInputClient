using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using MultiInputClient.Enums;

namespace MultiInputClient.CustomElements.Buttons;

public class Return : UIElement
{
    private TextBlock _textBlock;
    private SceneId _sceneId;
    public Return(SceneId sceneToReturnTo){
        _sceneId = sceneToReturnTo;
        _textBlock = new TextBlock();
        InitializeButton();
    }

    private void OnButton_Pressed(object sender, MouseButtonEventArgs mouseButtonEventArgs){
        object sender2 = sender;
        MainWindow.LoadScene(_sceneId);
    }

    private void InitializeButton(){
        _textBlock.MouseLeftButtonDown += OnButton_Pressed;
        _textBlock.Text = $"Return";
        _textBlock.Background = Brushes.Gray;
        _textBlock.HorizontalAlignment = HorizontalAlignment.Right;
        _textBlock.VerticalAlignment = VerticalAlignment.Top;
    }
}