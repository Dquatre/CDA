using Crud_Multipage.Models.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_Multipage.Dao
{
    public class GestionJson
    {
        static public void EcrireFichierJson(StructureJson sj, string path)
        {
            string[] contenu = { JsonConvert.SerializeObject(sj) };
            File.WriteAllLines(path, contenu);
        }
        static public StructureJson LireFichierJson(string path)
        {
             return JsonConvert.DeserializeObject<StructureJson>(File.ReadAllText(path));
        }
    }
}
