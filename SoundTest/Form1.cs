using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace SoundTest
{
    public partial class Form1 : Form
    {
        
        Button start,stop,exit;
        TextBox textBox1;
        Label Info;
        SoundPlayer play;
        public Form1()
        {
            start = new Button();
            this.Controls.Add(start);
            stop = new Button();
            this.Controls.Add(stop);
            exit = new Button();
            this.Controls.Add(exit);
            textBox1 = new TextBox();
            this.Controls.Add(textBox1);
            Info = new Label();
            this.Controls.Add(Info);

            this.Text = "声音测试";
            start.Text = "start";
            stop.Text = "stop";
            exit.Text = "exit";
            textBox1.Text = "1000 261.6";
            Info.Text = "OK";

            this.Size = new Size(100*3+50*5,50*4+30);

            start.Size = new Size(100,50);
            start.Location = new Point(50,50);
            stop.Size = new Size(100,50);
            stop.Location = new Point(50+100+50,50);
            exit.Size = new Size(100,50);
            exit.Location = new Point(50+100*2+50*2,50);
            
            textBox1.Location = new Point(50,50*3);
            textBox1.Width = 100*3+50*2;

            Info.Dock = DockStyle.Top;

            start.Click += new EventHandler(start_click);
            stop.Click += new EventHandler(stop_click);
            exit.Click += new EventHandler(exit_click);
        }
        public void start_click(object sender, EventArgs e)
        {
            string filePath = @"test.wav";
            // int amplitude = 32760;  // Max amplitude for 16-bit audio
            // double freq = 440.0f;   // Concert A: 440Hz
            string[] Input= textBox1.Text.Split(' ');
            WaveGenerator wave = new WaveGenerator(Convert.ToInt32(Input[0]),Convert.ToDouble(Input[1]));
            wave.Save(filePath);
            Info.Text = "制作完成";
            play = new SoundPlayer(filePath);
            play.Play();
            Info.Text = "正在播放";
        }
        public void stop_click(object sender, EventArgs e)
        {
            play.Stop();
            string[] Input= textBox1.Text.Split(' ');
            int amplitude = Convert.ToInt32(Input[0]);
            double freq = Convert.ToDouble(Input[1]);
            freq = freq * 1.05946*1.05946;
            textBox1.Text = amplitude.ToString()+" "+ freq.ToString();
            Info.Text = "已停止播放";
        }
        public void exit_click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
