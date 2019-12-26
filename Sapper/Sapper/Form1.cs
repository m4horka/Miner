using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        int ct = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            
            Random rnd = new Random();
            buts = new List<MyButton>();
            for (int x = 25; this.Width - x > 50; x += 25)
            {
                for (int y = 50; this.Height - 25-y > 50; y += 25)
                {
                    MyButton button;
                    if (rnd.Next(0, 100) <= 30)
                    {
                        button = new MyButton(true);

                    }
                    else
                    {
                        button = new MyButton(false);
                        ct++;
                    }
                    button.MouseDown += Button_MouseDown;
                    button.Location = new Point(x, y);
                    button.Size = new Size(25, 25);
                    Controls.Add(button);
                    buts.Add(button);
                }
            }
            gameField = new Field(25, 25, 50, buts);
            bombsleft.Text = ct + " places without bombs left";
            for (int x = 0; x < gameField.Width; x++)
            {
                for (int y = 0; y < gameField.Height; y++)
                {
                    gameField[x, y].CellButton.BackgroundImage = Sapper.Properties.Resources.empty;
                    gameField[x, y].IsMark = false;
                    gameField[x, y].IsOpened = false;
                }
            }


        }

        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            int yc = 0, xc = 0;
            MouseEventArgs me = (MouseEventArgs)e;
            MyButton but = (MyButton)sender;
            if (me.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (but.IsBomb == true)
                {
                    but.BackgroundImage = Sapper.Properties.Resources.bomb;
                    for (int i = 0; i < gameField.Butts.Count; i++)
                    {
                        if (buts[i].IsBomb == true)
                        {
                            buts[i].BackgroundImage = Sapper.Properties.Resources.bomb;
                        }
                    }
                    MessageBox.Show("Вы проиграли!", "конец :-(");
                    this.Close();
                }
                else
                {
                    for (int i = 0; i < gameField.Butts.Count; i++)
                    {
                        if (gameField.Butts[i] == but)
                        {
                            yc = i % gameField.Width;
                            xc = i / gameField.Width;
                            int cnt = 0;
                            if (gameField[xc, yc] is Empty)
                            {
                                if (gameField[xc, yc + 1] is Bomb)
                                {
                                    cnt++;
                                }
                                if (gameField[xc + 1, yc + 1] is Bomb)
                                {
                                    cnt++;
                                }
                                if (gameField[xc + 1, yc] is Bomb)
                                {
                                    cnt++;
                                }
                                if (gameField[xc + 1, yc - 1] is Bomb)
                                {
                                    cnt++;
                                }
                                if (gameField[xc, yc - 1] is Bomb)
                                {
                                    cnt++;
                                }
                                if (gameField[xc - 1, yc - 1] is Bomb)
                                {
                                    cnt++;
                                }
                                if (gameField[xc - 1, yc] is Bomb)
                                {
                                    cnt++;
                                }
                                if (gameField[xc - 1, yc + 1] is Bomb)
                                {
                                    cnt++;
                                }
                            }
                            but.Text = cnt.ToString();
                            but.BackgroundImage = Sapper.Properties.Resources.emptyopened;
                            gameField[xc, yc].IsOpened = true;
                            ct--;
                            bombsleft.Text = ct + " places without bombs left";
                        }
                    }
                }
            }

            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                for (int i = 0; i < gameField.Butts.Count; i++)
                {
                    if (gameField.Butts[i] == but)
                    {
                        yc = i % gameField.Width;
                        xc = i / gameField.Width;
                        if (gameField[xc, yc].IsMark == false && gameField[xc, yc].IsOpened == false)
                        {
                            gameField[xc, yc].IsMark = true;
                            gameField[xc, yc].CellButton.BackgroundImage = Sapper.Properties.Resources.mark;
                        }
                        else if (gameField[xc, yc].IsMark == true && gameField[xc, yc].IsOpened == false)
                        {
                            gameField[xc, yc].IsMark = false;
                            gameField[xc, yc].CellButton.BackgroundImage = Sapper.Properties.Resources.empty;
                        }
                    }
                }
            }
        }

        
    }
  
}