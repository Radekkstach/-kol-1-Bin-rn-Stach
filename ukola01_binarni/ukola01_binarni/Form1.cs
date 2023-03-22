namespace ukola01_binarni
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileStream datovytok = new FileStream("znaky.dat", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter zapis = new BinaryWriter(datovytok);
            char[] bengr = { 'B', 'E', 'N', 'G', 'R', '?', 'P', 'I', 'C', 'A' };
            for(int i = 0;i <bengr.Length;i++)
            {
                zapis.Write(bengr[i]);
            }
            datovytok.Close();
            zapis.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            FileStream datovytok = new FileStream("znaky.dat",FileMode.Open,FileAccess.Read);
            BinaryReader ctenar = new BinaryReader(datovytok);
            ctenar.BaseStream.Position = 0;
            char predchozi = ' ';
            bool konec = false;
            while (ctenar.BaseStream.Position<ctenar.BaseStream.Length&& konec == false)
            {
                char znak = ctenar.ReadChar();
                listBox1.Items.Add(znak);
                if (znak == '?' && konec == false)
                {

                    label2.Text = ctenar.BaseStream.Position.ToString();
                    label3.Text = predchozi.ToString();
                    konec = true;
                    
                }
                
                predchozi = znak;
            }
            if(konec == false)
            {
                MessageBox.Show("Zadny otaznik se nenasel");
            }
            ctenar.Close();
            datovytok.Close();


        }
    }
}