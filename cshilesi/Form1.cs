using Swed32;

namespace cshilesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            Swed swed = new Swed("half");
            IntPtr module = swed.GetModuleBase("sw.dll");

            var ptr = swed.ReadPointer(module, 0x00473860);

            var health = swed.ReadFloat(ptr, 0x504);

            Task.Run(() =>
            {
                while (true) {
                    swed.WriteFloat(ptr, 0x504, 300);
                }
            });
        }
    }
}
