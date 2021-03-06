﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class form1 : Form
    {
        int pipeSpeed = 8; // default pipe speed defined with an integer
        int gravity = 15; // default gravity speed defined with an integer
        int score = 0; // default score integer set to 0
        // variable ends
        

        public form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            Flappy.Top += gravity;
            Pipe.Left -= pipeSpeed;
            PipeDown.Left -= pipeSpeed;
            scoreboard.Text = "Score: " + score;

            if (Pipe.Left < -150)
            {
                // if the bottom pipes location is -150 then we will reset it back to 800 and add 1 to the score
                Pipe.Left = 800;
                score++;
            }
            if (PipeDown.Left < -180)
            {
                // if the top pipe location is -180 then we will reset the pipe back to the 950 and add 1 to the score
                PipeDown.Left = 950;
                score++;
            }

            // the if statement below is checking if the pipe hit the ground, pipes or if the player has left the screen from the top
            // the two pipe symbols stand for OR inside of an if statement so we can have multiple conditions inside of this if statement because its all going to do the same thing

            if (Flappy.Bounds.IntersectsWith(Pipe.Bounds) ||
                Flappy.Bounds.IntersectsWith(PipeDown.Bounds) ||
                Flappy.Bounds.IntersectsWith(pictureBox1.Bounds) || Flappy.Top < -25
                )
            {
                // if any of the conditions are met from above then we will run the end game function
                endGame();
            }


            // if score is greater then 5 then we will increase the pipe speed to 15
            if (score > 5)
            {
                pipeSpeed = 15;

            }

           


        }

        

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
               
                gravity = -15;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                
                gravity = 15;
            }
        }
        private void endGame()
        {
            // this is the game end function, this function will when the bird touches the ground or the pipes
            gameTimer.Stop(); // stop the main timer
            scoreboard.Text += " Game over!!!"; // show the game over text on the score text, += is used to add the new string of text next to the score instead of overriding it
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void scoreboard_Click(object sender, EventArgs e)
        {

        }
    }

}
  