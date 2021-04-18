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
        private Control_ ctl = new Control_();

        private TCtrl ctrl = new TCtrl();

        private int state = 1, ResultState = 0, divState = 0, divState1 = 0;

        public Конвертор()
        {
            InitializeComponent();
        }

        //Обработчик события нажатия командной кнопки.
        private void button1_Click_1(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            int j = Convert.ToInt16(but.Tag.ToString());
            DoCmnd(j);
            UpdateButtons();
        }

        private void DoCmnd(int j)
        {
            if (state == 1)
            {
                if (ResultState == 0)
                {
                    ctrl.processor.LeftOp.number = ctrl.DoCommand(j);
                    inNumber.Text = ctrl.processor.LeftOp.getNumber();
                }
                
                if (ResultState == 1)
                {
                    var tmp = "";

                    if (j > 9)
                    {
                       
                        switch (j)
                        {
                            case 10: tmp = "A"; break;
                            case 11: tmp = "B"; break;
                            case 12: tmp = "C"; break;
                            case 13: tmp = "D"; break;
                            case 14: tmp = "E"; break;
                            case 15: tmp = "F"; break;

                        }
                    }
                    else
                    {
                        tmp = j.ToString();
                    }

                    if (inNumber.Text[inNumber.Text.Length - 1] != '/' && inNumber.Text[inNumber.Text.Length - 1] != '*' && inNumber.Text[inNumber.Text.Length - 1] != '+' && inNumber.Text[inNumber.Text.Length - 1] != '-')
                    {
                        ctrl.processor.RightOp.number += tmp;
                        inNumber.Text += tmp;
                    }
                    else
                    {
                        ctrl.processor.RightOp.number = "";
                        ctrl.processor.RightOp.number += tmp;
                        inNumber.Text += tmp;
                    }
                }
                
                if (ResultState == 2)
                {
                    ctrl.processor.LeftOp.number = ctrl.DoCommand(j);
                    inNumber.Text = ctrl.processor.LeftOp.getNumber();
                }

                if (ResultState == 3)
                {
                    if (ctrl.processor.RightOp.number != "0" && (inNumber.Text.Contains('/') || inNumber.Text.Contains('*') || inNumber.Text.Contains('+') || inNumber.Text.Contains('-')))
                    {
                        ctrl.editor.State = 1;
                        for (int i = 0; i < ctrl.processor.RightOp.number.Length; i++)
                            inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);

                        ctrl.processor.RightOp.number = ctrl.DoCommand(j);
                        inNumber.Text += ctrl.processor.RightOp.number;
                    }
                    else
                    {
                        ctrl.editor.State = 0;
                        ctrl.processor.LeftOp.number = ctrl.DoCommand(j);
                        inNumber.Text = ctrl.processor.LeftOp.getNumber();
                    }

                }

                if (ResultState == 4)
                {
                    if (ctrl.processor.RightOp.number != "0" && (inNumber.Text.Contains('/') || inNumber.Text.Contains('*') || inNumber.Text.Contains('+') || inNumber.Text.Contains('-')))
                    {
                        ctrl.editor.State = 1;
                        for (int i = 0; i < ctrl.processor.RightOp.number.Length; i++)
                            inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);

                        ctrl.processor.RightOp.number = ctrl.DoCommand(j);
                        inNumber.Text += ctrl.processor.RightOp.number;
                    }
                    else
                    {
                        ctrl.editor.State = 0;
                        ctrl.processor.LeftOp.number = ctrl.DoCommand(j);
                        inNumber.Text = ctrl.processor.LeftOp.getNumber();
                    }
                }

            }

            if (state == 2)
            {
                if (ResultState == 0)
                {
                    if (divState == 0)
                    {
                        var str = ctrl.DoCommandFract(j).Split('|');
                        ctrl.Fprocessor.LeftOp.number.numer = str[0];
                        ctrl.Fprocessor.LeftOp.number.denom = str[1];

                    }

                    if (divState == 1)
                    {
                        if (ctrl.Fprocessor.LeftOp.number.denom == "1" && divState1 != 1)
                        {
                            ctrl.Fprocessor.LeftOp.number.denom = ctrl.Fprocessor.LeftOp.number.denom.Remove(ctrl.Fprocessor.LeftOp.number.denom.Length - 1);
                            inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);
                            ctrl.Fprocessor.LeftOp.number.denom += j.ToString();
                            divState1 = 1;
                        }
                        else
                        {
                            ctrl.Fprocessor.LeftOp.number.denom += j.ToString();
                        }
                    }

                    inNumber.Text = ctrl.Fprocessor.LeftOp.NumberString;
                }

                if (ResultState == 1)
                {
                    if (inNumber.Text[inNumber.Text.Length - 1] == '/' || inNumber.Text[inNumber.Text.Length - 1] == '*' || inNumber.Text[inNumber.Text.Length - 1] == '+' || inNumber.Text[inNumber.Text.Length - 1] == '-')
                    {
                        ctrl.Feditor.numer = "0"; ctrl.Feditor.denom = "1";
                        var str = ctrl.DoCommandFract(j).Split('|');
                        ctrl.Fprocessor.RightOp.number.numer = str[0];
                        ctrl.Fprocessor.RightOp.number.denom = str[1];
                        inNumber.Text += ctrl.Fprocessor.RightOp.NumberString;
                    }
                    else
                    {
                        if (divState == 0)
                        {
                            var str = ctrl.DoCommandFract(j).Split('|');
                            ctrl.Fprocessor.RightOp.number.numer = str[0];
                            ctrl.Fprocessor.RightOp.number.denom = str[1];

                            for (int i = 0; i < ctrl.Fprocessor.RightOp.NumberString.Length - 1; i++)
                            {
                                inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);
                            }
                        }

                        if (divState == 1)
                        {
                            if (ctrl.Fprocessor.RightOp.number.denom == "1" && divState1 != 1)
                            {
                                ctrl.Fprocessor.RightOp.number.denom = ctrl.Fprocessor.RightOp.number.denom.Remove(ctrl.Fprocessor.RightOp.number.denom.Length - 1);
                                for (int i = 0; i < ctrl.Fprocessor.RightOp.NumberString.Length + 1; i++)
                                {
                                    inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);
                                }
                                ctrl.Fprocessor.RightOp.number.denom += j.ToString();
                                divState1 = 1;
                            }
                            else
                            {
                                for (int i = 0; i < ctrl.Fprocessor.RightOp.NumberString.Length; i++)
                                {
                                    inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);
                                }
                                ctrl.Fprocessor.RightOp.number.denom += j.ToString();
                            }
                        }

                        inNumber.Text += ctrl.Fprocessor.RightOp.NumberString;
                    }
                }

                if (ResultState == 2)
                {
                    var str = ctrl.DoCommandFract(j).Split('|');
                    ctrl.Fprocessor.LeftOp.number.numer = str[0];
                    ctrl.Fprocessor.LeftOp.number.denom = str[1];
                    inNumber.Text = ctrl.Fprocessor.LeftOp.NumberString;
                }

                if (ResultState == 3)
                {
                    if (ctrl.Fprocessor.RightOp.NumberString != "0|1" && (inNumber.Text.Contains('/') || inNumber.Text.Contains('*') || inNumber.Text.Contains('+') || inNumber.Text.Contains('-')))
                    {
                        ctrl.Feditor.State = 1;
                        ctrl.Feditor.number = ctrl.Fprocessor.RightOp.NumberString;
                        for (int i = 0; i < ctrl.Fprocessor.RightOp.NumberString.Length; i++)
                            inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);

                        ctrl.Fprocessor.RightOp.NumberString = ctrl.DoCommandFract(j);
                        inNumber.Text += ctrl.Fprocessor.RightOp.NumberString;
                    }
                    else
                    {
                        ctrl.Feditor.number = ctrl.Fprocessor.LeftOp.NumberString;
                        ctrl.Feditor.State = 0;
                        ctrl.Fprocessor.LeftOp.NumberString = ctrl.DoCommandFract(j);
                        inNumber.Text = ctrl.Fprocessor.LeftOp.NumberString;
                    }
                }

                if (ResultState == 4)
                {
                    if (ctrl.Fprocessor.RightOp.NumberString != "0|1" && (inNumber.Text.Contains('/') || inNumber.Text.Contains('*') || inNumber.Text.Contains('+') || inNumber.Text.Contains('-')))
                    {
                        ctrl.Feditor.State = 1;
                        ctrl.Feditor.number = ctrl.Fprocessor.RightOp.NumberString;
                        for (int i = 0; i < ctrl.Fprocessor.RightOp.NumberString.Length; i++)
                            inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);


                        ctrl.Fprocessor.RightOp.NumberString = ctrl.DoCommandFract(j);

                        var tmp = ctrl.Feditor.numer;
                        ctrl.Feditor.numer = ctrl.Feditor.denom;
                        ctrl.Feditor.denom = tmp;
                        inNumber.Text += ctrl.Fprocessor.RightOp.NumberString;
                    }
                    else
                    {
                        ctrl.Feditor.number = ctrl.Fprocessor.LeftOp.NumberString;
                        ctrl.Feditor.State = 0;
                        ctrl.Fprocessor.LeftOp.NumberString = ctrl.DoCommandFract(j);
                        var tmp = ctrl.Feditor.numer;
                        ctrl.Feditor.numer = ctrl.Feditor.denom;
                        ctrl.Feditor.denom = tmp;
                        inNumber.Text = ctrl.Fprocessor.LeftOp.NumberString;
                    }
                }
            }

            if (state == 3)
            {

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
            trackBar1.Value = Convert.ToByte(numericUpDown1.Value);
            this.UpdateP1();
        }
        //Выполняет необходимые обновления при смене ос. с.сч. р1.
        private void UpdateP1()
        {

            if (inNumber.Text.Contains('/') || inNumber.Text.Contains('*') || inNumber.Text.Contains('+') || inNumber.Text.Contains('-'))
            {
                if (state == 1)
                {
                    ctrl.editor.number = "0";
                    ctrl.processor.RightOp.number = "0";
                    ctrl.processor.LeftOp.number = "0";
                    ctrl.processor.Operation = 0;
                }

                inNumber.Text = "0";
            }

            NumberCache.Text = "";

            ButtonMC.Enabled = false;
            ButtonMR.Enabled = false;
            ButtonMPlus.Enabled = false;
            UpdateButtons();

            ctrl.processor.LeftOp.PInt = trackBar1.Value;
            ctl.Pout = trackBar1.Value;


            if (inNumber.Text != "0" && !inNumber.Text.Contains("-") && !inNumber.Text.Contains("+") && !inNumber.Text.Contains("/") && !inNumber.Text.Contains("*"))
                inNumber.Text = ctl.DoCmnd(19, inNumber.Text);
            else
                inNumber.Text = "0";

            ctrl.processor.LeftOp.number = inNumber.Text;
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

            }
            if ((int)e.KeyChar == 8)
                i = 17;
            if ((int)e.KeyChar == 13)
                i = 19;
            if ((int)e.KeyChar == 45)//minus
            {
                if (inNumber.Text != "0")
                {
                   
                }
                return;
            }

            if ((int)e.KeyChar == 43)//plus
            {
                if (inNumber.Text != "0")
                {
                  
                }
                return;
            }

            if ((int)e.KeyChar == 47)//div
            {
                if (inNumber.Text != "0")
                {
                  
                }
                    return;
            }

            if ((int)e.KeyChar == 42)//mult
            {
                if (inNumber.Text != "0")
                {
                 

                }
                return;
            }

            if ((int)e.KeyChar == 61)
            {
               
                return;
            }

            if ((int)e.KeyChar == 8)
            {
               
            }

            if ((i < ctl.Pin) || (i >= 16))
            {
       
     
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
            button1_Click_1(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1_Click_1(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1_Click_1(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button1_Click_1(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button1_Click_1(sender, e);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button1_Click_1(sender, e);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button1_Click_1(sender, e);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button1_Click_1(sender, e);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button1_Click_1(sender, e);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            button1_Click_1(sender, e);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            button1_Click_1(sender, e);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            button1_Click_1(sender, e);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            button1_Click_1(sender, e);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            button1_Click_1(sender, e);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            button1_Click_1(sender, e);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (state == 1 && inNumber.Text[inNumber.Text.Length - 1] != '.')
            {

                if (ResultState == 0)
                {
                    if (!ctrl.processor.LeftOp.number.Contains('.'))
                    {
                        ctrl.processor.LeftOp.number = ctrl.DoCommand(16);
                        inNumber.Text = ctrl.processor.LeftOp.number;
                        return;
                    }
                }

                if (ResultState == 1)
                {
                    if (inNumber.Text[inNumber.Text.Length - 1] != '/' && inNumber.Text[inNumber.Text.Length - 1] != '*' && inNumber.Text[inNumber.Text.Length - 1] != '+' && inNumber.Text[inNumber.Text.Length - 1] != '-')
                    {
                        if (!ctrl.processor.RightOp.number.Contains('.'))
                        {
                            ctrl.processor.RightOp.number += ".";
                            inNumber.Text += ".";
                        }
                    }
                }
            }
    

        }


        private void button18_Click(object sender, EventArgs e)
        {
            if (state == 1)
            {
                if (inNumber.Text.Length != 1)
                {
                    if (inNumber.Text[inNumber.Text.Length - 1] == '+' || inNumber.Text[inNumber.Text.Length - 1] == '/' || inNumber.Text[inNumber.Text.Length - 1] == '*' || inNumber.Text[inNumber.Text.Length - 1] == '-')
                    {
                        inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);
                        ResultState = 0;
                        ctrl.processor.Operation = 0;
                    }
                    else
                    {
                        if (ctrl.processor.RightOp.number == "0" || (!inNumber.Text.Contains('/') && !inNumber.Text.Contains('*') && !inNumber.Text.Contains('+') && !inNumber.Text.Contains('-')))
                        {
                            ctrl.editor.number = ctrl.editor.number.Remove(ctrl.editor.number.Length - 1);
                            ctrl.processor.LeftOp.number = ctrl.processor.LeftOp.number.Remove(ctrl.processor.LeftOp.number.Length - 1);
                            inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);
                            return;
                        }

                        if (ctrl.processor.RightOp.number == "0" && (inNumber.Text.Contains('/') || inNumber.Text.Contains('*') || inNumber.Text.Contains('+') || inNumber.Text.Contains('-')))
                        {

                            inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);
                            return;
                        }

                        if (ctrl.processor.RightOp.number != "0")
                        {
                            ctrl.processor.RightOp.number = ctrl.processor.RightOp.number.Remove(ctrl.processor.RightOp.number.Length - 1);
                            inNumber.Text = inNumber.Text.Remove(inNumber.Text.Length - 1);
                            if (ResultState == 0) ctrl.editor.number = ctrl.editor.number.Remove(ctrl.editor.number.Length - 1);
                            return;
                        }
                    }

                }
                else
                {

                    ctrl.editor.number = "0";
                    ctrl.processor.RightOp.number = "0";
                    ctrl.processor.LeftOp.number = "0";
                    ctrl.processor.Operation = 0;
                    inNumber.Text = "0";
                }

            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (state == 1)
            {
                ctrl.editor.number = "0";
                ctrl.processor.RightOp.number = "0";
                ctrl.processor.LeftOp.number = "0";
                ctrl.processor.Operation = 0;
                inNumber.Text = "0";
                return;
            }

            if (state == 2)
            {
                ResultState = 0;
                divState = 0;
                divState1 = 0;
                inNumber.Text = "0|1";
                ctrl.Feditor.number = ctrl.Feditor.Clear();
                ctrl.Fprocessor.LeftOp.number.denom = "1";
                ctrl.Fprocessor.LeftOp.number.numer = "0";
                ctrl.Fprocessor.RightOp.number.denom = "1";
                ctrl.Fprocessor.RightOp.number.numer = "0";
                return;
            }

            if (state == 3)
            {

            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (inNumber.Text.Contains('+'))
            {
                if (ctrl.processor.Operation == 1) ctrl.processor.Operation = 2;
                inNumber.Text = inNumber.Text.Replace("+", "-");
                return;
            }

            if (inNumber.Text.Contains('-'))
            {
                if (ctrl.processor.Operation == 2) ctrl.processor.Operation = 1;
                inNumber.Text = inNumber.Text.Replace("-", "+");
            }
        }

        private void Конвертор_Load(object sender, EventArgs e)
        {

            inNumber.Text = "0";
            ButtonMC.Enabled = false;
            ButtonMR.Enabled = false;
            ButtonMPlus.Enabled = false;
            trackBar1.Value = 10;
            numericUpDown1.Value = 10;

            //состояния - калькулятор p-ичных чисел
            state = 1;

            //Обновить состояние командных кнопок.
            UpdateButtons();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (state == 1)
            {
                if (ctrl.processor.Operation != 0)
                {

                    if (inNumber.Text[inNumber.Text.Length - 1] == '+' || inNumber.Text[inNumber.Text.Length - 1] == '-' || inNumber.Text[inNumber.Text.Length - 1] == '*' || inNumber.Text[inNumber.Text.Length - 1] == '/')
                    {
                        ctrl.processor.RightOp.number = ctrl.processor.LeftOp.number;

                    }
                    ResultState = 0;
                    DoCmnd(40);
                }

            }

            if (state == 2)
            {
                if (ctrl.Fprocessor.Operation != 0)
                {
                    if (inNumber.Text[inNumber.Text.Length - 1] == '+' || inNumber.Text[inNumber.Text.Length - 1] == '-' || inNumber.Text[inNumber.Text.Length - 1] == '*' || inNumber.Text[inNumber.Text.Length - 1] == '/')
                    {
                        ctrl.Fprocessor.RightOp.NumberString = ctrl.Fprocessor.LeftOp.NumberString;
                        ResultState = 0;
                    }

                    ResultState = 2;
                    DoCmnd(40);
                    ResultState = 0;

                }
            }
        }

        private void ButtonPlus_Click(object sender, EventArgs e)
        {
            if (state == 1)
            {
                if (inNumber.Text.Contains('/') || inNumber.Text.Contains('*') || inNumber.Text.Contains('+') || inNumber.Text.Contains('-'))
                {
                    ResultState = 2;



                    if (inNumber.Text.Contains('/')) ctrl.processor.Operation = 4;
                    if (inNumber.Text.Contains('*')) ctrl.processor.Operation = 3;
                    if (inNumber.Text.Contains('+')) ctrl.processor.Operation = 1;
                    if (inNumber.Text.Contains('-')) ctrl.processor.Operation = 2;


                    DoCmnd(40);

                    ResultState = 0;
                }

                if (ResultState == 0)
                {
                    inNumber.Text += "+";
                    ResultState = 1;
                }

                else
                {
                    ResultState = 2;
                    DoCmnd(40);
                    inNumber.Text += "+";
                    ResultState = 1;
                }

                ctrl.processor.Operation = 1;

                return;
            }

            if (state == 2)
            {
                if (inNumber.Text.Contains('/') || inNumber.Text.Contains('*') || inNumber.Text.Contains('+') || inNumber.Text.Contains('-') && !inNumber.Text.StartsWith("-"))
                {
                    ResultState = 2;



                    if (inNumber.Text.Contains('/')) ctrl.Fprocessor.Operation = 4;
                    if (inNumber.Text.Contains('*')) ctrl.Fprocessor.Operation = 3;
                    if (inNumber.Text.Contains('+')) ctrl.Fprocessor.Operation = 1;
                    if (inNumber.Text.Contains('-') && !inNumber.Text.StartsWith("-")) ctrl.Fprocessor.Operation = 2;


                    DoCmnd(40);

                    ResultState = 0;
                }

                if (ResultState == 0)
                {
                    inNumber.Text += "+";
                    divState = 0;
                    divState1 = 0;
                    ResultState = 1;
                }

                else
                {
                    ResultState = 2;
                    DoCmnd(40);
                    inNumber.Text += "+";
                    ResultState = 1;
                }

                ctrl.Fprocessor.Operation = 1;

                return;
            }
        }

        private void ButtonMinus_Click(object sender, EventArgs e)
        {

            if (state == 1)
            {
                if (inNumber.Text.Contains('/') || inNumber.Text.Contains('*') || inNumber.Text.Contains('+') || inNumber.Text.Contains('-'))
                {
                    ResultState = 2;



                    if (inNumber.Text.Contains('/')) ctrl.processor.Operation = 4;
                    if (inNumber.Text.Contains('*')) ctrl.processor.Operation = 3;
                    if (inNumber.Text.Contains('+')) ctrl.processor.Operation = 1;
                    if (inNumber.Text.Contains('-')) ctrl.processor.Operation = 2;


                    DoCmnd(40);

                    ResultState = 0;
                }

                if (ResultState == 0)
                {
                    inNumber.Text += "-";
                    ResultState = 1;
                }

                else
                {

                    ResultState = 2;
                    DoCmnd(40);
                    inNumber.Text += "-";
                    ResultState = 1;
                }

                ctrl.processor.Operation = 2;

                return;
            }

            if (state == 2)
            {
                if (inNumber.Text.Contains('/') || inNumber.Text.Contains('*') || inNumber.Text.Contains('+') || inNumber.Text.Contains('-') && !inNumber.Text.StartsWith("-"))
                {
                    ResultState = 2;

                    if (inNumber.Text.Contains('/')) ctrl.Fprocessor.Operation = 4;
                    if (inNumber.Text.Contains('*')) ctrl.Fprocessor.Operation = 3;
                    if (inNumber.Text.Contains('+')) ctrl.Fprocessor.Operation = 1;
                    if (inNumber.Text.Contains('-') && !inNumber.Text.StartsWith("-")) ctrl.Fprocessor.Operation = 2;


                    DoCmnd(40);

                    ResultState = 0;
                }

                if (ResultState == 0)
                {
                    inNumber.Text += "-";
                    divState = 0;
                    divState1 = 0;
                    ResultState = 1;
                }

                else
                {
                    ResultState = 2;
                    DoCmnd(40);
                    inNumber.Text += "-";
                    ResultState = 1;
                }

                ctrl.Fprocessor.Operation = 2;
                return;
            }

        }

        private void ButtonMult_Click(object sender, EventArgs e)
        {

            if (state == 1)
            {
                if (inNumber.Text.Contains('/') || inNumber.Text.Contains('*') || inNumber.Text.Contains('+') || inNumber.Text.Contains('-') && !inNumber.Text.StartsWith("-"))
                {
                    ResultState = 2;



                    if (inNumber.Text.Contains('/')) ctrl.processor.Operation = 4;
                    if (inNumber.Text.Contains('*')) ctrl.processor.Operation = 3;
                    if (inNumber.Text.Contains('+')) ctrl.processor.Operation = 1;
                    if (inNumber.Text.Contains('-') && !inNumber.Text.StartsWith("-")) ctrl.processor.Operation = 2;


                    DoCmnd(40);

                    ResultState = 0;
                }

                if (ResultState == 0)
                {
                    inNumber.Text += "*";
                    ResultState = 1;
                }

                else
                {

                    ResultState = 2;
                    DoCmnd(40);
                    inNumber.Text += "*";
                    ResultState = 1;
                }
                ctrl.processor.Operation = 3;
            }

            if (state == 2)
            {
                if (inNumber.Text.Contains('/') || inNumber.Text.Contains('*') || inNumber.Text.Contains('+') || inNumber.Text.Contains('-') && !inNumber.Text.StartsWith("-"))
                {
                    ResultState = 2;
                    if (inNumber.Text.Contains('/')) ctrl.Fprocessor.Operation = 4;
                    if (inNumber.Text.Contains('*')) ctrl.Fprocessor.Operation = 3;
                    if (inNumber.Text.Contains('+')) ctrl.Fprocessor.Operation = 1;
                    if (inNumber.Text.Contains('-') && !inNumber.Text.StartsWith("-")) ctrl.Fprocessor.Operation = 2;

                    DoCmnd(40);

                    ResultState = 0;
                }

                if (ResultState == 0)
                {
                    inNumber.Text += "*";
                    ResultState = 1;
                }

                else
                {

                    ResultState = 2;
                    DoCmnd(40);
                    inNumber.Text += "*";
                    ResultState = 1;
                }
                ctrl.Fprocessor.Operation = 3;
            }
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (state == 1)
            {
                if (inNumber.Text.Contains('/') || inNumber.Text.Contains('*') || inNumber.Text.Contains('+') || inNumber.Text.Contains('-') && !inNumber.Text.StartsWith("-"))
                {
                    ResultState = 2;



                    if (inNumber.Text.Contains('/')) ctrl.processor.Operation = 4;
                    if (inNumber.Text.Contains('*')) ctrl.processor.Operation = 3;
                    if (inNumber.Text.Contains('+')) ctrl.processor.Operation = 1;
                    if (inNumber.Text.Contains('-') && !inNumber.Text.StartsWith("-")) ctrl.processor.Operation = 2;


                    DoCmnd(40);

                    ResultState = 0;
                }

                if (ResultState == 0)
                {
                    inNumber.Text += "/";
                    ResultState = 1;
                }

                else
                {
                    ResultState = 2;
                    DoCmnd(40);
                    inNumber.Text += "/";
                    ResultState = 1;
                }
                ctrl.processor.Operation = 4;
            }
            if (state == 2)
            {
                if (inNumber.Text.Contains('/') || inNumber.Text.Contains('*') || inNumber.Text.Contains('+') || inNumber.Text.Contains('-') && !inNumber.Text.StartsWith("-"))
                {
                    ResultState = 2;



                    if (inNumber.Text.Contains('/')) ctrl.Fprocessor.Operation = 4;
                    if (inNumber.Text.Contains('*')) ctrl.Fprocessor.Operation = 3;
                    if (inNumber.Text.Contains('+')) ctrl.Fprocessor.Operation = 1;
                    if (inNumber.Text.Contains('-') && !inNumber.Text.StartsWith("-")) ctrl.Fprocessor.Operation = 2;


                    DoCmnd(40);

                    ResultState = 0;
                }

                if (ResultState == 0)
                {
                    inNumber.Text += "/";
                    ResultState = 1;
                }

                else
                {
                    ResultState = 2;
                    DoCmnd(40);
                    inNumber.Text += "/";
                    ResultState = 1;
                }
                ctrl.Fprocessor.Operation = 4;
            }
        }

        private void ButtonSQR_Click(object sender, EventArgs e)
        {
            ResultState = 3;
            DoCmnd(31);
            ResultState = 0;
        }

        private void Button1Delx_Click(object sender, EventArgs e)
        {
            ResultState = 4;
            DoCmnd(32);
            ResultState = 0;
        }

        private void ButtonMC_Click(object sender, EventArgs e)
        {
           
        }

        private void ButtonMS_Click(object sender, EventArgs e)
        {

           
        }

        private void ButtonMPlus_Click(object sender, EventArgs e)
        {
           
        }

        private void ButtonMR_Click(object sender, EventArgs e)
        {
           
        }

        private void pичныеЧислаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (state == 2)
            {
                trackBar1.Enabled = true;
                numericUpDown1.Enabled = true;
                button10.Enabled = false;
                ctrl.Fprocessor.Operation = 0;
                divState = 0;
            }

            if (state == 3)
            {

            }

            state = 1;
            ResultState = 0;
            inNumber.Text = "0";
            ctrl.editor.number = "0";
            ctrl.processor.RightOp.number = "0";
            ctrl.processor.LeftOp.number = "0";
            ctrl.processor.Operation = 0;
            trackBar1.Value = 10;
            numericUpDown1.Value = 10;
            UpdateButtons();
        }

        private void вставитьИзБуфераToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inNumber.Text = Clipboard.GetText();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            if (divState == 0) divState = 1;
            else divState = 0;
        }

        private void дробныеЧислаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            state = 2;
            trackBar1.Enabled = false;
            numericUpDown1.Enabled = false;
            trackBar1.Value = 10;
            button10.Enabled = true;
            numericUpDown1.Value = 10;
            UpdateButtons();
            inNumber.Text = "0|1";
        }

        private void копироватьВБуферToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(inNumber.Text);
        }



    }
}
