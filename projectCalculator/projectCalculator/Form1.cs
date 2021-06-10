//////////////////////////////////////////////////////////////////////////////////////////////||
//                          DESIGNED BY NAKONECHNUI DANIIL  PD- 22                            ||                                                                 
//                                                                                            ||  
//////////////////////////////////////////////////////////////////////////////////////////////||
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectCalculator
{

    enum Numeral 
    {
        BinToOct = 1,
        BinToDec = 2,
        BinToHex = 3,
        OctToBin = 4,
        OctToDec = 5,
        OctToHex = 6,
        DecToBin = 7,
        DecToOct = 8,
        DecToHex = 9,
        HexToBin = 10,
        HexToOct = 11,
        HexToDec = 12
    }


    public partial class Form1 : Form
    {

        
        private TabControl tabControl = new TabControl();
        private TabPage pageConvertor = null;
        private TabPage pageCalculator = null;
        private GroupBox groupBox_fromNumeral = null;
        private GroupBox groupBox_inNumeral = null;
        private Label label_original_value = null;
        private Label label_result = null;
        private TextBox textBox_original_value = null;
        private TextBox textBox_result = null;
        private RadioButton radioButton_fromBinaryNumeral = null;
        private RadioButton radioButton_fromOctNumeral = null;
        private RadioButton radioButton_fromDecNumeral = null;
        private RadioButton radioButton_fromHexNumeral = null;
        private RadioButton radioButton_inBinaryNumeral = null;
        private RadioButton radioButton_inOctNumeral = null;
        private RadioButton radioButton_inDecNumeral = null;
        private RadioButton radioButton_inHexNumeral = null;
        private Button button_calculated = null;

        private List<Button> buttons = new List<Button>();
        private TextBox textBoxValues = null;

        float firstValue = 0, secondValue = 0;
        int count;
        float valFloat = 0;

        Label labelText = null;

        //Functions
        public Form1()
        {
            InitializeComponent();
            initWidgetFormForPageCalculator();
            initWidgetsFormForPageConvertor();
            styleForWidgets();
            addWidgetsToForm();
        }

        //Init
        private void initWidgetFormForPageCalculator()
        {
            pageCalculator = new TabPage();
            pageCalculator.Text = "Калькулятор";
            tabControl.Controls.Add(pageCalculator);

            int x = 30, y = 20;
            for (int i = 0; i <= 18; i++)
            {
                buttons.Add(new Button());
            }
            for (int i = 0; i <= 18; i++)
            {
                buttons[i].Text = (i).ToString();
                buttons[i].Height = 70;
                buttons[i].Width = 90;

                if (i == 0 || i == 5 || i == 10 || i == 15)
                {
                    buttons[i].Location = new Point(x = 30, y += 70);
                }
                else
                {
                    buttons[i].Location = new Point(x += 90, y += 0);
                }

                if (i == 10)
                {
                    buttons[i].Text = "Конвертировать";
                }
                if (i == 11)
                {
                    buttons[i].Text = "Очистить";
                }
                if (i == 12)
                {
                    buttons[i].Text = "-";
                }
                if (i == 13)
                {
                    buttons[i].Text = "+";
                }
                if (i == 14)
                {
                    buttons[i].Text = "*";
                }
                if (i == 15)
                {
                    buttons[i].Text = "/";
                }
                if (i == 16)
                {
                    buttons[i].Text = ",";
                }
                if (i == 17)
                {
                    buttons[i].Text = "=";
                }
                if (i == 18)
                {
                    buttons[i].Text = "<---";
                }

                pageCalculator.Controls.Add(buttons[i]);
            }

            textBoxValues = new TextBox();
            textBoxValues.Height = 200;
            textBoxValues.Width = 800;
            pageCalculator.Controls.Add(textBoxValues);
            textBoxValues.Location = new Point(0, 0);
            textBoxValues.ReadOnly = true;

            labelText = new Label();
            labelText.Text = "";
            labelText.Width = 800;
            labelText.Height = 200;
            pageCalculator.Controls.Add(labelText);
            labelText.Location = new Point(0, 50);

            tabControl.Width = 600;
            tabControl.Height = 600;
        }
        private void initWidgetsFormForPageConvertor()
        {
            
            pageConvertor = new TabPage();
            pageConvertor.Text = "Конвертор";
            tabControl.TabPages.Add(pageConvertor);
           
            groupBox_fromNumeral = new GroupBox();
            groupBox_fromNumeral.Text = "Из системы счисления:";
            groupBox_fromNumeral.FlatStyle = FlatStyle.Flat;
            groupBox_fromNumeral.Location = new Point(20, 80);

            groupBox_inNumeral = new GroupBox();
            groupBox_inNumeral.Text = "В систему счисления:";
            groupBox_inNumeral.FlatStyle = FlatStyle.Flat;
            groupBox_inNumeral.Location = new Point(20, 200);

            label_original_value = new Label();
            label_original_value.Location = new Point(20, 20);
            label_original_value.Width = 200;
            label_original_value.Height = 20;
            label_original_value.Text = "Исходное значение:";

            label_result = new Label();
            label_result.Location = new Point(20, 360);
            label_result.Width = 100;
            label_result.Height = 20;
            label_result.Text = "Результат:";
            
            textBox_original_value = new TextBox();
            textBox_original_value.Location = new Point(20, 40);
            textBox_original_value.Width = 400;
            textBox_original_value.Height = 50;

            textBox_result = new TextBox();
            textBox_result.Location = new Point(20, 380);
            textBox_result.Width = 400;
            textBox_result.Height = 50;

            radioButton_fromBinaryNumeral = new RadioButton();
            radioButton_fromBinaryNumeral.Location = new Point(20, 20);
            radioButton_fromBinaryNumeral.Width = 150;
            radioButton_fromBinaryNumeral.Height = 20;
            radioButton_fromBinaryNumeral.Text = "Двоичной (Bin)";
            
            radioButton_fromOctNumeral = new RadioButton();
            radioButton_fromOctNumeral.Location = new Point(20, 40);
            radioButton_fromOctNumeral.Width = 150;
            radioButton_fromOctNumeral.Height = 20;
            radioButton_fromOctNumeral.Text = "Восьмеричной (Oct)";
            
            radioButton_fromDecNumeral = new RadioButton();
            radioButton_fromDecNumeral.Location = new Point(20, 60);
            radioButton_fromDecNumeral.Width = 150;
            radioButton_fromDecNumeral.Height = 20;
            radioButton_fromDecNumeral.Text = "Десятичной (Dec)"; 
            
            radioButton_fromHexNumeral = new RadioButton();
            radioButton_fromHexNumeral.Location = new Point(20, 80);
            radioButton_fromHexNumeral.Width = 200;
            radioButton_fromHexNumeral.Height = 20;
            radioButton_fromHexNumeral.Text = "Шестнадцатеричной (HEX)";
            
            radioButton_inBinaryNumeral = new RadioButton();
            radioButton_inBinaryNumeral.Location = new Point(20,20);
            radioButton_inBinaryNumeral.Width = 150;
            radioButton_inBinaryNumeral.Height = 20;
            radioButton_inBinaryNumeral.Text = "Двоичную (Bin)";
  
            radioButton_inOctNumeral = new RadioButton();
            radioButton_inOctNumeral.Location = new Point(20, 40);
            radioButton_inOctNumeral.Width = 150;
            radioButton_inOctNumeral.Height = 20;
            radioButton_inOctNumeral.Text = "Восьмеричную (Oct)";
       
            radioButton_inDecNumeral = new RadioButton();
            radioButton_inDecNumeral.Location = new Point(20, 60);
            radioButton_inDecNumeral.Width = 150;
            radioButton_inDecNumeral.Height = 20;
            radioButton_inDecNumeral.Text = "Десятичную (Dec)";
           
            radioButton_inHexNumeral = new RadioButton();
            radioButton_inHexNumeral.Location = new Point(20, 80);
            radioButton_inHexNumeral.Width = 200;
            radioButton_inHexNumeral.Height = 20;
            radioButton_inHexNumeral.Text = "Шестнадцатеричную (Hex)";
           
            button_calculated = new Button();
            button_calculated.Location = new Point(20,320);
            button_calculated.Width = 100;
            button_calculated.Height = 30;
            button_calculated.Text = "Выполнить";

        }

        private void styleForWidgets()
        {
           label_original_value.Font = new Font(label_original_value.Font, label_original_value.Font.Style 
                | FontStyle.Bold);
            label_result.Font = new Font(label_result.Font, label_result.Font.Style 
                | FontStyle.Bold);

            groupBox_fromNumeral.Font = new Font(groupBox_fromNumeral.Font, groupBox_fromNumeral.Font.Style
                | FontStyle.Bold);
            groupBox_inNumeral.Font = new Font(groupBox_inNumeral.Font, groupBox_inNumeral.Font.Style
                | FontStyle.Bold);

            textBoxValues.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold);

            labelText.Font = new Font("Microsoft Sans Serif", 15, FontStyle.Bold);

            for(int i = 0;i <= 18;i++)
            {
                buttons[i].Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            }
        }

        private void addWidgetsToForm()
        {

            this.Controls.Add(tabControl);

            pageConvertor.Controls.Add(label_original_value);
            pageConvertor.Controls.Add(label_result);

            pageConvertor.Controls.Add(textBox_original_value);
            pageConvertor.Controls.Add(textBox_result);

            groupBox_fromNumeral.Controls.Add(radioButton_fromBinaryNumeral);
            groupBox_fromNumeral.Controls.Add(radioButton_fromOctNumeral);
            groupBox_fromNumeral.Controls.Add(radioButton_fromDecNumeral);
            groupBox_fromNumeral.Controls.Add(radioButton_fromHexNumeral);
            pageConvertor.Controls.Add(groupBox_fromNumeral); 

      
            groupBox_inNumeral.Controls.Add(radioButton_inBinaryNumeral);
            groupBox_inNumeral.Controls.Add(radioButton_inOctNumeral);
            groupBox_inNumeral.Controls.Add(radioButton_inDecNumeral);
            groupBox_inNumeral.Controls.Add(radioButton_inHexNumeral);
            pageConvertor.Controls.Add(groupBox_inNumeral);

            pageConvertor.Controls.Add(button_calculated);

            
        }

    
        private void Form1_Load(object sender, EventArgs e)
        {
            button_calculated.Click += new EventHandler(button_calculated_Click); 
            
            buttons[0].Click += new EventHandler(button0_Click);
            buttons[1].Click += new EventHandler(button1_Click);
            buttons[2].Click += new EventHandler(button2_Click);
            buttons[3].Click += new EventHandler(button3_Click);
            buttons[4].Click += new EventHandler(button4_Click);
            buttons[5].Click += new EventHandler(button5_Click);
            buttons[6].Click += new EventHandler(button6_Click);
            buttons[7].Click += new EventHandler(button7_Click);
            buttons[8].Click += new EventHandler(button8_Click);
            buttons[9].Click += new EventHandler(button9_Click);
            buttons[10].Click += new EventHandler(button10_Click);
            buttons[11].Click += new EventHandler(button11_Click);
            buttons[12].Click += new EventHandler(button12_Click);
            buttons[13].Click += new EventHandler(button13_Click);
            buttons[14].Click += new EventHandler(button14_Click);
            buttons[15].Click += new EventHandler(button15_Click);
            buttons[16].Click += new EventHandler(button16_Click);
            buttons[17].Click += new EventHandler(button17_Click);
            buttons[18].Click += new EventHandler(button18_Click);

        }

        private void button0_Click(object sender, EventArgs e)
        {
            textBoxValues.Text = textBoxValues.Text + 0;
            labelText.Text = labelText.Text + 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxValues.Text = textBoxValues.Text + 1;
            labelText.Text = labelText.Text + 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxValues.Text = textBoxValues.Text + 2;
            labelText.Text = labelText.Text + 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBoxValues.Text = textBoxValues.Text + 3;
            labelText.Text = labelText.Text + 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBoxValues.Text = textBoxValues.Text + 4;
            labelText.Text = labelText.Text + 4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBoxValues.Text = textBoxValues.Text + 5;
            labelText.Text = labelText.Text + 5;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBoxValues.Text = textBoxValues.Text + 6;
            labelText.Text = labelText.Text + 6;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBoxValues.Text = textBoxValues.Text + 7;
            labelText.Text = labelText.Text + 7;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBoxValues.Text = textBoxValues.Text + 8;
            labelText.Text = labelText.Text + 8;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBoxValues.Text = textBoxValues.Text + 9;
            labelText.Text = labelText.Text + 9;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                valFloat = float.Parse(textBoxValues.Text);
                int valInt = (int)valFloat;
                textBox_original_value.Text = valInt.ToString();
                MessageBox.Show(
                "Перейдите во вкладку 'Конвертор'",
                 "Сообщение");
            }
            catch(FormatException)
            {
                MessageBox.Show($"Unable to parse '{valFloat}'", "Error");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBoxValues.Clear();
            labelText.Text = "";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            firstValue = float.Parse(textBoxValues.Text);
            textBoxValues.Text = textBoxValues.Text + "-";
            labelText.Text = labelText.Text + '-';
            count = 2;
            textBoxValues.Clear();
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            firstValue = float.Parse(textBoxValues.Text);
            textBoxValues.Clear();
            textBoxValues.Text = textBoxValues.Text + "+";
            labelText.Text = labelText.Text + '+';
            count = 1;
            
        }

        private void button14_Click(object sender, EventArgs e)
        {
            firstValue = float.Parse(textBoxValues.Text);
            textBoxValues.Text = textBoxValues.Text + "*";
            labelText.Text = labelText.Text + '*';
            count = 3;
            
            textBoxValues.Clear();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            firstValue = float.Parse(textBoxValues.Text);
            textBoxValues.Text = textBoxValues.Text + "/";
            labelText.Text = labelText.Text + '/';
            count = 4;
            
            textBoxValues.Clear();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBoxValues.Text = textBoxValues.Text + ",";
            labelText.Text = labelText.Text + ',';
        }

        private void button17_Click(object sender, EventArgs e)
        {
            calculate();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            var text = textBoxValues.Text;
            if(textBoxValues.TextLength == 0)
            {

            }
            else
            {
                textBoxValues.Text = text.Remove(text.Length - 1);
                var textLabel = labelText.Text;
                labelText.Text = textLabel.Remove(textLabel.Length - 1);
            }
          
        }


        private void calculate()
        {
            switch(count)
            {
                case 1:
                    secondValue = firstValue + float.Parse(textBoxValues.Text);
                    textBoxValues.Text = secondValue.ToString();
                    labelText.Text = secondValue.ToString();
                    break;
                case 2:
                    secondValue = firstValue - float.Parse(textBoxValues.Text);
                    textBoxValues.Text = secondValue.ToString();
                    labelText.Text = secondValue.ToString();
                    break;
                case 3:
                    secondValue = firstValue * float.Parse(textBoxValues.Text);
                    textBoxValues.Text = secondValue.ToString();
                    labelText.Text = secondValue.ToString(); ;
                    break;
                case 4:
                    secondValue = firstValue / float.Parse(textBoxValues.Text);
                    textBoxValues.Text = secondValue.ToString();
                    labelText.Text = secondValue.ToString(); ;
                    break;

                default:
                    break;
            }
        }

        private void button_calculated_Click(object sender,System.EventArgs e)
        {
            check_numeral();
        }
        
        public void check_numeral() {
            string value = "";

            if (radioButton_fromBinaryNumeral.Checked == true
                && radioButton_inBinaryNumeral.Checked == true)
            {
                textBox_result.Text = textBox_original_value.Text;
            }

            if (radioButton_fromBinaryNumeral.Checked == true
                && radioButton_inOctNumeral.Checked == true)
            {
                value = textBox_original_value.Text;
                convertValue(value, Numeral.BinToOct);

            }

            if (radioButton_fromBinaryNumeral.Checked == true
                && radioButton_inDecNumeral.Checked == true)
            {
                value = textBox_original_value.Text;
                convertValue(value, Numeral.BinToDec);
            }

            if (radioButton_fromBinaryNumeral.Checked == true
                && radioButton_inHexNumeral.Checked == true)
            {
                value = textBox_original_value.Text;
                convertValue(value, Numeral.BinToHex);
            }

            if (radioButton_fromOctNumeral.Checked == true
                && radioButton_inBinaryNumeral.Checked == true)
            {
                value = textBox_original_value.Text;
                convertValue(value, Numeral.OctToBin);
            }

            if (radioButton_fromOctNumeral.Checked == true
                && radioButton_inOctNumeral.Checked == true)
            {
                value = textBox_original_value.Text;
                textBox_result.Text = value;
            }

            if (radioButton_fromOctNumeral.Checked == true
                && radioButton_inDecNumeral.Checked == true)
            {
                value = textBox_original_value.Text;
                convertValue(value, Numeral.OctToDec);

            }

            if (radioButton_fromOctNumeral.Checked == true
                && radioButton_inHexNumeral.Checked == true)
            {
                value = textBox_original_value.Text;
                convertValue(value, Numeral.OctToHex);
            }


            if (radioButton_fromDecNumeral.Checked == true
                && radioButton_inBinaryNumeral.Checked == true)
            {
                value = textBox_original_value.Text;
                convertValue(value, Numeral.DecToBin);
            }

            if (radioButton_fromDecNumeral.Checked == true
                && radioButton_inOctNumeral.Checked == true)
            {
                value = textBox_original_value.Text;
                convertValue(value, Numeral.DecToOct);
            }

            if (radioButton_fromDecNumeral.Checked == true
                && radioButton_inDecNumeral.Checked == true)
            {
                value = textBox_original_value.Text;
                textBox_result.Text = value;
            }

            if (radioButton_fromDecNumeral.Checked == true
                && radioButton_inHexNumeral.Checked == true)
            {
                value = textBox_original_value.Text;
                convertValue(value, Numeral.DecToHex);
            }

            if (radioButton_fromHexNumeral.Checked == true
                && radioButton_inBinaryNumeral.Checked == true)
            {
                value = textBox_original_value.Text;
                convertValue(value, Numeral.HexToBin);
            }

            if (radioButton_fromHexNumeral.Checked == true
                && radioButton_inOctNumeral.Checked == true)
            {
                value = textBox_original_value.Text;
                convertValue(value, Numeral.HexToOct);
            }

            if (radioButton_fromHexNumeral.Checked == true
               && radioButton_inDecNumeral.Checked == true)
            {
                value = textBox_original_value.Text;
                convertValue(value, Numeral.HexToDec);
            }

            if (radioButton_fromHexNumeral.Checked == true
                && radioButton_inHexNumeral.Checked == true)
            {
                value = textBox_original_value.Text;
                textBox_result.Text = value;
            }
        }

        void convertValue(string data, Numeral type)
        {
            int numeralFrom = 0;
            int numeralIn = 0;
            switch (type)
            {
                case Numeral.BinToOct:
                    numeralFrom = 2;
                    numeralIn = 8;
                    break;
                case Numeral.BinToDec:
                    numeralFrom = 2;
                    numeralIn = 10;
                    break;
                case Numeral.BinToHex:
                    numeralFrom = 2;
                    numeralIn = 16;
                    break;
                case Numeral.OctToBin:
                    numeralFrom = 8;
                    numeralIn = 2;
                    break;
                case Numeral.OctToDec:
                    numeralFrom = 8;
                    numeralIn = 10;
                    break;
                case Numeral.OctToHex:
                    numeralFrom = 8;
                    numeralIn = 16;
                    break;
                case Numeral.DecToBin:
                    numeralFrom = 10;
                    numeralIn = 2;
                    break;
                case Numeral.DecToOct:
                    numeralFrom = 10;
                    numeralIn = 8;
                    break;
                case Numeral.DecToHex:
                    numeralFrom = 10;
                    numeralIn = 16;
                    break;
                case Numeral.HexToBin:
                    numeralFrom = 16;
                    numeralIn = 2;
                    break;
                case Numeral.HexToOct:
                    numeralFrom = 16;
                    numeralIn = 8;
                    break;
                case Numeral.HexToDec:
                    numeralFrom = 16;
                    numeralIn = 10;
                    break;
            }

            try
            {
                long tmp = Convert.ToInt64(data, numeralFrom);
                string result_value = Convert.ToString(tmp, numeralIn);
                textBox_result.Text = result_value;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ошибка конвертации:" + exception.Message, "Error");

            }

        }
    }

    
 
}
