using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Copmuter_Graghics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DrawPoint(float x, float y)
        {
            var aBrush = Brushes.Red;
            var g = panel1.CreateGraphics();

            g.FillRectangle(aBrush, 172 + x, 154 - y, 2, 2);

        }
        void DDALine(int xInitial, int yInitial, int xFinal, int yFinal)

        {
           // int = x0,  = y0,  = xEnd,  = yEnd;
            int dx = xFinal - xInitial,
                dy = yFinal - yInitial,
                steps, k, xf, yf;

            float xIncrement, yIncrement, x = xInitial, y = yInitial;

            if (Math.Abs(dx) > Math.Abs(dy))
                 steps = Math.Abs(dx);
            else 
                 steps = Math.Abs(dy);

            xIncrement = dx / (float)steps;
            yIncrement = dy / (float)steps;

            for (k = 0; k < steps; k++)
            {
                x += xIncrement;
                xf = (int)x;
                y += yIncrement;
                yf = (int)y;

                try
                {
                    DrawPoint(x, y);

                }
                catch (InvalidOperationException)
                {
                    return;
                }
                listBox1.Items.Add(x);
                listBox2.Items.Add(y);
            }
        }
        private void DrawAxis()
        {
            var aBrush = Brushes.Black;
            var g = panel1.CreateGraphics();
            //x axis drawing
            for (int i = 0; i < 344; i++)
            {
                g.FillRectangle(aBrush, i, 154, 2, 2);
            }
            //y axis drawing
            for (int j = 0; j < 308; j++)
            {
                g.FillRectangle(aBrush, 172, j, 1, 1);
            } 
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox1.Text);
            int y1 = Convert.ToInt32(textBox2.Text);
            int x2 = Convert.ToInt32(textBox3.Text);
            int y2 = Convert.ToInt32(textBox4.Text);
            panel1.Controls.Clear();
            this.Refresh();
            DrawAxis();
            DDALine(x1, y1, x2, y2);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox1.Text);
            int y1 = Convert.ToInt32(textBox2.Text);
            int x2 = Convert.ToInt32(textBox3.Text);
            int y2 = Convert.ToInt32(textBox4.Text);


            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);
            if (dx > dy)
            {
                BresenhamLine(x1, y1, x2, y2, dx, dy, 0);
            }
            else
            {
                BresenhamLine(y1, x1, y2, x2, dx, dy, 1);
            }


            DrawAxis();
        }

        private void BresenhamLine(int x1, int y1, int x2, int y2, int dx, int dy, int m)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            int pk = 2 * dy - dx;
            for (int i = 0; i <= dx - 1; i++)
            {
                if (x1 < x2) x1++;
                else x1--;

                if (pk < 0)
                {
                    if (m == 0)
                    {
                        DrawPoint(x1, y1);
                        pk = pk + 2 * dy;
                    }
                    else
                    {
                        DrawPoint(y1, x1);
                        pk = pk + 2 * dy;
                    }
                }
                else
                {
                    if (y1 < y2) y1++;
                    else y1--;
                    if (m == 0)
                    {

                        DrawPoint(x1, y1);
                    }
                    else
                    {
                        DrawPoint(y1, x1);
                    }
                    pk = pk + 2 * dy - 2 * dx;
                }
                listBox1.Items.Add(x1);
                listBox2.Items.Add(y1);


            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox5.Text);
            int y1 = Convert.ToInt32(textBox6.Text);
            int Radius = Convert.ToInt32(textBox7.Text);
            panel1.Controls.Clear();
            this.Refresh();
            DrawAxis();
            CircleMidpoint(x1, y1, Radius);
        }
        void CircleMidpoint(int xCenter, int yCenter, int radius)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            int x = 0;
            int y = radius;
            int p = 1 - radius;
            DrawCirclePoints(xCenter, yCenter, x, y);
            while (x < y)
            {
                x++;
                if (p < 0)
                    p += 2 * x + 1;
                else
                {
                    y--;
                    p += 2 * (x - y) + 1;
                }
                DrawCirclePoints(xCenter, yCenter, x, y);
                listBox1.Items.Add(x);
                listBox2.Items.Add(y);
            }
        }
        void DrawCirclePoints(int xCenter, int yCenter, int x, int y)
        {
            var aBrush = Brushes.Black;
            var g = panel1.CreateGraphics();

            g.FillRectangle(aBrush, 172 + (xCenter + x), 154 - (yCenter + y), 2, 2);
            g.FillRectangle(aBrush, 172 + (xCenter - x), 154 - (yCenter + y), 2, 2);
            g.FillRectangle(aBrush, 172 + (xCenter + x), 154 - (yCenter - y), 2, 2);
            g.FillRectangle(aBrush, 172 + (xCenter - x), 154 - (yCenter - y), 2, 2);
            g.FillRectangle(aBrush, 172 + (xCenter + y), 154 - (yCenter + x), 2, 2);
            g.FillRectangle(aBrush, 172 + (xCenter - y), 154 - (yCenter + x), 2, 2);
            g.FillRectangle(aBrush, 172 + (xCenter + y), 154 - (yCenter - x), 2, 2);
            g.FillRectangle(aBrush, 172 + (xCenter - y), 154 - (yCenter - x), 2, 2);

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox8.Text);
            int y1 = Convert.ToInt32(textBox9.Text);
            int xradius = Convert.ToInt32(textBox10.Text);
            int yradius = Convert.ToInt32(textBox11.Text);
            panel1.Controls.Clear();
            this.Refresh();
            DrawAxis();
            EllipseMidpoint(x1, y1, xradius, yradius);
        }

        void EllipseMidpoint(int xCenter, int yCenter, int Rx, int Ry)
        {
            int Rx2 = Rx * Rx;
            int Ry2 = Ry * Ry;
            int twoRx2 = 2 * Rx2;
            int twoRy2 = 2 * Ry2;
            int p;
            int x = 0;
            int y = Ry;
            int px = 0;
            int py = twoRx2 * y;

            DrawEllipsePoints(xCenter, yCenter, x, y);
            // Region 1 
            p = Convert.ToInt32(Ry2 - (Rx2 * Ry) + (0.25 * Rx2));
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            while (px < py)
            {
                x++;
                px += twoRy2;
                if (p < 0)
                    p += Ry2 + px;
                else
                {
                    y--;
                    py -= twoRx2;
                    p += Ry2 + px - py;
                }
                DrawEllipsePoints(xCenter, yCenter, x, y);
                listBox1.Items.Add(x);
                listBox2.Items.Add(y);
            }
            // Region 2 
            p = Convert.ToInt32(Ry2 * (x + 0.5) * (x + 0.5) + Rx2 * (y - 1) * (y - 1) - Rx2 * Ry2);

            while (y > 0)
            {
                y--;
                py -= twoRx2;
                if (p > 0)
                    p += Rx2 - py;
                else
                {
                    x++;
                    px += twoRy2;
                    p += Rx2 - py + px;
                }
                DrawEllipsePoints(xCenter, yCenter, x, y);
                listBox1.Items.Add(x);
                listBox2.Items.Add(y);
            }
        }
        void DrawEllipsePoints(int xCenter, int yCenter, int x, int y)
        {
            var aBrush = Brushes.Black;
            var g = panel1.CreateGraphics();
            g.FillRectangle(aBrush, 172 + (xCenter + x), 154 - (yCenter + y), 2, 2);
            g.FillRectangle(aBrush, 172 + (xCenter - x), 154 - (yCenter + y), 2, 2);
            g.FillRectangle(aBrush, 172 + (xCenter + x), 154 - (yCenter - y), 2, 2);
            g.FillRectangle(aBrush, 172 + (xCenter - x), 154 - (yCenter - y), 2, 2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox12.Text);
            int y1 = Convert.ToInt32(textBox13.Text);
            int x2 = Convert.ToInt32(textBox14.Text);
            int y2 = Convert.ToInt32(textBox15.Text);
            int x3 = Convert.ToInt32(textBox16.Text);
            int y3 = Convert.ToInt32(textBox17.Text);
            int x4 = Convert.ToInt32(textBox18.Text);
            int y4 = Convert.ToInt32(textBox19.Text);



            Point p1 = new Point(x1 + 172, 154 - y1);
            Point p2 = new Point(x2 + 172, 154 - y2);
            Point p3 = new Point(x3 + 172, 154 - y3);
            Point p4 = new Point(x4 + 172, 154 - y4);


            Graphics draw = panel1.CreateGraphics();
            Brush brush = new SolidBrush(Color.Blue);
            Pen redBrush = new Pen(brush, 2);
            this.Refresh();
            panel1.Controls.Clear();
            draw.DrawLine(redBrush, p1, p2);
            draw.DrawLine(redBrush, p1, p3);
            draw.DrawLine(redBrush, p2, p4);
            draw.DrawLine(redBrush, p3, p4);
            

            DrawAxis();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox12.Text);
            int y1 = Convert.ToInt32(textBox13.Text);
            int x2 = Convert.ToInt32(textBox14.Text);
            int y2 = Convert.ToInt32(textBox15.Text);
            int x3 = Convert.ToInt32(textBox16.Text);
            int y3 = Convert.ToInt32(textBox17.Text);
            int x4 = Convert.ToInt32(textBox18.Text);
            int y4 = Convert.ToInt32(textBox19.Text);

            int y1dash = 0;
            int y2dash = 0;
            int y3dash = 0;
            int y4dash = 0;


            int[,] currentMat1 = { {1,0,x1 },
                                   {0,1,y1 },
                                   {0,0,1} };


            int[,] currentMat2 = { {1,0,x2 },
                                   {0,1,y2 },
                                   {0,0,1} };


            int[,] currentMat3 = { {1,0,x3 },
                                   {0,1,y3 },
                                   {0,0,1} };

            int[,] currentMat4 = { {1,0,x4 },
                                   {0,1,y4 },
                                   {0,0,1} };


            int[,] newtMat1 = { {1,0,x1 },
                                {0,1,y1dash },
                                {0,0,1} };


            int[,] newtMat2 = { {1,0,x2 },
                                {0,1,y2dash },
                                {0,0,1} };


            int[,] newtMat3 = { {1,0,x3 },
                                {0,1,y3dash },
                                {0,0,1} };

            int[,] newtMat4 = { {1,0,x4 },
                                {0,1,y4dash },
                                {0,0,1} };


            int[,] reflectMat = { {1,0,0 },
                                  {0,-1,0 },
                                  {0,0,1 } };

            multiply(reflectMat, currentMat1, newtMat1);
            multiply(reflectMat, currentMat2, newtMat2);
            multiply(reflectMat, currentMat3, newtMat3);
            multiply(reflectMat, currentMat4, newtMat4);




            // panel1.Refresh();
            Graphics draw = panel1.CreateGraphics();
            Brush brush = new SolidBrush(Color.Yellow);
            Pen redBrush = new Pen(brush, 2);
            draw.DrawLine(redBrush, x1 + 172, 154 - newtMat1[1, 2], x2 + 172, 154 - newtMat2[1, 2]);
            draw.DrawLine(redBrush, x1 + 172, 154 - newtMat1[1, 2], x3 + 172, 154 - newtMat3[1, 2]);
            draw.DrawLine(redBrush, x2 + 172, 154 - newtMat2[1, 2], x4 + 172, 154 - newtMat4[1, 2]);
            draw.DrawLine(redBrush, x3 + 172, 154 - newtMat3[1, 2], x4 + 172, 154 - newtMat4[1, 2]);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox12.Text);
            int y1 = Convert.ToInt32(textBox13.Text);
            int x2 = Convert.ToInt32(textBox14.Text);
            int y2 = Convert.ToInt32(textBox15.Text);
            int x3 = Convert.ToInt32(textBox16.Text);
            int y3 = Convert.ToInt32(textBox17.Text);
            int x4 = Convert.ToInt32(textBox18.Text);
            int y4 = Convert.ToInt32(textBox19.Text);

            int x1dash = 0;
            int x2dash = 0;
            int x3dash = 0;
            int x4dash = 0;


            int[,] currentMat1 = { {1,0,x1 },
                                   {0,1,y1 },
                                   {0,0,1} };


            int[,] currentMat2 = { {1,0,x2 },
                                   {0,1,y2 },
                                   {0,0,1} };


            int[,] currentMat3 = { {1,0,x3 },
                                   {0,1,y3 },
                                   {0,0,1} };

            int[,] currentMat4 = { {1,0,x4 },
                                   {0,1,y4 },
                                   {0,0,1} };


            int[,] newtMat1 = { {1,0,x1dash },
                                {0,1,y1 },
                                {0,0,1} };


            int[,] newtMat2 = { {1,0,x2dash },
                                {0,1,y2 },
                                {0,0,1} };


            int[,] newtMat3 = { {1,0,x3dash },
                                {0,1,y3 },
                                {0,0,1} };

            int[,] newtMat4 = { {1,0,x4dash },
                                {0,1,y4 },
                                {0,0,1} };


            int[,] reflectMat = { {-1,0,0 },
                                  {0,1,0 },
                                  {0,0,1 } };

            multiply(reflectMat, currentMat1, newtMat1);
            multiply(reflectMat, currentMat2, newtMat2);
            multiply(reflectMat, currentMat3, newtMat3);
            multiply(reflectMat, currentMat4, newtMat4);





            Graphics draw = panel1.CreateGraphics();

            Brush brush = new SolidBrush(Color.Green);
            Pen redBrush = new Pen(brush, 2);
            DrawAxis();
            draw.DrawLine(redBrush, newtMat1[0, 2] + 172, 154 - y1, newtMat2[0, 2] + 172, 154 - y2);
            draw.DrawLine(redBrush, newtMat1[0, 2] + 172, 154 - y1, newtMat3[0, 2] + 172, 154 - y3);
            draw.DrawLine(redBrush, newtMat2[0, 2] + 172, 154 - y2, newtMat4[0, 2] + 172, 154 - y4);
            draw.DrawLine(redBrush, newtMat3[0, 2] + 172, 154 - y3, newtMat4[0, 2] + 172, 154 - y4);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox12.Text);
            int y1 = Convert.ToInt32(textBox13.Text);
            int x2 = Convert.ToInt32(textBox14.Text);
            int y2 = Convert.ToInt32(textBox15.Text);
            int x3 = Convert.ToInt32(textBox16.Text);
            int y3 = Convert.ToInt32(textBox17.Text);
            int x4 = Convert.ToInt32(textBox18.Text);
            int y4 = Convert.ToInt32(textBox19.Text);

            int x1dash = 0;
            int y1dash = 0;
            int x2dash = 0;
            int y2dash = 0;
            int x3dash = 0;
            int y3dash = 0;
            int x4dash = 0;
            int y4dash = 0;


            int[,] currentMat1 = { {1,0,x1 },
                                   {0,1,y1 },
                                   {0,0,1} };


            int[,] currentMat2 = { {1,0,x2 },
                                   {0,1,y2 },
                                   {0,0,1} };


            int[,] currentMat3 = { {1,0,x3 },
                                   {0,1,y3 },
                                   {0,0,1} };

            int[,] currentMat4 = { {1,0,x4 },
                                   {0,1,y4 },
                                   {0,0,1} };

            int[,] newtMat1 = { {1,0,x1dash },
                                {0,1,y1dash },
                                {0,0,1} };


            int[,] newtMat2 = { {1,0,x2dash },
                                {0,1,y2dash },
                                {0,0,1} };


            int[,] newtMat3 = { {1,0,x3dash },
                                {0,1,y3dash },
                                {0,0,1} };

            int[,] newtMat4 = { {1,0,x4dash },
                                {0,1,y4dash },
                                {0,0,1} };


            int[,] reflectMat = { {-1,0,0 },
                                  {0,-1,0 },
                                  {0,0,1 } };

            multiply(reflectMat, currentMat1, newtMat1);
            multiply(reflectMat, currentMat2, newtMat2);
            multiply(reflectMat, currentMat3, newtMat3);
            multiply(reflectMat, currentMat4, newtMat4);





            Graphics draw = panel1.CreateGraphics();

            Brush brush = new SolidBrush(Color.Red);
            Pen redBrush = new Pen(brush, 2);
            draw.DrawLine(redBrush, newtMat1[0, 2] + 172, 154 - newtMat1[1, 2], newtMat2[0, 2] + 172, 154 - newtMat2[1, 2]);
            draw.DrawLine(redBrush, newtMat1[0, 2] + 172, 154 - newtMat1[1, 2], newtMat3[0, 2] + 172, 154 - newtMat3[1, 2]);
            draw.DrawLine(redBrush, newtMat2[0, 2] + 172, 154 - newtMat2[1, 2], newtMat4[0, 2] + 172, 154 - newtMat4[1, 2]);
            draw.DrawLine(redBrush, newtMat3[0, 2] + 172, 154 - newtMat3[1, 2], newtMat4[0, 2] + 172, 154 - newtMat4[1, 2]);
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }
        private void Translate(int xdash, int ydash, int xdash2, int ydash2, int xdash3, int ydash3, int xdash4, int ydash4)
        {

            Graphics draw = panel1.CreateGraphics();
            Brush brush = new SolidBrush(Color.DarkGreen);
            Pen redBrush = new Pen(brush, 2);
            Point p1 = new Point(xdash + 172, 154 - ydash);
            Point p2 = new Point(xdash2 + 172, 154 - ydash2);
            Point p3 = new Point(xdash3 + 172, 154 - ydash3);
            Point p4 = new Point(xdash4 + 172, 154 - ydash4);
            draw.DrawLine(redBrush, p1, p2);
            draw.DrawLine(redBrush, p1, p3);
            draw.DrawLine(redBrush, p2, p4);
            draw.DrawLine(redBrush, p2, p4);
            draw.DrawLine(redBrush, p3, p4);

        }
        private void button9_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox20.Text);
            int y = Convert.ToInt32(textBox21.Text);
            int x1 = Convert.ToInt32(textBox12.Text);
            int y1 = Convert.ToInt32(textBox13.Text);
            int x2 = Convert.ToInt32(textBox14.Text);
            int y2 = Convert.ToInt32(textBox15.Text);
            int x3 = Convert.ToInt32(textBox16.Text);
            int y3 = Convert.ToInt32(textBox17.Text);
            int x4 = Convert.ToInt32(textBox18.Text);
            int y4 = Convert.ToInt32(textBox19.Text);

            int xdash = x1 + x;
            int ydash = y1 + y;
            int xdash2 = x2 + x;
            int ydash2 = y2 + y;
            int xdash3 = x3 + x;
            int ydash3 = y3 + y;
            int xdash4 = x4 + x;
            int ydash4 = y4 + y;

            Translate(xdash, ydash, xdash2, ydash2, xdash3, ydash3, xdash4, ydash4);
        
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox20.Text);
            int y = Convert.ToInt32(textBox21.Text);
            int x1 = Convert.ToInt32(textBox12.Text);
            int y1 = Convert.ToInt32(textBox13.Text);
            int x2 = Convert.ToInt32(textBox14.Text);
            int y2 = Convert.ToInt32(textBox15.Text);
            int x3 = Convert.ToInt32(textBox16.Text);
            int y3 = Convert.ToInt32(textBox17.Text);
            int x4 = Convert.ToInt32(textBox18.Text);
            int y4 = Convert.ToInt32(textBox19.Text);

            int xdash = x1 * x;
            int xdash2 = x2 * x;
            int xdash3 = x3 * x;
            int xdash4 = x4 * x;


            int ydash = y1 * y;
            int ydash2 = y2 * y;
            int ydash3 = y3 * y;
            int ydash4 = y4 * y;
            Translate(xdash, ydash, xdash2, ydash2, xdash3, ydash3, xdash4, ydash4);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            panel1.CreateGraphics().Clear(Color.White);

            listBox1.Items.Clear();
            listBox2.Items.Clear();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox12.Text);
            int y1 = Convert.ToInt32(textBox13.Text);
            int x2 = Convert.ToInt32(textBox14.Text);
            int y2 = Convert.ToInt32(textBox15.Text);
            int x3 = Convert.ToInt32(textBox16.Text);
            int y3 = Convert.ToInt32(textBox17.Text);
            int x4 = Convert.ToInt32(textBox18.Text);
            int y4 = Convert.ToInt32(textBox19.Text);

            int angle = Convert.ToInt32(textBox22.Text);

            int xdash1 = Convert.ToInt32((Math.Cos(angle) * x1) + (-Math.Sin(angle) * y1));
            int ydash1 = Convert.ToInt32((Math.Sin(angle) * x1) + (Math.Cos(angle) * y1));
            int xdash2 = Convert.ToInt32((Math.Cos(angle) * x2) + (-Math.Sin(angle) * y2));
            int ydash2 = Convert.ToInt32((Math.Sin(angle) * x2) + (Math.Cos(angle) * y2));
            int xdash3 = Convert.ToInt32((Math.Cos(angle) * x3) + (-Math.Sin(angle) * y3));
            int ydash3 = Convert.ToInt32((Math.Sin(angle) * x3) + (Math.Cos(angle) * y3));
            int xdash4 = Convert.ToInt32((Math.Cos(angle) * x4) + (-Math.Sin(angle) * y4));
            int ydash4 = Convert.ToInt32((Math.Sin(angle) * x4) + (Math.Cos(angle) * y4));
            
            Translate(xdash1, ydash1, xdash2, ydash2, xdash3, ydash3, xdash4, ydash4);



        }

        private void button12_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox12.Text);
            int y1 = Convert.ToInt32(textBox13.Text);
            int x2 = Convert.ToInt32(textBox14.Text);
            int y2 = Convert.ToInt32(textBox15.Text);
            int x3 = Convert.ToInt32(textBox16.Text);
            int y3 = Convert.ToInt32(textBox17.Text);
            int x4 = Convert.ToInt32(textBox18.Text);
            int y4 = Convert.ToInt32(textBox19.Text);
            // int sy = Convert.ToInt32(textBox26.Text);
            int sx = Convert.ToInt32(textBox23.Text);




            int xdash = x1 + sx * y1;
            int xdash2 = x2 + sx * y2;
            int xdash3 = x3 + sx * y3;
            int xdash4 = x4 + sx * y4;

            int ydash = y1;
            int ydash2 = y2;
            int ydash3 = y3;
            int ydash4 = y4;
            Translate(xdash, ydash, xdash2, ydash2, xdash3, ydash3, xdash4, ydash4);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox12.Text);
            int y1 = Convert.ToInt32(textBox13.Text);
            int x2 = Convert.ToInt32(textBox14.Text);
            int y2 = Convert.ToInt32(textBox15.Text);
            int x3 = Convert.ToInt32(textBox16.Text);
            int y3 = Convert.ToInt32(textBox17.Text);
            int x4 = Convert.ToInt32(textBox18.Text);
            int y4 = Convert.ToInt32(textBox19.Text);
            int sy = Convert.ToInt32(textBox24.Text);
            //int sx = Convert.ToInt32(textBox23.Text);




            int xdash = x1;
            int xdash2 = x2;
            int xdash3 = x3;
            int xdash4 = x4;

            int ydash = y1 + sy * x1;
            int ydash2 = y2 + sy * x2;
            int ydash3 = y3 + sy * x3;
            int ydash4 = y4 + sy * x4;
            Translate(xdash, ydash, xdash2, ydash2, xdash3, ydash3, xdash4, ydash4);

        }
        static void multiply(int[,] mat1,
            int[,] mat2, int[,] res)
        {
            int N = 3;
            int i, j, k;
            for (i = 0; i < N; i++)
            {
                for (j = 0; j < N; j++)
                {
                    res[i, j] = 0;
                    for (k = 0; k < N; k++)
                        res[i, j] += mat1[i, k]
                                     * mat2[k, j];
                }
            }
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }
    }

}
