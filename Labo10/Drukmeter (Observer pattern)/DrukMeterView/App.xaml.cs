using DrukMeter.Pattern;
using Microsoft.Practices.Unity;
using System;
using System.Windows;
using Unity;
using Unity.Injection;

namespace DrukMeterView
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //(un)comment the following blocks to switch between di and no di
            NoDependencyInjection().Show();
            //WithDependencyInjection().Show();
        }

        private MainWindow NoDependencyInjection()
        {
            DrukSubject drukSubject = new DrukSubject();

            //(un)comment the following blocks to switch between units
            #region Pascal
            //InvoerControl invoer = new InvoerControl(drukSubject, "druk in Pascal (default)");
            //UitvoerControl uitvoer = new UitvoerControl(drukSubject);
            #endregion

            #region atmosfeer
            AangepastDrukSubject aDrukSubject = new AangepastDrukSubject(drukSubject, "atm", 101325);
            InvoerControl invoer = new InvoerControl(aDrukSubject, "druk in atmosfeer");
            UitvoerControl uitvoer = new UitvoerControl(aDrukSubject);
            #endregion

            #region psi
            // AangepastDrukSubject aDrukSubject = new AangepastDrukSubject(drukSubject, "psi", 101325 / 14.7);
            //InvoerControl invoer = new InvoerControl(aDrukSubject, "druk in psi");
            //UitvoerControl uitvoer = new UitvoerControl(aDrukSubject);
            #endregion



            MainWindow mainWindow = new MainWindow(invoer, uitvoer);
            return mainWindow;
        }

        // https://stackoverflow.com/questions/4059991/microsoft-unity-how-to-specify-a-certain-parameter-in-constructor
        // zie link voor meer info over syntax Unity
        private MainWindow WithDependencyInjection()
        {
            using (var container = new UnityContainer())
            {
                // dit hele labo draait om deze lijnen:
                // we maken zelf een instantie van het basismodel en gaan dat telkens registreren
                // de container heeft zo een mapping IDrukSubject => instantie model, als de container ergens anders een IDrukSubject nodig heeft,
                // heeft het een geldige instantie om te gebruiken.
                // RegisterType is de meest gebruikte manier: je zegt aan het DI framework dat je een nieuwe mapping wenst
                // bv container.RegisterType<InvoerControl>(...)
                // de container is verantwoordelijk voor het maken van een InvoerControl, dat kan natuurlijk niet zomaar
                // daarom is het argument van de RegisterType functie: new InjectionConstructor(typeof(IDrukSubject),"druk in pascal")
                // peek: public InvoerControl(IDrukSubject drukSubject, string titel) is de constructor voor een InvoerControl
                // via de typeof(IDrukSubject) weet de container dat hij de instantie moet gebruiken die net geregistreerd werd
                // het tweede argument is de string die verwacht is

                IDrukSubject drukSubject = new DrukSubject();

                #region Pascal
                //container.RegisterInstance<IDrukSubject>(drukSubject);
                //container.RegisterType<InvoerControl>(new InjectionConstructor(typeof(IDrukSubject), "druk in Pascal"));
                #endregion

                #region atmosfeer
                //container.RegisterInstance(drukSubject);
                //container.RegisterType<AangepastDrukSubject>(new InjectionConstructor(typeof(DrukSubject), "atm", 101325));
                //container.RegisterType<IDrukSubject, AangepastDrukSubject>();
                //container.RegisterType<InvoerControl>(new InjectionConstructor(typeof(IDrukSubject), "druk in atmosfeer"));
                #endregion

                #region psi  
                // huidige instance registreren
                container.RegisterInstance(drukSubject);
                // DI container 'zeggen' hoe een AangepastDrukSubject gemaakt moet worden
                container.RegisterType<AangepastDrukSubject>(new InjectionConstructor(typeof(DrukSubject), "psi", 101325 / 14.7));
                // instellen dat de container AangepastDrukSubject moet maken als hij een dependency van type IDrukSubject tegenkomt
                container.RegisterType<IDrukSubject, AangepastDrukSubject>();
                // DI container 'zeggen' hoe een InvoerControl gemaakt moet worden
                container.RegisterType<InvoerControl>(new InjectionConstructor(typeof(IDrukSubject), "druk in psi"));
                #endregion

                // altijd nodig
                // merk op dat voor de mapping voor een MainWindow er niet verder gespecifieerd wordt hoe een UitvoerControl gemaakt moet worden
                // dat is ook niet nodig als je gaat kijken in UitvoerControl.xaml.cs, de DI container heeft al alle info om zelf de InjectionConstructor te voorzien
                container.RegisterType<MainWindow>(new InjectionConstructor(typeof(InvoerControl), typeof(UitvoerControl)));
                // de aanroep die alles in gang zet, de boom van dependencies wordt gebouwd om uiteindelijk een geldige MainWindow terug te geven
                MainWindow window = container.Resolve<MainWindow>();
                return window;
            }
        }
    }
}
