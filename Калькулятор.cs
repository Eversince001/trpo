using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Лабораторная_работа__2_ТРПО.ЛБР_2;

namespace Лабораторная_работа__2_ТРПО
{
    public partial class Конвертор : Form
    {
        //Объект класса Управление.
        private Control_ ctl = new Control_();
        private TProcessor<TPNumber> proc = new TProcessor<TPNumber>(10);
        private TProcessor<TPNumber> tmp = new TProcessor<TPNumber>(10);
        private TPNumber Lop = new TPNumber();
        private TPNumber Rop = new TPNumber();
        private TPNumber temp = new TPNumber();
        private Memory<TPNumber> Mem = new Memory<TPNumber>();
        private string CurrentNumber = "", intermediate = "";

        public Конвертор()
        {
            InitializeComponent();
        }

        //Обработчик события нажатия командной кнопки.
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (inNumber.Text != "0")
            {
                inNumber.Text += "0";
                CurrentNumber += "0";
                intermediate = CurrentNumber;
            }

        }

        private void DoCmnd(int j)
        {
            if (j == 19)
            {
                //deletezero();
            }
            else
            {
                if (ctl.St == Control_.State.Converted)
                {
                    //очистить содержимое редактора 
                    inNumber.Text = ctl.DoCmnd(18, "");
                }
                //выполнить команду редактирования


                if (inNumber.Text != "0")
                    inNumber.Text += ctl.DoCmnd(j, j.ToString());
                else
                    inNumber.Text = ctl.DoCmnd(j, j.ToString());
            }
        }
        //Обновляет состояние командных кнопок по основанию с. сч. исходного числа.

        private void UpdateButtons()
        {
            //просмотреть все компоненты формы
            foreach (Control i in Controls)
            {
                if (i is Button)//текущий компонент - командная кнопка 
                {
                    int j = Convert.ToInt16(i.Tag.ToString());
                    if (j < trackBar1.Value)
                    {
                        //сделать кнопку доступной
                        i.Enabled = true;
                    }
                    if ((j >= trackBar1.Value) && (j <= 15))
                    {
                        //сделать кнопку недоступной
                        i.Enabled = false;
                    }
                }
            }
        }
        //Изменяет значение основания с.сч. исходного числа.
        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            numericUpDown1.Value = trackBar1.Value;
        }

        //Изменяет значение основания с.сч. исходного числа.
        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            //Обновить состояние.
            trackBar1.Value = Convert.ToByte(numericUpDown1.Value);
            //Обновить состояние командных кнопок.
            this.UpdateP1();
        }
        //Выполняет необходимые обновления при смене ос. с.сч. р1.
        private void UpdateP1()
        {

            CurrentNumber = "";
            intermediate = "";
            NumberCache.Text = "";
            Mem.clear();

            ButtonMC.Enabled = false;
            ButtonMR.Enabled = false;
            ButtonMPlus.Enabled = false;

            //Сохранить р1 в объекте управление.
            ctl.Pout = trackBar1.Value;
            //Обновить состояние командных кнопок.
            this.UpdateButtons();

            if (inNumber.Text != "0" && !inNumber.Text.Contains("-") && !inNumber.Text.Contains("+") && !inNumber.Text.Contains("/") && !inNumber.Text.Contains("x"))
                inNumber.Text = ctl.DoCmnd(19, inNumber.Text);
            else
                inNumber.Text = "0";
            ctl.Pin = trackBar1.Value;
        }

        //Пункт меню Выход.
        private void выходToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Close();
        }
        //Пункт меню Справка.
        private void справкаToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Справка a = new Справка();
            a.ShowDialog();
        }
 
    
        //Обработка алфавитно-цифровых клавиш.
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
           int i = -1;
            if (e.KeyChar >= 'A' && e.KeyChar <= 'F')
                i = (int)e.KeyChar - 'A' + 10;
            if (e.KeyChar >= 'a' && e.KeyChar <= 'f')
                i = (int)e.KeyChar - 'a' + 10;
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
                i = (int)e.KeyChar - '0';
            if (e.KeyChar == '.')
            {
                if (CurrentNumber.Contains("."))
                    return;
                if (inNumber.Text[inNumber.Text.Length - 1] != '+' && inNumber.Text[inNumber.Text.Length - 1] != '/' && inNumber.Text[inNumber.Text.Length - 1] != 'x' && inNumber.Text[inNumber.Text.Length - 1] != '-')
                {
                    if (inNumber.Text == "16.")
                    {
                        inNumber.Text = "0";
                        inNumber.Text += ".";
                        CurrentNumber = inNumber.Text;
                        intermediate = CurrentNumber;
                    }
                    else
                    {
                        inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);
                        inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);
                        inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);
                        inNumber.Text += ".";
                        CurrentNumber += ".";
                        intermediate = CurrentNumber;
                    }
                }
                return;
            }
            if ((int)e.KeyChar == 8)
                i = 17;
            if ((int)e.KeyChar == 13)
                i = 19;
            if ((int)e.KeyChar == 45)//minus
            {
                if (inNumber.Text != "0")
                {
                    if (inNumber.Text.Contains("-") || inNumber.Text.Contains("+") || inNumber.Text.Contains("/") || inNumber.Text.Contains("x"))
                    {
                        if (inNumber.Text[inNumber.Text.Length - 1] != '+' && inNumber.Text[inNumber.Text.Length - 1] != '/' && inNumber.Text[inNumber.Text.Length - 1] != 'x' && inNumber.Text[inNumber.Text.Length - 1] != '-')
                        {
                            if (CurrentNumber[CurrentNumber.Length - 1] == '.') CurrentNumber = CurrentNumber.Remove(CurrentNumber.Length - 1);
                            Rop.number = CurrentNumber;
                            Rop.setC(trackBar1.Value);
                            Rop.setP(trackBar1.Value);
                            proc.setRop(Rop);
                            proc.doOp();
                            inNumber.Text = proc.Lop_Res.number;
                            intermediate = inNumber.Text;
                            CurrentNumber = proc.Lop_Res.number;
                        }
                    }

                    if (inNumber.Text[inNumber.Text.Length - 1] == '-')
                        return;
                    if (inNumber.Text[inNumber.Text.Length - 1] == '+' || inNumber.Text[inNumber.Text.Length - 1] == 'x' || inNumber.Text[inNumber.Text.Length - 1] == '/')
                    {
                        inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);
                    }

                    if (CurrentNumber != "")
                    if (CurrentNumber[CurrentNumber.Length - 1] == '.') CurrentNumber = CurrentNumber.Remove(CurrentNumber.Length - 1);
                    if (inNumber.Text[inNumber.Text.Length - 1] == '.') inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);
                    if (CurrentNumber == inNumber.Text) intermediate = CurrentNumber;

                    proc.setState(TProcessor<TPNumber>.OperationState.sub);
                    Lop.number = CurrentNumber;
                    CurrentNumber = "";
                    Lop.setP(trackBar1.Value);
                    Lop.setC(trackBar1.Value);
                    proc.setLop(Lop);
                    inNumber.Text += "-";
                }
                return;
            }

            if ((int)e.KeyChar == 43)//plus
            {
                if (inNumber.Text != "0")
                {
                    if (inNumber.Text.Contains("-") || inNumber.Text.Contains("+") || inNumber.Text.Contains("/") || inNumber.Text.Contains("x"))
                    {
                        if (inNumber.Text[inNumber.Text.Length - 1] != '+' && inNumber.Text[inNumber.Text.Length - 1] != '/' && inNumber.Text[inNumber.Text.Length - 1] != 'x' && inNumber.Text[inNumber.Text.Length - 1] != '-')
                        {
                            if (CurrentNumber[CurrentNumber.Length - 1] == '.') CurrentNumber = CurrentNumber.Remove(CurrentNumber.Length - 1);
                            Rop.number = CurrentNumber;
                            Rop.setC(trackBar1.Value);
                            Rop.setP(trackBar1.Value);
                            proc.setRop(Rop);
                            proc.doOp();
                            inNumber.Text = proc.Lop_Res.number;
                            intermediate = inNumber.Text;
                            CurrentNumber = proc.Lop_Res.number;
                        }
                    }

                    if (inNumber.Text[inNumber.Text.Length - 1] == '+')
                        return;

                    if (inNumber.Text[inNumber.Text.Length - 1] == '-' || inNumber.Text[inNumber.Text.Length - 1] == 'x' || inNumber.Text[inNumber.Text.Length - 1] == '/')
                    {
                        inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);
                    }

                    if (CurrentNumber != "")
                    if (CurrentNumber[CurrentNumber.Length - 1] == '.') CurrentNumber = CurrentNumber.Remove(CurrentNumber.Length - 1);
                    if (inNumber.Text[inNumber.Text.Length - 1] == '.') inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);
                    if (CurrentNumber == inNumber.Text) intermediate = CurrentNumber;

                    proc.setState(TProcessor<TPNumber>.OperationState.add);
                    Lop.number = CurrentNumber;
                    CurrentNumber = "";
                    Lop.setP(trackBar1.Value);
                    Lop.setC(trackBar1.Value);
                    proc.setLop(Lop);
                    inNumber.Text += "+";
                }
                return;
            }

            if ((int)e.KeyChar == 47)//div
            {
                if (inNumber.Text != "0")
                {
                    if (inNumber.Text.Contains("-") || inNumber.Text.Contains("+") || inNumber.Text.Contains("/") || inNumber.Text.Contains("x"))
                    {
                        if (inNumber.Text[inNumber.Text.Length - 1] != '+' && inNumber.Text[inNumber.Text.Length - 1] != '/' && inNumber.Text[inNumber.Text.Length - 1] != 'x' && inNumber.Text[inNumber.Text.Length - 1] != '-')
                        {
                            if (CurrentNumber[CurrentNumber.Length - 1] == '.') CurrentNumber = CurrentNumber.Remove(CurrentNumber.Length - 1);
                            Rop.number = CurrentNumber;
                            Rop.setC(trackBar1.Value);
                            Rop.setP(trackBar1.Value);
                            proc.setRop(Rop);
                            proc.doOp();
                            inNumber.Text = proc.Lop_Res.number;
                            intermediate = inNumber.Text;
                            CurrentNumber = proc.Lop_Res.number;
                        }
                    }

                    if (inNumber.Text[inNumber.Text.Length - 1] == '/')
                        return;
                    if (inNumber.Text[inNumber.Text.Length - 1] == '+' || inNumber.Text[inNumber.Text.Length - 1] == '-' || inNumber.Text[inNumber.Text.Length - 1] == 'x')
                    {
                        inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);
                    }

                    if (CurrentNumber != "")
                    if (CurrentNumber[CurrentNumber.Length - 1] == '.') CurrentNumber = CurrentNumber.Remove(CurrentNumber.Length - 1);
                    if (inNumber.Text[inNumber.Text.Length - 1] == '.') inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);
                    if (CurrentNumber == inNumber.Text) intermediate = CurrentNumber;


                    proc.setState(TProcessor<TPNumber>.OperationState.div);
                    Lop.number = CurrentNumber;
                    CurrentNumber = "";
                    Lop.setP(trackBar1.Value);
                    Lop.setC(trackBar1.Value);
                    proc.setLop(Lop);
                    inNumber.Text += "/";
                }
                    return;
            }

            if ((int)e.KeyChar == 42)//mult
            {
                if (inNumber.Text != "0")
                {
                    if (inNumber.Text.Contains("-") || inNumber.Text.Contains("+") || inNumber.Text.Contains("/") || inNumber.Text.Contains("x"))
                    {
                        if (inNumber.Text[inNumber.Text.Length - 1] != '+' && inNumber.Text[inNumber.Text.Length - 1] != '/' && inNumber.Text[inNumber.Text.Length - 1] != 'x' && inNumber.Text[inNumber.Text.Length - 1] != '-')
                        {
                            if (CurrentNumber[CurrentNumber.Length - 1] == '.') CurrentNumber = CurrentNumber.Remove(CurrentNumber.Length - 1);
                            Rop.number = CurrentNumber;
                            Rop.setC(trackBar1.Value);
                            Rop.setP(trackBar1.Value);
                            proc.setRop(Rop);
                            proc.doOp();
                            inNumber.Text = proc.Lop_Res.number;
                            intermediate = inNumber.Text;
                            CurrentNumber = proc.Lop_Res.number;
                        }
                    }

                    if (inNumber.Text[inNumber.Text.Length - 1] == 'x')
                        return;
                    if (inNumber.Text[inNumber.Text.Length - 1] == '+' || inNumber.Text[inNumber.Text.Length - 1] == '-' || inNumber.Text[inNumber.Text.Length - 1] == '/')
                    {
                        inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);
                    }


                    if (CurrentNumber != "")
                    if (CurrentNumber[CurrentNumber.Length - 1] == '.') CurrentNumber = CurrentNumber.Remove(CurrentNumber.Length - 1);
                    if (inNumber.Text[inNumber.Text.Length - 1] == '.') inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);
                    if (CurrentNumber == inNumber.Text) intermediate = CurrentNumber;

                    proc.setState(TProcessor<TPNumber>.OperationState.mult);
                    Lop.number = CurrentNumber;
                    CurrentNumber = "";
                    Lop.setP(trackBar1.Value);
                    Lop.setC(trackBar1.Value);
                    proc.setLop(Lop);
                    inNumber.Text += "x";

                }
                return;
            }

            if ((int)e.KeyChar == 61)
            {
                if (proc.getState() != TProcessor<TPNumber>.OperationState.none)
                {
                    if (inNumber.Text[inNumber.Text.Length - 1] != '+' || inNumber.Text[inNumber.Text.Length - 1] != '/' || inNumber.Text[inNumber.Text.Length - 1] != 'x' || inNumber.Text[inNumber.Text.Length - 1] != '-')
                    {

                        Rop.number = intermediate;
                        Rop.setC(trackBar1.Value);
                        Rop.setP(trackBar1.Value);
                        proc.setRop(Rop);
                        proc.doOp();
                        inNumber.Text = proc.Lop_Res.number;
                        CurrentNumber = inNumber.Text;
                    }
                    else
                    {
                        CurrentNumber = "";
                        Rop.number = CurrentNumber;
                        proc.doOp();
                        inNumber.Text = proc.Lop_Res.number;
                    }
                }
                return;
            }

            if ((int)e.KeyChar == 8)
            {
                if (inNumber.Text.Length != 1)
                {
                    if (inNumber.Text[inNumber.Text.Length - 1] == '+' || inNumber.Text[inNumber.Text.Length - 1] == '/' || inNumber.Text[inNumber.Text.Length - 1] == 'x' || inNumber.Text[inNumber.Text.Length - 1] == '-')
                    {
                        inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);
                        CurrentNumber = inNumber.Text;
                        intermediate = CurrentNumber;
                    }
                    else
                    {
                        inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);
                        CurrentNumber = CurrentNumber.Remove(CurrentNumber.Length - 1);
                        intermediate = CurrentNumber;
                    }
                }
                else
                {
                    inNumber.Text = "0";
                    CurrentNumber = "";
                    intermediate = "";
                }
                return;
            }

            if ((i < ctl.Pin) || (i >= 16))
            {
                DoCmnd(i);
                if (i < 10 && i >= 0 )
                {
                    CurrentNumber += i;
                    intermediate = CurrentNumber;
                }
                else
                {
                    switch (i)
                    {
                        case 10:
                            CurrentNumber += 'A';
                            intermediate = CurrentNumber;
                            break;
                        case 11:
                            CurrentNumber += 'B';
                            intermediate = CurrentNumber;
                            break;
                        case 12:
                            CurrentNumber += 'C';
                            intermediate = CurrentNumber;
                            break;
                        case 13:
                            CurrentNumber += 'D';
                            intermediate = CurrentNumber;
                            break;
                        case 14:
                            CurrentNumber += 'E';
                            intermediate = CurrentNumber;
                            break;
                        case 15:
                            CurrentNumber += 'F';
                            intermediate = CurrentNumber;
                            break;
                    }
                }
            }
        }

        //Обработка клавиш управления.
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                //Клавиша Delete.
                DoCmnd(18);
            if (e.KeyCode == Keys.Execute)
                //Клавиша Execute Separator.
                DoCmnd(19);
            if (e.KeyCode == Keys.Decimal)
                //Клавиша Decimal.
                DoCmnd(16);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (inNumber.Text == "0")
            {
                inNumber.Text = "1";
                CurrentNumber = "1";
                intermediate = CurrentNumber;
            }
            else
            {
                CurrentNumber += "1";
                inNumber.Text += "1";
                intermediate = CurrentNumber;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (inNumber.Text == "0")
            {
                inNumber.Text = "2";
                CurrentNumber = "2";
                intermediate = CurrentNumber;
            }
            else
            {
                CurrentNumber += "2";
                inNumber.Text += "2";
                intermediate = CurrentNumber;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (inNumber.Text == "0")
            {
                inNumber.Text = "3";
                CurrentNumber = "3";
                intermediate = CurrentNumber;
            }
            else
            {
                CurrentNumber += "3";
                inNumber.Text += "3";
                intermediate = CurrentNumber;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (inNumber.Text == "0")
            {
                inNumber.Text = "4";
                CurrentNumber = "4";
                intermediate = CurrentNumber;
            }
            else
            {
                CurrentNumber += "4";
                inNumber.Text += "4";
                intermediate = CurrentNumber;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (inNumber.Text == "0")
            {
                inNumber.Text = "5";
                CurrentNumber = "5";
                intermediate = CurrentNumber;
            }
            else
            {
                CurrentNumber += "5";
                inNumber.Text += "5";
                intermediate = CurrentNumber;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (inNumber.Text == "0")
            {
                inNumber.Text = "6";
                CurrentNumber = "6";
                intermediate = CurrentNumber;
            }
            else
            {
                CurrentNumber += "6";
                inNumber.Text += "6";
                intermediate = CurrentNumber;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (inNumber.Text == "0")
            {
                inNumber.Text = "7";
                CurrentNumber = "7";
                intermediate = CurrentNumber;
            }
            else
            {
                CurrentNumber += "7";
                inNumber.Text += "7";
                intermediate = CurrentNumber;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (inNumber.Text == "0")
            {
                inNumber.Text = "8";
                CurrentNumber = "8";
                intermediate = CurrentNumber;
            }
            else
            {
                CurrentNumber += "8";
                inNumber.Text += "8";
                intermediate = CurrentNumber;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (inNumber.Text == "0")
            {
                inNumber.Text = "9";
                CurrentNumber = "9";
                intermediate = CurrentNumber;
            }
            else
            {
                CurrentNumber += "9";
                inNumber.Text += "9";
                intermediate = CurrentNumber;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (inNumber.Text == "0")
            {
                inNumber.Text = "A";
                CurrentNumber = "A";
                intermediate = CurrentNumber;
            }
            else
            {
                inNumber.Text += "A";
                CurrentNumber += "A";
                intermediate = CurrentNumber;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (inNumber.Text == "0")
            {
                inNumber.Text = "B";
                CurrentNumber = "B";
                intermediate = CurrentNumber;
            }
            else
            {
                inNumber.Text += "B";
                CurrentNumber += "B";
                intermediate = CurrentNumber;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (inNumber.Text == "0")
            {
                inNumber.Text = "C";
                CurrentNumber = "C";
                intermediate = CurrentNumber;
            }
            else
            {
                inNumber.Text += "C";
                CurrentNumber += "C";
                intermediate = CurrentNumber;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (inNumber.Text == "0")
            {
                inNumber.Text = "D";
                CurrentNumber = "D";
                intermediate = CurrentNumber;
            }
            else
            {
                inNumber.Text += "D";
                CurrentNumber += "D";
                intermediate = CurrentNumber;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (inNumber.Text == "0")
            {
                inNumber.Text = "E";
                CurrentNumber = "E";
                intermediate = CurrentNumber;
            }
            else
            {
                inNumber.Text += "E";
                CurrentNumber += "E";
                intermediate = CurrentNumber;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (inNumber.Text == "0")
            {
                inNumber.Text = "F";
                CurrentNumber = "F";
                intermediate = CurrentNumber;
            }
            else
            {
                inNumber.Text += "F";
                CurrentNumber += "F";
                intermediate = CurrentNumber;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {

            if (CurrentNumber.Contains("."))
                return;
            if (inNumber.Text[inNumber.Text.Length - 1] != '+' && inNumber.Text[inNumber.Text.Length - 1] != '/' && inNumber.Text[inNumber.Text.Length - 1] != 'x' && inNumber.Text[inNumber.Text.Length - 1] != '-')
            {
                inNumber.Text += ".";
                CurrentNumber += ".";
                intermediate = CurrentNumber;
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (inNumber.Text.Length != 1)
            {
                if (inNumber.Text[inNumber.Text.Length - 1] == '+' || inNumber.Text[inNumber.Text.Length - 1] == '/' || inNumber.Text[inNumber.Text.Length - 1] == 'x' || inNumber.Text[inNumber.Text.Length - 1] == '-')
                {
                    inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);
                    CurrentNumber = inNumber.Text;
                    intermediate = CurrentNumber;
                }
                else
                {
                    inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);
                    CurrentNumber = CurrentNumber.Remove(CurrentNumber.Length - 1);
                    intermediate = CurrentNumber;
                }
            }
            else
            {
                inNumber.Text = "0";
                CurrentNumber = "";
                intermediate = "";
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            inNumber.Text = "0";
            CurrentNumber = "";
            intermediate = CurrentNumber;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (inNumber.Text[inNumber.Text.Length - 1] == '-')
            {
                inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);
                inNumber.Text += "+";
            }

            if (inNumber.Text[inNumber.Text.Length - 1] == '+')
            {
                inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);
                inNumber.Text += "-";
            }

        }

        private void Конвертор_Load(object sender, EventArgs e)
        {
            inNumber.Text = ctl.ed.number;
            //Основание с.сч. исходного числа р1.
            trackBar1.Value = ctl.Pin;
            numericUpDown1.Value = ctl.Pin;
            inNumber.Text = "0";
            ButtonMC.Enabled = false;
            ButtonMR.Enabled = false;
            ButtonMPlus.Enabled = false;
            //Обновить состояние командных кнопок.
            this.UpdateButtons();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (proc.getState() != TProcessor<TPNumber>.OperationState.none)
            {
                if (inNumber.Text[inNumber.Text.Length - 1] != '+' || inNumber.Text[inNumber.Text.Length - 1] != '/' || inNumber.Text[inNumber.Text.Length - 1] != 'x' || inNumber.Text[inNumber.Text.Length - 1] != '-')
                {

                    Rop.number = intermediate;
                    Rop.setC(trackBar1.Value);
                    Rop.setP(trackBar1.Value);
                    proc.setRop(Rop);
                    proc.doOp();
                    inNumber.Text = proc.Lop_Res.number;
                    CurrentNumber = inNumber.Text;
                }
                else
                {
                    CurrentNumber = "";
                    Rop.number = CurrentNumber;
                    proc.doOp();
                    inNumber.Text = proc.Lop_Res.number;
                }
            }
        }

        private void ButtonPlus_Click(object sender, EventArgs e)
        {

            if (inNumber.Text != "0")
            {
                if (inNumber.Text.Contains("-") || inNumber.Text.Contains("+") || inNumber.Text.Contains("/") || inNumber.Text.Contains("x"))
                {
                    if (inNumber.Text[inNumber.Text.Length - 1] != '+' && inNumber.Text[inNumber.Text.Length - 1] != '/' && inNumber.Text[inNumber.Text.Length - 1] != 'x' && inNumber.Text[inNumber.Text.Length - 1] != '-')
                    {
                        if (CurrentNumber[CurrentNumber.Length - 1] == '.') CurrentNumber =  CurrentNumber.Remove(CurrentNumber.Length - 1);
                        Rop.number = CurrentNumber;
                        Rop.setC(trackBar1.Value);
                        Rop.setP(trackBar1.Value);
                        proc.setRop(Rop);
                        proc.doOp();
                        inNumber.Text = proc.Lop_Res.number;
                        intermediate = inNumber.Text;
                        CurrentNumber = proc.Lop_Res.number;
                    }
                }

                if (inNumber.Text[inNumber.Text.Length - 1] == '+')
                    return;

                if (inNumber.Text[inNumber.Text.Length - 1] == '-' || inNumber.Text[inNumber.Text.Length - 1] == 'x' || inNumber.Text[inNumber.Text.Length - 1] == '/')
                {
                    inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);
                }

                if (CurrentNumber != "")
                if (CurrentNumber[CurrentNumber.Length - 1] == '.') CurrentNumber = CurrentNumber.Remove(CurrentNumber.Length - 1);
                if (inNumber.Text[inNumber.Text.Length - 1] == '.') inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);
                if (CurrentNumber == inNumber.Text) intermediate = CurrentNumber;

                proc.setState(TProcessor<TPNumber>.OperationState.add);
                Lop.number = CurrentNumber;
                CurrentNumber = "";
                Lop.setP(trackBar1.Value);
                Lop.setC(trackBar1.Value);
                proc.setLop(Lop);
                inNumber.Text += "+";
            }

        }

        private void ButtonMinus_Click(object sender, EventArgs e)
        {
            if (inNumber.Text != "0")
            {
                if (inNumber.Text.Contains("-") || inNumber.Text.Contains("+") || inNumber.Text.Contains("/") || inNumber.Text.Contains("x"))
                {
                    if (inNumber.Text[inNumber.Text.Length - 1] != '+' && inNumber.Text[inNumber.Text.Length - 1] != '/' && inNumber.Text[inNumber.Text.Length - 1] != 'x' && inNumber.Text[inNumber.Text.Length - 1] != '-')
                    {
                        if (CurrentNumber[CurrentNumber.Length - 1] == '.') CurrentNumber = CurrentNumber.Remove(CurrentNumber.Length - 1);
                        Rop.number = CurrentNumber; 
                        Rop.setC(trackBar1.Value);
                        Rop.setP(trackBar1.Value);
                        proc.setRop(Rop);
                        proc.doOp();
                        inNumber.Text = proc.Lop_Res.number;
                        intermediate = inNumber.Text;
                        CurrentNumber = proc.Lop_Res.number;
                    }
                }

                if (inNumber.Text[inNumber.Text.Length - 1] == '-')
                    return;
                if (inNumber.Text[inNumber.Text.Length - 1] == '+' || inNumber.Text[inNumber.Text.Length - 1] == 'x' || inNumber.Text[inNumber.Text.Length - 1] == '/')
                {
                    inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);
                }

                if (CurrentNumber != "")
                if (CurrentNumber[CurrentNumber.Length - 1] == '.') CurrentNumber = CurrentNumber.Remove(CurrentNumber.Length - 1);
                if (inNumber.Text[inNumber.Text.Length - 1] == '.') inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);
                if (CurrentNumber == inNumber.Text) intermediate = CurrentNumber;

                proc.setState(TProcessor<TPNumber>.OperationState.sub);
                Lop.number = CurrentNumber;
                CurrentNumber = "";
                Lop.setP(trackBar1.Value);
                Lop.setC(trackBar1.Value);
                proc.setLop(Lop);
                inNumber.Text += "-";
            }
        }

        private void ButtonMult_Click(object sender, EventArgs e)
        {
            if (inNumber.Text != "0")
            {
                if (inNumber.Text.Contains("-") || inNumber.Text.Contains("+") || inNumber.Text.Contains("/") || inNumber.Text.Contains("x"))
                {
                    if (inNumber.Text[inNumber.Text.Length - 1] != '+' && inNumber.Text[inNumber.Text.Length - 1] != '/' && inNumber.Text[inNumber.Text.Length - 1] != 'x' && inNumber.Text[inNumber.Text.Length - 1] != '-')
                    {
                        if (CurrentNumber[CurrentNumber.Length - 1] == '.') CurrentNumber = CurrentNumber.Remove(CurrentNumber.Length - 1);
                        Rop.number = CurrentNumber;
                        Rop.setC(trackBar1.Value);
                        Rop.setP(trackBar1.Value);
                        proc.setRop(Rop);
                        proc.doOp();
                        inNumber.Text = proc.Lop_Res.number;
                        intermediate = inNumber.Text;
                        CurrentNumber = proc.Lop_Res.number;
                    }
                }

                if (inNumber.Text[inNumber.Text.Length - 1] == 'x')
                    return;
                if (inNumber.Text[inNumber.Text.Length - 1] == '+' || inNumber.Text[inNumber.Text.Length - 1] == '-' || inNumber.Text[inNumber.Text.Length - 1] == '/')
                {
                    inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);
                }

                if (CurrentNumber != "")
                if (CurrentNumber[CurrentNumber.Length - 1] == '.') CurrentNumber = CurrentNumber.Remove(CurrentNumber.Length - 1);
                if (inNumber.Text[inNumber.Text.Length - 1] == '.') inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);
                if (CurrentNumber == inNumber.Text) intermediate = CurrentNumber;

                proc.setState(TProcessor<TPNumber>.OperationState.mult);
                Lop.number = CurrentNumber;
                CurrentNumber = "";
                Lop.setP(trackBar1.Value);
                Lop.setC(trackBar1.Value);
                proc.setLop(Lop);
                inNumber.Text += "x";

            }

        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (inNumber.Text != "0")
            {
                if (inNumber.Text.Contains("-") || inNumber.Text.Contains("+") || inNumber.Text.Contains("/") || inNumber.Text.Contains("x"))
                {
                    if (inNumber.Text[inNumber.Text.Length - 1] != '+' && inNumber.Text[inNumber.Text.Length - 1] != '/' && inNumber.Text[inNumber.Text.Length - 1] != 'x' && inNumber.Text[inNumber.Text.Length - 1] != '-')
                    {
                        if (CurrentNumber[CurrentNumber.Length - 1] == '.') CurrentNumber = CurrentNumber.Remove(CurrentNumber.Length - 1);
                        Rop.number = CurrentNumber;
                        Rop.setC(trackBar1.Value);
                        Rop.setP(trackBar1.Value);
                        proc.setRop(Rop);
                        proc.doOp();
                        inNumber.Text = proc.Lop_Res.number;
                        intermediate = inNumber.Text;
                        CurrentNumber = proc.Lop_Res.number;
                    }
                }

                if (inNumber.Text[inNumber.Text.Length - 1] == '/')
                    return;
                if (inNumber.Text[inNumber.Text.Length - 1] == '+' || inNumber.Text[inNumber.Text.Length - 1] == '-' || inNumber.Text[inNumber.Text.Length - 1] == 'x')
                {
                    inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);
                }

                if (CurrentNumber != "")
                if (CurrentNumber[CurrentNumber.Length - 1] == '.') CurrentNumber = CurrentNumber.Remove(CurrentNumber.Length - 1);
                if (inNumber.Text[inNumber.Text.Length - 1] == '.') inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);
                if (CurrentNumber == inNumber.Text) intermediate = CurrentNumber;


                proc.setState(TProcessor<TPNumber>.OperationState.div);
                Lop.number = CurrentNumber;
                CurrentNumber = "";
                Lop.setP(trackBar1.Value);
                Lop.setC(trackBar1.Value);
                proc.setLop(Lop);
                inNumber.Text += "/";

            }
        }

        private void ButtonSQR_Click(object sender, EventArgs e)
        {
            if (inNumber.Text != "0")
            {
                if (inNumber.Text[inNumber.Text.Length - 1] != '+' && inNumber.Text[inNumber.Text.Length - 1] != '/' && inNumber.Text[inNumber.Text.Length - 1] != 'x' && inNumber.Text[inNumber.Text.Length - 1] != '-')
                {
                    for (int i = 0; i < CurrentNumber.Length; i++)
                        inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);

                    if (!inNumber.Text.Contains("-") && !inNumber.Text.Contains("+") && !inNumber.Text.Contains("/") && !inNumber.Text.Contains("x"))
                    {
                        tmp.State = proc.State;
                        proc.setState(TProcessor<TPNumber>.OperationState.sqr);
                        Lop.number = CurrentNumber;
                        Lop.setP(trackBar1.Value);
                        Lop.setC(trackBar1.Value);
                        proc.setLop(Lop);
                        proc.doFunc(false);
                        inNumber.Text += proc.Lop_Res.number;
                        CurrentNumber = inNumber.Text;
                        Lop.number = CurrentNumber;
                        proc.State = tmp.State;
                    }
                    else
                    {
                        tmp.State = proc.State;
                        proc.setState(TProcessor<TPNumber>.OperationState.sqr);
                        Rop.number = CurrentNumber;
                        Rop.setP(trackBar1.Value);
                        Rop.setC(trackBar1.Value);
                        proc.setRop(Rop);
                        proc.doFunc(true);
                        inNumber.Text += proc.Rop.number;
                        CurrentNumber = proc.Rop.number;
                        Rop.number = CurrentNumber;
                        proc.State = tmp.State;
                    }

                }
                else
                {
                    tmp.State = proc.State;
                    inNumber.Text = "";
                    proc.setState(TProcessor<TPNumber>.OperationState.sqr);
                    proc.doFunc(false);
                    inNumber.Text += proc.Lop_Res.number;
                    CurrentNumber = inNumber.Text;
                    Lop.number = CurrentNumber;
                    proc.State = tmp.State;
                }



            }
        }

        private void Button1Delx_Click(object sender, EventArgs e)
        {
            if (inNumber.Text != "0")
            {
                if (inNumber.Text[inNumber.Text.Length - 1] != '+' && inNumber.Text[inNumber.Text.Length - 1] != '/' && inNumber.Text[inNumber.Text.Length - 1] != 'x' && inNumber.Text[inNumber.Text.Length - 1] != '-')
                {
                    for (int i = 0; i < CurrentNumber.Length; i++)
                        inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);

                    if (!inNumber.Text.Contains("-") && !inNumber.Text.Contains("+") && !inNumber.Text.Contains("/") && !inNumber.Text.Contains("x"))
                    {
                        tmp.State = proc.State;
                        proc.setState(TProcessor<TPNumber>.OperationState.rev);
                        Lop.number = CurrentNumber;
                        Lop.setP(trackBar1.Value);
                        Lop.setC(trackBar1.Value);
                        proc.setLop(Lop);
                        proc.doFunc(false);
                        inNumber.Text += proc.Lop_Res.number;
                        CurrentNumber = inNumber.Text;
                        Lop.number = CurrentNumber;
                        proc.State = tmp.State;
                    }
                    else
                    {
                        tmp.State = proc.State;
                        proc.setState(TProcessor<TPNumber>.OperationState.rev);
                        Rop.number = CurrentNumber;
                        Rop.setP(trackBar1.Value);
                        Rop.setC(trackBar1.Value);
                        proc.setRop(Rop);
                        proc.doFunc(true);
                        inNumber.Text += proc.Rop.number;
                        CurrentNumber = proc.Rop.number;
                        Rop.number = CurrentNumber;
                        proc.State = tmp.State;
                    }

                }
                else
                {
                    tmp.State = proc.State;
                    inNumber.Text = "";
                    proc.setState(TProcessor<TPNumber>.OperationState.rev);
                    proc.doFunc(false);
                    inNumber.Text += proc.Lop_Res.number;
                    CurrentNumber = inNumber.Text;
                    Lop.number = CurrentNumber;
                    proc.State = tmp.State;
                }

            }
        }

        private void ButtonMC_Click(object sender, EventArgs e)
        {
            if (Mem.getFS() == Memory<TPNumber>.FState._on)
            {
                NumberCache.Text = "";
                Mem.clear();
            }

            ButtonMC.Enabled = false;
            ButtonMR.Enabled = false;
            ButtonMPlus.Enabled = false;
        }

        private void ButtonMS_Click(object sender, EventArgs e)
        {

            if (inNumber.Text == "0")
            {
                temp.number = "0";
            }
            else
            {
                temp.number = CurrentNumber;
            }
            temp.setP(trackBar1.Value);
            temp.setC(trackBar1.Value);
            Mem.store(temp);

            NumberCache.Text = temp.number;

            ButtonMC.Enabled = true;
            ButtonMR.Enabled = true;
            ButtonMPlus.Enabled = true;
        }

        private void ButtonMPlus_Click(object sender, EventArgs e)
        {
            temp.number = CurrentNumber;
            temp.setP(trackBar1.Value);
            temp.setC(trackBar1.Value);
            Mem.add(temp);

            temp = Mem.getFNumber();

            NumberCache.Text = temp.number;
        }

        private void ButtonMR_Click(object sender, EventArgs e)
        {
            if (Mem.getFS() == Memory<TPNumber>.FState._on)
            {
                for (int i = 0; i < CurrentNumber.Length; i++)
                {
                    inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);
                }

                temp = Mem.getFNumber();
                CurrentNumber = temp.number;
                intermediate = CurrentNumber;


                if (inNumber.Text == "0")
                {
                    inNumber.Text = CurrentNumber;
                }
                else
                {
                    inNumber.Text += CurrentNumber;
                }
            }
        }

        private void вставитьИзБуфераToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inNumber.Text = Clipboard.GetText();
        }

        private void копироватьВБуферToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(inNumber.Text);
        }



    }
}
