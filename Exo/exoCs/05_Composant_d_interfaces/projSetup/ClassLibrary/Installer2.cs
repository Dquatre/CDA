using System.Collections;
using System.Configuration.Install;

namespace ClassLibrary
{
    public class Installer2 : Installer
    {
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
            string param = this.Context.Parameters["base"];
            File.WriteAllText("C:\\temp\\inst\\text.txt",param);
        }
    }
}