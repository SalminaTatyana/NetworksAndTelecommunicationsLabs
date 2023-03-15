﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Sockets;
using System.Globalization;
using System.Text.Json;

namespace Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
           InitializeComponent();
           Setting();
        }

        Dictionary<int, char> DeISO = new Dictionary<int, char>()
        {
            {33,'!' },
            {34,'"' },
            {35,'#' },
            {36,'$' },
            {37,'%' },
            {38,'&' },
            {39, '\'' },
            {40,'(' },
            {41,')' },
            {42, '*'  },
            {43,'+' },
            {44,',' },
            {45,'-' },
            {46,'.' },
            {47,'/' },
            {48,'0' },
            {49,'1' },
            {50,'2' },
            {51,'3' },
            {52,'4' },
            {53,'5' },
            {54,'6' },
            {55,'7' },
            {56,'8' },
            {57,'9' },
            {58,':' },
            {59,';' },
            {60,'<' },
            {61,'=' },
            {62,'>' },
            {63,'?' },
            {64,'@' },
            {65,'A' },
            {66,'B' },
            {67,'C' },
            {68,'D' },
            {69,'E' },
            {70,'F' },
            {71,'G' },
            {72,'H' },
            {73,'I' },
            {74,'J' },
            {75,'K' },
            {76,'L' },
            {77,'M' },
            {78,'N' },
            {79,'O' },
            {80,'P' },
            {81,'Q' },
            {82,'R' },
            {83,'S' },
            {84,'T' },
            {85,'U' },
            {86,'V' },
            {87,'W' },
            {88,'X' },
            {89,'Y' },
            {90,'Z' },
            {91,'[' },
            {92,'\\'},
            {93,']' },
            {94,'^' },
            {95,'_' },
            {96,'`' },
            {97,'a' },
            {98,'b' },
            {99,'c' },
            {100,'d' },
            {101,'e' },
            {102,'f' },
            {103,'g' },
            {104,'h' },
            {105,'i' },
            {106,'j' },
            {107,'k' },
            {108,'l' },
            {109,'m' },
            {110,'n' },
            {111,'o' },
            {112,'p' },
            {113,'q' },
            {114,'r' },
            {115,'s' },
            {116,'t' },
            {117,'u' },
            {118,'v' },
            {119,'w' },
            {120,'x' },
            {121,'y' },
            {122,'z' },
            {123,'{' },
            {124,'|' },
            {125,'}' },
            {126,'~' },
            {160,' ' },
            {161,'Ё' },
            {162,'Ђ' },
            {163,'Ѓ' },
            {164,'Є' },
            {165,'Ѕ' },
            {166,'І' },
            {167,'Ї' },
            {168,'Ј' },
            {169,'Љ' },
            {170,'Њ' },
            {171,'Ћ' },
            {172,'¬' },
            {174,'Ў' },
            {175,'Џ' },
            {176,'А' },
            {177,'Б' },
            {178,'В' },
            {179,'Г' },
            {180,'Д' },
            {181,'Е' },
            {182,'Ж' },
            {183,'З' },
            {184,'И' },
            {185,'Й' },
            {186,'К' },
            {187,'Л' },
            {188,'М' },
            {189,'Н' },
            {190,'О' },
            {191,'П' },
            {192,'Р' },
            {193,'С' },
            {194,'Т' },
            {195,'У' },
            {196,'Ф' },
            {197,'Х' },
            {198,'Ц' },
            {199,'Ч' },
            {200,'Ш' },
            {201,'Щ' },
            {202,'Ъ' },
            {203,'Ы' },
            {204,'Ь' },
            {205,'Э' },
            {206,'Ю' },
            {207,'Я' },
            {208,'а' },
            {209,'б' },
            {210,'в' },
            {211,'г' },
            {212,'д' },
            {213,'е' },
            {214,'ж' },
            {215,'з' },
            {216,'и' },
            {217,'й' },
            {218,'к' },
            {219,'л' },
            {220,'м' },
            {221,'н' },
            {222,'о' },
            {223,'п' },
            {224,'р' },
            {225,'с' },
            {226,'т' },
            {227,'у' },
            {228,'ф' },
            {229,'х' },
            {230,'ц' },
            {231,'ч' },
            {232,'ш' },
            {233,'щ' },
            {234,'ъ' },
            {235,'ы' },
            {236,'ь' },
            {237,'э' },
            {238,'ю' },
            {239,'я' },
            {240,'№' },
            {241,'ё' },
            {242,'ђ' },
            {243,'ѓ' },
            {244,'є' },
            {247,'ї' },
            {249,'љ' },
            {250,'њ' },
            {251,'ћ' },
            {252,'ќ' },
            {253,'§' },
            {254,'ў' },
            {255,'џ' }
        };
        Dictionary<char, int> ISO = new Dictionary<char, int>()
        {
            { '!', 33},
            { '"', 34},
            { '#', 35},
            {  '$',36},
            {  '%',37},
            {  '&',38},
            {'\'' ,39},
            {  '(',40},
            {  ')',41},
            {  '*',42},
            {  '+',43},
            { ',', 44},
            { '-', 45},
            { '.', 46},
            { '/', 47},
            { '0', 48},
            { '1', 49},
            { '2', 50},
            { '3', 51},
            { '4', 52},
            { '5', 53},
            { '6', 54},
            { '7', 55},
            { '8', 56},
            { '9', 57},
            { ':', 58},
            { ';', 59},
            { '<', 60},
            { '=', 61},
            { '>', 62},
            { '?', 63},
            { '@', 64},
            { 'A', 65},
            { 'B', 66},
            { 'C', 67},
            { 'D', 68},
            { 'E', 69},
            { 'F', 70},
            { 'G', 71},
            { 'H', 72},
            { 'I', 73},
            { 'J', 74},
            { 'K', 75},
            { 'L', 76},
            { 'M', 77},
            { 'N', 78},
            { 'O', 79},
            { 'P', 80},
            { 'Q', 81},
            { 'R', 82},
            { 'S', 83},
            { 'T', 84},
            { 'U', 85},
            { 'V', 86},
            { 'W', 87},
            { 'X', 88},
            { 'Y', 89},
            { 'Z', 90},
            { '[', 91},
            { '\\',92},
            { ']', 93},
            { '^', 94},
            { '_', 95},
            { '`', 96},
            { 'a', 97},
            { 'b', 98},
            { 'c', 99},
            {'d',100 },
            {'e',101 },
            {'f',102 },
            {'g',103 },
            {'h',104 },
            {'i',105 },
            {'j',106 },
            {'k',107 },
            {'l',108 },
            {'m',109 },
            {'n',110 },
            {'o',111 },
            {'p',112 },
            {'q',113 },
            {'r',114 },
            {'s',115 },
            {'t',116 },
            {'u',117 },
            {'v',118 },
            {'w',119 },
            {'x',120 },
            {'y',121 },
            {'z',122 },
            {'{',123 },
            {'|',124 },
            {'}',125 },
            {'~',126 },
            {' ',160 },
            {'Ё',161 },
            {'Ђ',162 },
            {'Ѓ',163 },
            {'Є',164 },
            {'Ѕ',165 },
            {'І',166 },
            {'Ї',167 },
            {'Ј',168 },
            {'Љ',169 },
            {'Њ',170 },
            {'Ћ',171 },
            {'¬',172 },
            {'Ў',174 },
            {'Џ',175 },
            {'А',176 },
            {'Б',177 },
            {'В',178 },
            {'Г',179 },
            {'Д',180 },
            {'Е',181 },
            {'Ж',182 },
            {'З',183 },
            {'И',184 },
            {'Й',185 },
            {'К',186 },
            {'Л',187 },
            {'М',188 },
            {'Н',189 },
            {'О',190 },
            {'П',191 },
            {'Р',192 },
            {'С',193 },
            {'Т',194 },
            {'У',195 },
            {'Ф',196 },
            {'Х',197 },
            {'Ц',198 },
            {'Ч',199 },
            {'Ш',200 },
            {'Щ',201 },
            {'Ъ',202 },
            {'Ы',203 },
            {'Ь',204 },
            {'Э',205 },
            {'Ю',206 },
            {'Я',207 },
            {'а',208 },
            {'б',209 },
            {'в',210 },
            {'г',211 },
            {'д',212 },
            {'е',213 },
            {'ж',214 },
            {'з',215 },
            {'и',216 },
            {'й',217 },
            {'к',218 },
            {'л',219 },
            {'м',220 },
            {'н',221 },
            {'о',222 },
            {'п',223 },
            {'р',224 },
            {'с',225 },
            {'т',226 },
            {'у',227 },
            {'ф',228 },
            {'х',229 },
            {'ц',230 },
            {'ч',231 },
            {'ш',232 },
            {'щ',233 },
            {'ъ',234 },
            {'ы',235 },
            {'ь',236 },
            {'э',237 },
            {'ю',238 },
            {'я',239 },
            {'№',240 },
            {'ё',241 },
            {'ђ',242 },
            {'ѓ',243 },
            {'є',244 },
            {'ї',247 },
            {'љ',249 },
            {'њ',250 },
            {'ћ',251 },
            {'ќ',252 },
            {'§',253 },
            {'ў',254 },
            {'џ',255 }
        };
        List<string> allStrTxt = new List<string>();
        List<byte[]> allStrBin = new List<byte[]>();
        IPAddress localAddress;
        int localPort;
        int remotePort;
        
        private void SaveBin(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlgBin = new Microsoft.Win32.SaveFileDialog();
            dlgBin.FileName = "Document"; // Default file name
            dlgBin.DefaultExt = ".bin"; // Default file extension
            dlgBin.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlgBin.ShowDialog();

            if (result == true)
            {
                string path = dlgBin.FileName;
                // создаем объект BinaryWriter
                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Append)))
                {
                    foreach (var item in allStrBin)
                    {
                        writer.Write(item);
                    }
                }
                allStrBin.Clear();
            }
        }
        public async void Setting()
        {
            try
            {
                using (FileStream fs = new FileStream("appsetting.json", FileMode.OpenOrCreate))
                {
                    Connection connection = await JsonSerializer.DeserializeAsync<Connection>(fs);
                    if (!String.IsNullOrEmpty(connection.ip))
                    {
                        localAddress = IPAddress.Parse(connection.ip);
                        remotePort = connection.remotePort;
                        localPort = connection.localPort;
                        ip.Text = localAddress.ToString();
                        port.Text = remotePort.ToString();
                        portLocal.Text = localPort.ToString();
                    }
                }
            }
            catch (JsonException ex)
            {

                histoty.Items.Add("Ошибка считывания json");
            }
            catch (Exception ex)
            {

                histoty.Items.Add(ex);
            }

        }
        
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[0-9]");
            e.Handled = !regex.IsMatch(e.Text);
        }
        private void IPValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            bool isHandled = true;
            Regex regex2 = new Regex("[0-9.]");
            if (regex2.IsMatch(e.Text))
            {
                isHandled = false;
            }
            e.Handled = isHandled;
        }
        private async void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                await SendMessageAsync();
            }
        }
        private async void SaveUDPData(object sender, RoutedEventArgs e)
        {
            try
            {
               
                localAddress = IPAddress.Parse(ip.Text);
                remotePort = Int32.Parse(port.Text);
                localPort = Int32.Parse(portLocal.Text);

                if (Int32.Parse(portLocal.Text) > 65535)
                {
                    throw new OverflowException("Слишком большое число в локальном порте. Используется локальный порт не более 65535");
                }
                
                if (Int32.Parse(port.Text) > 65535)
                {
                    throw new OverflowException("Слишком большое число в удаленном порте. Используется удаленный порт не более 65535");
                }
                saveUDPDataBtn.IsEnabled = false;
                sendUDPDataBtn.IsEnabled = true;
                inText.IsEnabled = true;
                ip.IsEnabled = false;
                port.IsEnabled = false;
                histoty.Items.Add("Подключение");
                await ReceiveMessageAsync();
                
            }
            catch (ArgumentNullException ex)
            {
                if (String.IsNullOrEmpty(ip.Text))
                {
                    histoty.Items.Add("Ip адрес не введен, введите Ip адрес.");
                }
                if (String.IsNullOrEmpty(portLocal.Text))
                {
                    histoty.Items.Add("Локальный порт не введен, введите локальный порт");
                }
                if (String.IsNullOrEmpty(port.Text))
                {
                    histoty.Items.Add("Удаленный порт не введен, введите локальный порт");
                }
            } 
            catch (FormatException ex)
            {
                if (ex.TargetSite.DeclaringType.Name== "IPAddressParser")
                {
                    histoty.Items.Add("Ip адрес имеет неправильный тип, введите Ip адрес по примеру: 127.0.0.1");

                }
                if (ex.TargetSite.DeclaringType.Name == "Number")
                {
                    histoty.Items.Add("Порты имеют неправильный тип, введите порты по примеру: 55555");

                }

            }
            catch (OverflowException ex)
            {
                histoty.Items.Add(ex.Message);
            }
            catch (Exception ex)
            {
                histoty.Items.Add(ex.Message);
            }
        }
        // отправка сообщений
        async Task ReceiveMessageAsync()
        {
            string formattedDate = DateTime.Now.ToString("dd.MM.yyyy_hh-mm-ss");
            string path = formattedDate + ".txt";
            using UdpClient receiver = new UdpClient(localPort);
            histoty.Items.Add("Прослушивание порта "+localPort);
            while (true)
            {
                string str = "";
                string strCode = "";
                string strBin = "";
                
                string strDecode = "";

                // получаем данные
                var result = await receiver.ReceiveAsync();
                var message = result.Buffer;
                byte[] strBin2 = new byte[message.Length];
                // выводим сообщение
                int j = 0;
                foreach (var item in message)
                {
                    str = str + item.ToString() + " ";
                    strCode = strCode + (char)item;
                    strBin = strBin + Convert.ToString(item,2) + " ";
                    strBin2[j] = item;
                    strDecode = strDecode + DeISO[item];
                    j++;
                }

                outText.Text = outText.Text+"Собеседник: " + strDecode+"\n";

                using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Append)))
                {
                    foreach (var item in strBin2)
                    {
                        writer.Write(item);
                    }
                }
            }
        }
        // отправка сообщений в группу
        async Task SendMessageAsync()
        {
            using UdpClient sender = new UdpClient();
            string str = inText.Text;
            byte[] codeStrBin = new byte[str.Length];
            int j = 0;
            foreach (char item in str)
            {
                if (ISO.ContainsKey(item))
                {
                    codeStrBin[j] = (byte)ISO[item];
                    j = j + 1;

                }
            }
            outText.Text = outText.Text + "Вы: " + str + "\n";
            await sender.SendAsync(codeStrBin, codeStrBin.Length, new IPEndPoint(localAddress, remotePort)); 
        }

        private async void SendUDPData(object sender, RoutedEventArgs e)
        {
            try
            {
                await SendMessageAsync();
                
            }
            catch (ArgumentOutOfRangeException)
            {
                histoty.Items.Add("Удаленный порт слишком большой, введите порт от 1024 до 65535");
            }
        }


        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            portLocal.Visibility = Visibility.Visible;
            localPortLable.Visibility = Visibility.Visible;
        }


    }
}
