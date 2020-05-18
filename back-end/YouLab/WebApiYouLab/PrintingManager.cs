using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;

namespace WebApiYouLab
{
    public class PrintingManager
    {
        public void Printing(string printer)
        {
            try
            {
                //var streamToPrint = new StreamReader("");
                try
                {
                    var printFont = new Font("Arial", 10);
                    PrintDocument pd = new PrintDocument();
                    pd.PrinterSettings.PrinterName = "Microsoft Print to PDF";
                    var streamToPrint = new StreamReader("C:\\Users\\Youcode\\Documents\\20191225_231946.jpg");

                    if (pd.PrinterSettings.IsValid)
                    {
                        pd.Print();
                    }
                    else
                    {
                    }
                }
                finally
                {
                    
                }
            }
            catch (Exception)
            {

            }
        }
    }
}