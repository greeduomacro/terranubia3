using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Server
{
    class NubiaDiagnostic
    {
        private static string fileName = "NubiaDiag.log";
        private static TextWriter getDiagnosticFile()
        {
            TextWriter fileStream = null;
            try
            {
                FileStream fs = null;
                if ( !File.Exists("./" + fileName))
                    fs = File.Create("./" + fileName);
                else 
                    fs = File.OpenWrite("./" + fileName);

                if (fs != null)
                    fileStream = new StreamWriter(fs) as TextWriter;
                else
                    Console.WriteLine(fileName + " non trouvé et/ou échoué à être crée");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Diag proble: " + ex.Message);
            }
            return fileStream;
        }

        public static void doDiagnostic()
        {
            System.IO.TextWriter stream = getDiagnosticFile();
            if (stream != null)
            {
                stream.WriteLine("Diagnostic le " + DateTime.Now.ToLongDateString() + " à "+ DateTime.Now.ToLongTimeString() );
                stream.WriteLine();
                
                stream.WriteLine("== XP Nessecaire par niveau ==");
                stream.WriteLine(".");
                for (int i = 0; i < 30; i++)
                {
                    stream.WriteLine("Niveau {0}: {1}xp", i.ToString(), XPHelper.GetXpForLevel(i).ToString());
                    if (i == 20)
                        stream.WriteLine("-- Niveaux de prestiges --");
                }

                stream.WriteLine(".");
                int xplvlmax = 0;
                for (int i = 0; i < 20; i++)
                    xplvlmax += XPHelper.GetXpForLevel(i);
                stream.WriteLine("XP Total Nessecaire pour level 20 : " + xplvlmax);
            }
            Console.WriteLine("Diagnostic terminé, voir " + fileName);
            stream.Close();
        }
    }
}
