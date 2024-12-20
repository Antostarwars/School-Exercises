using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Threading;
using AcquarioLib;

/*
 * Antonio De Rosa 4H 20-12-2024
 * Tecniche Grafiche WPF - Acquario
 */
namespace TecnicheGrafica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Global variables
        DispatcherTimer FishDispatcher, PropsDispatcher;

        /// <summary>
        /// Setup of the dispatcher Timer, it is called only once when the application starts
        /// </summary>
        private void SetupTimer()
        {
            FishDispatcher = new DispatcherTimer();
            PropsDispatcher = new DispatcherTimer();
            FishDispatcher.Interval = TimeSpan.FromMilliseconds(40);
            PropsDispatcher.Interval = TimeSpan.FromMilliseconds(500);
            FishDispatcher.Start();
            PropsDispatcher.Start();
        }

        /// <summary>
        /// Adds objects to the canvas
        /// </summary>
        private void AggiungiOggetti()
        {
            AnimatoInAcqua animato = new AnimatoInAcqua(canvasAcquario, Inanimato.ImageFromName("pesce-pagliaccio.png"), FishDispatcher);
            animato.ChangeCenterOfRotation(100, 100);

            AnimatoSulPosto alga = new AnimatoSulPosto(canvasAcquario, Inanimato.ImageFromName("alga-1.png"), PropsDispatcher);

            AnimatoPilotatoSilurante sub = new AnimatoPilotatoSilurante(canvasAcquario, Inanimato.ImageFromName("submarine.png"), FishDispatcher, this, Inanimato.ImageFromName("missile.png"));

            AnimatoSulFondo paguro = new AnimatoSulFondo(canvasAcquario, Inanimato.ImageFromName("paguro.png"), FishDispatcher);

            AnimatoInAcqua polipo = new AnimatoInAcqua(canvasAcquario, Inanimato.ImageFromName("polipo.png"), FishDispatcher, 20);

            AnimatoSulPosto alga2 = new AnimatoSulPosto(canvasAcquario, Inanimato.ImageFromName("alga-2.png", 1125), PropsDispatcher);

            sub.Start();
            animato.Start();
            alga.Start();
            paguro.Start();
            polipo.Start();
            alga2.Start();
        }

        /// <summary>
        /// Constructor for MainWindow
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            SetupTimer();
            AggiungiOggetti();

            this.Title = "Antonio De Rosa 4H - Acquario in WPF";
        }
    }
}