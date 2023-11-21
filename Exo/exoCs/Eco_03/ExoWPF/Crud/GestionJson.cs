using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;

namespace Crud
{
    class GestionJson
    {

        public static void EcrireFichierJson(String chemin, Object obj)
        {
            string jsonString = JsonSerializer.Serialize(obj);

            try
            {
                if (File.Exists(chemin))
                {
                    File.WriteAllText(chemin, jsonString);
                }
                else
                {
                    File.CreateText(chemin);
                    File.WriteAllText(chemin, jsonString);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

        }

        public static Object LireFichierJson(String chemin)
        {
            try
            {
                return JsonSerializer.Deserialize<Object?>(File.ReadAllText(chemin));
            }catch (Exception ex)
            {
                return null;
            }
            
        }

    }
}
