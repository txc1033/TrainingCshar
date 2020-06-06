using CsharLibrary;
namespace TrainingCshar
{
    internal class Load
    {
        [System.STAThread]
        private static void Main(string[] args)
        {
            var service = new Services();
            var container = service.csharContainer;

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new Formulaio.FStart(container));
        }
    }
}