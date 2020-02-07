using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

    

namespace SMDStore
{



    public partial class Form1 : Form
    {
       // internal string CValue { get; set; }


        int pBoxflag = 1;

        string zahlID;
        
        bool[] shelf = new bool[] { false, false, false, false, false, false, false };
        string[] pNR = new string[7];
        string[] pTYPE = new string[7];
        string[] mNR = new string[7];
        string[] mANZAHL = new string[7];
        string[] bDICKE = new string[7];
        string[] bLAENGE = new string[7];
        string[] bBREITE = new string[7];
        string[] mSORTE = new string[7];
       



        //string file = "";  //"\\\\MISTERX-PC\\salva-01\\pos_13.dat";

        //string path = "\\\\MISTERX-PC\\salva-01\\";

        string path = "";
        string palBACK;
        string palorder;

        string[] myFile = new string[7] { "pos_13.dat"                    // file0 = "\\\\MISTERX-PC\\salva-01\\pos_13.dat";
                                        , "pos_14.dat"                    // file1 = "\\\\MISTERX-PC\\salva-01\\pos_14.dat";
                                        , "pos_15.dat"                    // file2 = "\\\\MISTERX-PC\\salva-01\\pos_15.dat";
                                        , "pos_16.dat"                    // file3 = "\\\\MISTERX-PC\\salva-01\\pos_16.dat";
                                        , "pos_17.dat"                    // file4 = "\\\\MISTERX-PC\\salva-01\\pos_17.dat";
                                        , "pos_18.dat"                    // file5 = "\\\\MISTERX-PC\\salva-01\\pos_18.dat";
                                        , "pos_19.dat"};                  // file6 = "\\\\MISTERX-PC\\salva-01\\pos_19.dat";

           
                                                              
        
        

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,string key, string def, StringBuilder retVal, int size, string filePath);
        

        public string GetString(string section, string key,string file)
        {
            const int size = 255;    
            string def = "";
            StringBuilder sb = new StringBuilder(size);
            GetPrivateProfileString(section, key, def, sb, size, file);
            return sb.ToString();
        }

       

        public void ReadValues()
        {
            for (int i = 0; i <= 6; i++)
            {
                if (File.Exists(path + myFile[i]))
                {
                    // MessageBox.Show("JA IST DA"+myFile[i]+" !!!");
                    shelf[i] = true;
                    pNR[i] = GetString("pallet", "id", path + myFile[i]);
                    pTYPE[i] = GetString("pallet", "pallettype", path + myFile[i]);
                    mNR[i] = GetString("pack1", "name", path + myFile[i]);
                    mANZAHL[i] = GetString("pack1", "quantity", path + myFile[i]);
                    bDICKE[i] = GetString("pack1", "zdim", path + myFile[i]);
                    bLAENGE[i] = GetString("pack1", "xdim", path + myFile[i]);
                    bBREITE[i] = GetString("pack1", "ydim", path + myFile[i]);
                    mSORTE[i] = GetString("Material", mNR[i], Environment.CurrentDirectory + "\\Settings.INI");
                }
                else
                {
                    shelf[i] = false;
                    pNR[i] = "";
                    pTYPE[i] = "";
                    mNR[i] = "";
                    mANZAHL[i] = "";
                    bDICKE[i] = "";
                    bLAENGE[i] = "";
                    bBREITE[i] = "";
                    mSORTE[i] = "";
                }


            }

        }

        public void SetValues(int number)
        {
            PictureBox[] p = { pictureBox1, pictureBox2, pictureBox3,
                   pictureBox4, pictureBox5, pictureBox6,pictureBox7 };
            Label[] l = { label1, label2, label3, label4, label5, label6, label7 };
            

            palNr.Text = pNR[number];
            palType.Text = pTYPE[number];
            matNr.Text = mNR[number];
            matAnzahl.Text = mANZAHL[number];
            blDicke.Text = bDICKE[number];
            blLaenge.Text = bLAENGE[number];
            blBreite.Text = bBREITE[number];
            matSorte.Text = mSORTE[number];

            for (int i = 0; i <= 6; i++)
            {
                p[i].BorderStyle = BorderStyle.FixedSingle;
                l[i].ForeColor = System.Drawing.Color.Black;
            }
            switch (pBoxflag)
            {
                case 1:
                    pictureBox1.BorderStyle = BorderStyle.Fixed3D;
                    label1.ForeColor = System.Drawing.Color.Red;
                    BpalBack.Text = "Pal Fach 13 zurück";
                    BpalOrder.Text = "Pal Fach 13 bestellen";
                    break;
                case 2:
                    pictureBox2.BorderStyle = BorderStyle.Fixed3D;
                    label2.ForeColor = System.Drawing.Color.Red;
                    BpalBack.Text = "Pal Fach 14 zurück";
                    BpalOrder.Text = "Pal Fach 14 bestellen";
                    break;
                case 3:
                    pictureBox3.BorderStyle = BorderStyle.Fixed3D;
                    label3.ForeColor = System.Drawing.Color.Red;
                    BpalBack.Text = "Pal Fach 15 zurück";
                    BpalOrder.Text = "Pal Fach 15 bestellen";
                    break;
                case 4:
                    pictureBox4.BorderStyle = BorderStyle.Fixed3D;
                    label4.ForeColor = System.Drawing.Color.Red;
                    BpalBack.Text = "Pal Fach 16 zurück";
                    BpalOrder.Text = "Pal Fach 16 bestellen";
                    break;
                case 5:
                    pictureBox5.BorderStyle = BorderStyle.Fixed3D;
                    label5.ForeColor = System.Drawing.Color.Red;
                    BpalBack.Text = "Pal Fach 17 zurück";
                    BpalOrder.Text = "Pal Fach 17 bestellen";
                    break;
                case 6:
                    pictureBox6.BorderStyle = BorderStyle.Fixed3D;
                    label6.ForeColor = System.Drawing.Color.Red;
                    BpalBack.Text = "Pal Fach 18 zurück";
                    BpalOrder.Text = "Pal Fach 18 bestellen";
                    break;
                case 7:
                    pictureBox7.BorderStyle = BorderStyle.Fixed3D;
                    label7.ForeColor = System.Drawing.Color.Red;
                    BpalBack.Text = "Pal Fach 19 zurück";
                    BpalOrder.Text = "Pal Fach 19 bestellen";
                    break;
            }

        }

        public void SetShelf()
        {
            PictureBox[] p = { pictureBox1, pictureBox2, pictureBox3,
                   pictureBox4, pictureBox5, pictureBox6,pictureBox7 };

            for (int i = 0; i <= 6; i++)
            {
                if (shelf[i] == true)
                {
                    p[i].Image = SMDStore.Properties.Resources.pfull;
                }
                else
                {
                    p[i].Image = SMDStore.Properties.Resources.pempty;
                }
            }

        }
        

       

        public Form1()
        {
            InitializeComponent();

            path = GetString("Settings","path",Environment.CurrentDirectory + "\\Settings.INI");
            palBACK = GetString("Settings", "palback", Environment.CurrentDirectory + "\\Settings.INI");
            palorder = GetString("Settings", "palorder", Environment.CurrentDirectory + "\\Settings.INI");
            
            ReadValues();            
            SetShelf();
            SetValues(0);
            //MessageBox.Show(path);
           
            
         
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //file = path + myFile[0];
            //matNr.Text = GetString("pack1","xpos",path+myFile[0]);

            ReadValues();
            pBoxflag = 1;
            SetValues(0);
            SetShelf();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pBoxflag = 1;
            SetValues(0);
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pBoxflag = 2;
            SetValues(1);
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pBoxflag = 3;
            SetValues(2);
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pBoxflag = 4;
            SetValues(3);
            
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pBoxflag = 5;
            SetValues(4);
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pBoxflag = 6;
            SetValues(5);
           
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            pBoxflag = 7;
            SetValues(6);
            
        }

        private void BpalBack_Click(object sender, EventArgs e)
        {

            string lines = "[Main]\r\ncode="+palBACK;
            
            System.IO.StreamWriter freq;
            System.IO.StreamWriter freqsys;


            switch(pBoxflag)
            {
                case 1:
                    if (shelf[pBoxflag-1] == true)
                    {
                        MessageBox.Show("Fach 13 zurück");
                        freq = new StreamWriter(GetString("Settings", "path", Environment.CurrentDirectory + "\\Settings.INI") + "request13.dat");
                        freq.WriteLine(lines);
                        freq.Close();
                        freqsys = new StreamWriter(GetString("Settings", "path", Environment.CurrentDirectory + "\\Settings.INI") + "request13.syn");
                        freqsys.Close();
                    }
                    break;
                case 2:
                    if (shelf[pBoxflag - 1] == true)
                    {
                        MessageBox.Show("Fach 14 zurück");
                        freq = new StreamWriter(GetString("Settings", "path", Environment.CurrentDirectory + "\\Settings.INI") + "request14.dat");
                        freq.WriteLine(lines);
                        freq.Close();
                        freqsys = new StreamWriter(GetString("Settings", "path", Environment.CurrentDirectory + "\\Settings.INI") + "request14.syn");
                        freqsys.Close();
                    }
                    break;
                case 3:
                    if (shelf[pBoxflag - 1] == true)
                    {
                        MessageBox.Show("Fach 15 zurück");
                        freq = new StreamWriter(GetString("Settings", "path", Environment.CurrentDirectory + "\\Settings.INI") + "request15.dat");
                        freq.WriteLine(lines);
                        freq.Close();
                        freqsys = new StreamWriter(GetString("Settings", "path", Environment.CurrentDirectory + "\\Settings.INI") + "request15.syn");
                        freqsys.Close();
                    }
                    break;
                case 4:
                    if (shelf[pBoxflag - 1] == true)
                    {
                        MessageBox.Show("Fach 16 zurück");
                        freq = new StreamWriter(GetString("Settings", "path", Environment.CurrentDirectory + "\\Settings.INI") + "request16.dat");
                        freq.WriteLine(lines);
                        freq.Close();
                        freqsys = new StreamWriter(GetString("Settings", "path", Environment.CurrentDirectory + "\\Settings.INI") + "request16.syn");
                        freqsys.Close();
                    }
                    break;
                case 5:
                    if (shelf[pBoxflag - 1] == true)
                    {
                        MessageBox.Show("Fach 17 zurück");
                        freq = new StreamWriter(GetString("Settings", "path", Environment.CurrentDirectory + "\\Settings.INI") + "request17.dat");
                        freq.WriteLine(lines);
                        freq.Close();
                        freqsys = new StreamWriter(GetString("Settings", "path", Environment.CurrentDirectory + "\\Settings.INI") + "request17.syn");
                        freqsys.Close();
                    }
                    break;
                case 6:
                    if (shelf[pBoxflag - 1] == true)
                    {
                        MessageBox.Show("Fach 18 zurück");
                        freq = new StreamWriter(GetString("Settings", "path", Environment.CurrentDirectory + "\\Settings.INI") + "request18.dat");
                        freq.WriteLine(lines);
                        freq.Close();
                        freqsys = new StreamWriter(GetString("Settings", "path", Environment.CurrentDirectory + "\\Settings.INI") + "request18.syn");
                        freqsys.Close();
                    }
                    break;
                case 7:
                    if (shelf[pBoxflag - 1] == true)
                    {
                        MessageBox.Show("Fach 19 zurück");
                        freq = new StreamWriter(GetString("Settings", "path", Environment.CurrentDirectory + "\\Settings.INI") + "request19.dat");
                        freq.WriteLine(lines);
                        freq.Close();
                        freqsys = new StreamWriter(GetString("Settings", "path", Environment.CurrentDirectory + "\\Settings.INI") + "request19.syn");
                        freqsys.Close();
                    }
                    break;
            }
        }

        private void BpalOrder_Click(object sender, EventArgs e)
        {
            if (shelf[pBoxflag-1] == true)
            {
                const string message = "Fach ist voll, soll die Palette zurück geschickt werden";
                const string caption = "Palette bestellen"; 
                var result = MessageBox.Show(message, caption,
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    BpalBack.PerformClick();
                   // MessageBox.Show("Hat funktioniert");
                    fopen_orderForm();

                }

            }
            else
            {


                fopen_orderForm();

                
                       
                    // = frm.CustomValue;
                 //   MessageBox.Show(zahlID);
                
                
               
                
            }

            

        }

        private void fopen_orderForm()
        {
                Order frm = new Order();
                frm.Closed += new EventHandler(frm_Closed);
                frm.Show();
        }
    

        private void fpalOrder(string ID)
        {
            string line = "[Main]\r\ncode=" + palorder + "\r\nformat=" + ID + "\r\nquantity=1\r\nwoodpalletid=";
            System.IO.StreamWriter freqo;
            System.IO.StreamWriter freqsyso;

            

                freqo = new StreamWriter(GetString("Settings", "path", Environment.CurrentDirectory + "\\Settings.INI") + "request"+ (pBoxflag+12) + ".dat");
                freqo.WriteLine(line);
                freqo.Close();
                freqsyso = new StreamWriter(GetString("Settings", "path", Environment.CurrentDirectory + "\\Settings.INI") + "request" + (pBoxflag + 12) + ".syn");
                freqsyso.Close();
            
            
        }


        private void frm_Closed(object sender, EventArgs e)
        {
            Order frm = sender as Order;
            if (frm != null)
            {
               // if (frm.DialogResult == DialogResult.OK)
               // {
               //     this.zahlID = frm.CustomValue;
               //     //MessageBox.Show(zahlID);
               //     fpalOrder(zahlID);
               // }

                switch (frm.DialogResult)
                {
                    case DialogResult.OK:
                        {
                            this.zahlID = frm.CustomValue;
                            //MessageBox.Show(zahlID);
                            fpalOrder(zahlID);
                        }
                        break;

                    case DialogResult.Abort:
                        {
                            MessageBox.Show("Vorgang Abgebrochen");
                            

                        }
                        break;
                        
                }

            frm.Closed -= new EventHandler(frm_Closed);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

       
       

    }
}
