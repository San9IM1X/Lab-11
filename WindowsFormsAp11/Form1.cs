using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAp11
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        int x = 0, y = 0, r = 25, step = 1;
        byte part;
        Pen p = new Pen(Color.Black, 2);

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawEllipse(p, x, y, r, r);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((y + r) < ClientSize.Height && x == 0)
            {
                y += step;
                part = 1;
            }
            else
            {
                if ((y + r) == ClientSize.Height && (x + r) < ClientSize.Width)
                {
                    x += step;
                    part = 2;
                }
                else
                {
                    if ((x + r) == ClientSize.Width && y > 0)
                    {
                        y -= step;
                        part = 3;
                    }
                    else
                    {
                        if (y == 0 && (x + r) > 0)
                        {
                            x -= step;
                            part = 4;
                        }
                        else
                        {
                            if (part == 2)
                            {
                                if ((x + 2 * r) > ClientSize.Width)
                                    x -= step;
                                y += step * Math.Sign(ClientSize.Height - (y + r));
                            }
                            else
                            {
                                if (part == 3)
                                {
                                    x += step * Math.Sign(ClientSize.Width - (x + r));
                                }
                                else
                                    if (part == 1)
                                {
                                    y -= step;
                                }
                            }
                        }

                    }
                }
            }

            Invalidate();
        }
    }
    
}
