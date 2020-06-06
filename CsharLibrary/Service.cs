using CsharLibrary.Class.Data_Process;
using CsharLibrary.Data_Process;
using CsharLibrary.Examples;
using SimpleInjector;

namespace CsharLibrary
{
    public class Service
    {
        private Container container;
        public Container csharContainer { get => container; }

        public Service()
        {
            container = new Container();
            container.Register<IOrchestrator, Orchestrator>();
            container.Register<IManagement, Management>();
            container.Register<IDBManagement, DBManagement>();
            container.Register<IFileManagement, FileManagement>();
            container.Register<IApiManagement, ApiManagement>();
        }
    }
}