Namespace TrainingCshar
    Friend Class Load
        <STAThread>
        Private Shared Sub Main(ByVal args As String())
            System.Windows.Forms.Application.EnableVisualStyles()
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(False)
            System.Windows.Forms.Application.Run(New Formulaio.FStart())
        End Sub
    End Class
End Namespace
