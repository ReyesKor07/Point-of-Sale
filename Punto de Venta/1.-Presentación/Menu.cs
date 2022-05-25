using System.Runtime.InteropServices; //Mover la Ventana

namespace _1._Presentación
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }
        
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")] //Mover la Ventana
        private extern static void ReleaseCapture(); //Mover la Ventana
        [DllImport("user32.DLL", EntryPoint = "SendMessage")] //Mover la Ventana

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam); //Mover la Ventana

        private void PanelContenedor_MouseDown(object sender, MouseEventArgs e)//Mover la Ventana con el Mouse
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}