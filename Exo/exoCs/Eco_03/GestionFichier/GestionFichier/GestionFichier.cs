using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace GestionFichier
{
    public class GestionFichier
    {
        /// <summary>
        /// Ecrit une string dans un fichier texte exisant
        /// </summary>
        /// <param name="ecriture"></param>
        /// <param name="emplacementFichier"></param>
        public static void EcrireFichierTexte(String chemin, String texte)
        {
            try
            {
                if (File.Exists(chemin))
                {
                    File.WriteAllText(chemin, texte);
                }
                else
                {
                    File.CreateText(chemin);
                    File.WriteAllText(chemin, texte);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
        public static void EcrireFichierTexte(String chemin, List<String> texte)
        {
            try
            {
                if (File.Exists(chemin))
                {
                    File.WriteAllLines(chemin, texte);
                }
                else
                {
                    File.CreateText(chemin);
                    File.WriteAllLines(chemin, texte);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

 

        public static String LireFichierTexte(String chemin)
        {
            String ret = "";
            using (StreamReader sr = File.OpenText(chemin))
            {
                string ligne;
                while ((ligne = sr.ReadLine()) != null)
                {
                    ret += ligne + "\n";
                }
            }
            return ret;
        }

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

        //public static Object LireFichierJson(String chemin)
        //{
        //   
        //    using FileStream openStream = File.OpenRead(chemin);
        //    Object? obj =
        //        await JsonSerializer.DeserializeAsync<Object>(openStream);

           
        //    return obj;
        //}


    }
}
