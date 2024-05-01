using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockXCore
{
    public static class CommonUtility
    {
        public static System.Windows.Forms.DataGridView SetGridColor(System.Windows.Forms.DataGridView gdvItemDetails, Color FromRGBColor)
        {
            gdvItemDetails.EnableHeadersVisualStyles = false;
            gdvItemDetails.ColumnHeadersDefaultCellStyle.BackColor = Color.FromName("#496989");

            DataGridViewCellStyle column_header_cell_style = new DataGridViewCellStyle();
            column_header_cell_style.BackColor = FromRGBColor;            
            column_header_cell_style.ForeColor = Color.Black;

            column_header_cell_style.SelectionBackColor = Color.DarkGray;
            column_header_cell_style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column_header_cell_style.Font = new Font("DaytonaPro-☞", 12, FontStyle.Bold, GraphicsUnit.Pixel);
            column_header_cell_style.WrapMode = DataGridViewTriState.True;

            gdvItemDetails.ColumnHeadersDefaultCellStyle = column_header_cell_style;

            return gdvItemDetails;
        }

        public static bool SendSMS(string text, string tempPassword)
        {
            return true;
        }

        public static Color SetTextBackgroundColor(TextBox txtBarcode)
        {
            return txtBarcode.BackColor = Color.Yellow;
        }

        public static string WriteExcel(string filename, System.Data.DataTable dataTable)
        {
            filename = filename + ".xls";
            StreamWriter sw = new StreamWriter(filename);

            try
            {             

                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    sw.Write(dataTable.Columns[i].ToString().ToUpper() + "\t");
                }

                sw.WriteLine();


                for (int i = 0; i < (dataTable.Rows.Count); i++)
                {
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        if (dataTable.Rows[i][j] != null)
                        {
                            sw.Write(Convert.ToString(dataTable.Rows[i][j]) + "\t");
                        }
                        else
                        {
                            sw.Write("\t");
                        }
                    }
                    //go to next line
                    sw.WriteLine();
                }
                //close file
                sw.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sw.Close();
                sw.Dispose();
            }
            return "file successfully downloaded at \n" + filename;
        }
    }
}
