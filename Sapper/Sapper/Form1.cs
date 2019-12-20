using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SapperLogic;

namespace Sapper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Field gameField;
        List<MyButton> buts;
        private void Form1_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            buts = new List<MyButton>();
            for (int x = 25; this.Width - x > 50; x += 25)
            {
                for (int y = 25; this.Height - y > 50; y += 25)
                {
                    MyButton button;
                    if (rnd.Next(0, 100) <= 30) button = new MyButton(true);
                    else button = new MyButton(false);
                    button.Click += new System.EventHandler(ClickHandler);
                    button.Location = new Point(x, y);
                    button.Size = new Size(25, 25);
                    Controls.Add(button);
                    buts.Add(button);
                }
            }
            gameField = new Field(25, 25, 50, buts); //bombquantity is useless now
            for (int x = 0; x < gameField.Width; x++)
            {
                for (int y = 0; y < gameField.Height; y++)
                {
                    gameField[x, y].CellButton.BackgroundImage = Sapper.Properties.Resources.empty;
                }
            }

        }
        private void ClickHandler(object sender, EventArgs e)
        {
            MyButton but = (MyButton)sender;
            for (int i = 0; i < buts.Count; i++)
            {
                if (buts[i] == but)
                {
                    buts[i].BackgroundImage = Sapper.Properties.Resources.bomb;
                    MessageBox.Show(i.ToString());
                    break;
                }
            }
            Cell c = gameField.Cells.Where(c.CellButton==but);

        }
    }
  
}