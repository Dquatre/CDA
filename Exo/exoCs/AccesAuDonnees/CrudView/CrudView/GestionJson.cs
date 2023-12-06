using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CrudModelControl.Models.Data;

namespace CrudView
{
    class GestionJson
    {
        public static void EcrireFichierJson(String chemin, Object obj)
        {
            string jsonString = JsonConvert.SerializeObject(obj);

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
                return JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText(chemin));
            }catch (Exception ex)
            {
                return null;
            }
        }

    }
}
