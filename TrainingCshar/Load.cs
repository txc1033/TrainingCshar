namespace TrainingCshar
{
    internal class Load
    {
        [System.STAThread]
        private static void Main(string[] args)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new Formulaio.FStart());
        }
    }
}