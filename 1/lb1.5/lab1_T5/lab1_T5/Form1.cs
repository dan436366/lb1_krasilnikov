using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab1_T5
{
    public delegate void SuperButton(object sender, EventArgs e);
    public partial class Form1 : Form
    {

        private SuperButton superButton;
        private double prevOpacity;
        private Color prevColor;

        public Form1()
        {
            InitializeComponent();
            prevOpacity = this.Opacity;
            prevColor = this.BackColor;
        }

        private void BtnOpacity_Click(object sender, EventArgs e)
        {
            if (this.Opacity == 1.0)
            {
                this.Opacity = 0.7;
            }
            else
            {
                this.Opacity = 1.0;
            }
        }

        private void BackgroundColor_Click(object sender, EventArgs e)
        {
            if (this.BackColor == Color.Blue)
            {
                this.BackColor = prevColor;
            }
            else
            {
                prevColor = this.BackColor;
                this.BackColor = Color.Blue;
            }
        }

        private void CheckboxBackground_Click(object sender, EventArgs e)
        {
            superButton -= BackgroundColor_Click; 
            if (CheckboxBgColor.Checked)
            {
                superButton += BackgroundColor_Click; 
            }
        }

        private void CheckboxHelloWorld_Click(object sender, EventArgs e)
        {
            superButton -= HelloWorld_Click; 
            if (CheckboxHelloWorld.Checked)
            {
                superButton += HelloWorld_Click; 
            }
        }

        private void CheckboxOpacity_Click(object sender, EventArgs e)
        {
            superButton -= BtnOpacity_Click;
            if (CheckboxTransparency.Checked)
            {
                superButton += BtnOpacity_Click;
            }
        }

        private void HelloWorld_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hello world!");
        }

        private void BtnSuperMegaButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Я СУПЕРМЕГАКНОПКА,\nі цього мене не позбавиш!");
            superButton?.Invoke(sender, e);
        }
    }
}
