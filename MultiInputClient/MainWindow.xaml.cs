using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MultiInputClient.Enums;
using MultiInputClient.Interfaces;
using MultiInputClient.Scenes;

namespace MultiInputClient;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public static MainWindow? Window;
    public static List<IScene> Scenes = new List<IScene>();
    public static SceneId ActiveSceneId;
    public static IScene? ActiveScene;
    

    public MainWindow(){
        Window = this;
        InitializeComponent();
        InitializeScenes();
        LoadScene(SceneId.MainMenu);
    }

    private void InitializeScenes(){
        MainMenu mainMenu = new MainMenu();
        mainMenu.Initialize();
        Scenes.Add(mainMenu);

        
    }

    public static bool LoadScene(SceneId sceneId){
        IScene? scene = Scenes.FirstOrDefault(x => x.SceneId == sceneId);
        if (scene is null) {
            return false;
        }

        if (scene == ActiveScene) {
            //???????????
            return true;
        }
        ActiveScene?.UnLoad();
        ActiveScene = scene;
        ActiveSceneId = sceneId;
        scene.Load();
        return true;
    }
}