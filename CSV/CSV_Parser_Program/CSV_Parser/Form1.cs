using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSV_Parser
{
    enum employeeType
    {
        Manager,
        Asst_Manager ,
        Coordinator,
        program_Manager,
        Team_Lead,
        Software_Engineer,
        Junior
    }
    enum departmentType
    {
        IT,
        Marketing,
        Sales,
        Store,
        HR,
        Tech_Team,
        Server
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            Random random = new Random();
           
            using (var fbd = new FolderBrowserDialog())
                 {
                     MessageBox.Show("Select a location to store CSV file");
                     DialogResult result = fbd.ShowDialog();
                   
                     if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                     {
                         var x = fbd.SelectedPath;
                         string destinationImgPath = x + "\\sample.csv";

                         employeeType empEnum;
                         departmentType dptEnum;

                         using (StreamWriter writer = new StreamWriter(new FileStream(destinationImgPath,
                         FileMode.Create, FileAccess.Write)))
                         {
                             //Header Rows
                             writer.WriteLine("EmployeeID, Name, Phone No, Category, Department, Salary, Start Date");
                            
                             for (int i = 0; i < 10; i++)
                             {
                                 Enum.TryParse<employeeType>("" + random.Next(0, 6) + "", out empEnum);
                                 Enum.TryParse<departmentType>("" + random.Next(0, 6) + "", out dptEnum);
                                 //writer.WriteLine(random.Next(101, 888) + ", Sanath ," + random.Next(12224, 2000000) + ", " + empEnum.ToString() + ", " + dptEnum.ToString()+ ", " + random.Next(2000, 9000) + ", " + DateTime.Now.AddMonths(random.Next(1, 8)));
                                 var col=random.Next(101, 888);
                                 var col1="Sanath";
                                 var col2 =random.Next(12224, 2000000);
                                 var col3= empEnum.ToString() ;
                                 var col4= dptEnum.ToString() ;
                                 var col5= random.Next(2000, 9000);
                                 var col6= DateTime.Now.AddMonths(random.Next(1, 8));
                                 var line = String.Format("{0},{1},{2},{3},{4},{5},{6}", col, col1, col2, col3, col4, col5, col6);
                                 writer.WriteLine(line);
                             }
                            
                         }
                     }
                 }
            
        }

        private void btn_close(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Read(object sender, EventArgs e)
        {
           
            string imgBase64String = "";
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "Image Files(*.csv; )|*.csv; ";
            if (open.ShowDialog() == DialogResult.OK)
            {

                var path = open.FileNames[0];
                using (var reader = new StreamReader(path))
                {
                    string textLine = "";
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        textLine =textLine + line;
                        textLine += Environment.NewLine;
                        textLine += Environment.NewLine;
                        //for (int i = 0; i < values.Length; i++)
                        //{
                        //    dataGridView1.Rows.Add(strArray[i],strArray[1],);
			 
                        //}
                        label1.Text = textLine;
                        
                    }

                    
                }
            
            }

                
        }

 
    }
}
