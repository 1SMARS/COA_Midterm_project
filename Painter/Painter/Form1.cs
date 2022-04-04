namespace Painter
{
    public partial class Form1 : Form
    {
        bool drw;
        int X,Y;
        Pen p;
        Color color = Color.Black;
        private object stateComboBox;

        public Form1()
        {
            InitializeComponent();
        }


        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            drw = true;
            X = e.X;
            Y = e.Y;
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            drw = false;
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            int size = Convert.ToInt32(comboBox1.Text);
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            Graphics g = Canvas.CreateGraphics();
            p = new Pen(color, size);
            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            Point point1 = new Point(X,Y);
            Point point2 = new Point(e.X,e.Y);
            if(drw == true)
            {
                g.DrawLine(p, point1, point2);
                X = e.X;
                Y = e.Y;
            }
            
        }

        


        private void ColorPick(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                color = colorDialog1.Color;
                p.Color = color;
            }
        }

        private void ClearBtn(object sender, EventArgs e)
        {
            Graphics g = Canvas.CreateGraphics();
            g.Clear(Canvas.BackColor);
        }

        private void EraserBtn(object sender, EventArgs e)
        {
            color = Color.White;
            p.Color = color;
        }

        private void brushSize_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            color = ((Button)sender).BackColor;
            p.Color = color;
        }

       
    }
}