using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Guess_the_number
{
    public partial class Form1 : Form
    {
        public static int count = 0;
        private int randomnum;
        private int users_last_guess;
        private int usersguess;
       
        public Form1()
        {
            InitializeComponent();
            genrandom();
        }
        private void genrandom()
        {
            Random random = new Random();
            randomnum = random.Next(1, 1001);
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = System.Drawing.Color.White;
            panel1.BackColor = System.Drawing.Color.White;
            textBox1.Enabled = true;
            textBox1.Text = "";
            genrandom();
            label5.Text = "";
            label5.Text = "";
            label4.Text = "";
            label1.Text = "I Have A Number Between 1 And 1000 — You'll Never Be Able to Guess it Mwahaa!";
            textBox1.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {   
            count++;
            label6.Text = "Amount of Guesses\n" +
                "You've Conducted: " + count;
            label2.Text = "Wrong Again! You'll Never Get it,\n" +
                          "Ha! But Enter Another Number To Try\n" +
                          " Again If You Insist....";
            label5.Text = "";
            try
            {   label4.Text = "Blue : Further than your previous guess \n" +
                                 "Red : Closer than your previous guess";
                if (Convert.ToInt32(textBox1.Text) == 0 || (Convert.ToInt32(textBox1.Text) > 1000))
                {
                    label4.Text = "";
                    label_highlow.Text = "";
                    label5.Text = "Hmm.. guess something \n" +
                        "between 1-1000. Because you Defnitely\n" +
                        "Just Wasted a Guess!!"; 
                    label2.Text = "Please enter a number below:"; return;
                }
                label4.Text = "Blue : Further than your previous guess \n" +
                                 "Red : Closer than your previous guess";
                usersguess = Convert.ToInt32(textBox1.Text);
                if (usersguess == randomnum)
                {
                    panel1.BackColor = System.Drawing.Color.Green;
                    msg m = new msg();
                    m.Show();
                    textBox1.Enabled = false;
                    label_highlow.Text = "";
                    label5.Text = "";
                    label4.Text = "";
                    label2.Text = "Hey, You actually Got It! Darnit!\n" +
                                  "Want to Play Again??? No Way You\n" +
                                  "Can Do it Twice...";
                    label1.Text = "";
                    count = 0;
                }
                int users_accuracy = Math.Abs(randomnum - usersguess);
                int users_last_accuracy = Math.Abs(randomnum - users_last_guess);
                if (users_accuracy < users_last_accuracy)
                {
                    textBox1.BackColor = System.Drawing.Color.Red;
                }
                if (users_accuracy > users_last_accuracy)
                {
                    textBox1.BackColor = System.Drawing.Color.Blue;
                }
                if (usersguess > randomnum)
                {
                    label_highlow.Text = "Ouch,Too High, Try Again!";
                }
                if (usersguess < randomnum)
                {
                    label_highlow.Text = "Oops, Too Low!";
                }
                users_last_guess = usersguess;
            }
            catch (Exception ex)
            {
                label5.Text = "Hmm.. Something Seems to Have\n" +
                    "Went Wrong With Your Input Try again, This\n" +
                    "Time, Be sure It's A Number And Not Text.\n" +
                    "You Just Wasted A Guess.";
                label4.Text = "";
                label_highlow.Text = "";
                label2.Text = "Please Enter A Number Below:";
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = randomnum.ToString();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
