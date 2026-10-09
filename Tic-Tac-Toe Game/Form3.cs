using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_Toe_Game.Properties;

namespace Tic_Tac_Toe_Game
{
    public partial class Form3 : Form
    {
        stGameStatus GameStatus;
        enPlayer PlayerTurn = enPlayer.Player1;
        enum enPlayer
        {
            Player1,
            Player2
        }

        enum enWinner
        {
            Player1,
            Player2,
            Draw,
            GameInProgress
        }

        struct stGameStatus
        {
            public enWinner Winner;
            public bool GameOver;
            public short PlayCount;

        }

        public Form3()
        {
            InitializeComponent();
        }

        public bool CheckValues(Button btn1, Button btn2, Button btn3)
        {


            if (btn1.Tag.ToString() != "?" && btn1.Tag.ToString() == btn2.Tag.ToString() && btn1.Tag.ToString() == btn3.Tag.ToString())
            {

                btn1.BackColor = Color.GreenYellow;
                btn2.BackColor = Color.GreenYellow;
                btn3.BackColor = Color.GreenYellow;

                if (btn1.Tag.ToString() == "X")
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
                else
                {
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }

            }

            GameStatus.GameOver = false;
            return false;


        }

        void EndGame()
        {

            lblTurn.Text = "Game Over";
            switch (GameStatus.Winner)
            {

                case enWinner.Player1:

                    lblWinner.Text = "Player1";
                    break;

                case enWinner.Player2:

                    lblWinner.Text = "Player2";
                    break;

                default:

                    lblWinner.Text = "Draw";
                    break;

            }

            MessageBox.Show("GameOver", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        public void CheckWinner()
        {


            //checked rows
            //check Row1
            if (CheckValues(btn1, btn2, btn3))
                return;

            //check Row2
            if (CheckValues(btn4, btn5, btn6))
                return;

            //check Row3
            if (CheckValues(btn7, btn8, btn9))
                return;

            //checked cols
            //check col1
            if (CheckValues(btn1, btn4, btn7))
                return;

            //check col2
            if (CheckValues(btn2, btn5, btn8))
                return;

            //check col3
            if (CheckValues(btn3, btn6, btn9))
                return;

            //check Diagonal

            //check Diagonal1
            if (CheckValues(btn1, btn5, btn9))
                return;

            //check Diagonal2
            if (CheckValues(btn3, btn5, btn7))
                return;


        }


        public void ChangeImage(Button btn)
        {

            if (btn.Tag.ToString() == "?")
            {
                switch (PlayerTurn)
                {
                    case enPlayer.Player1:
                        btn.Image = Resources.X;
                        PlayerTurn = enPlayer.Player2;
                        lblTurn.Text = "Player 2";
                        GameStatus.PlayCount++;
                        btn.Tag = "X";
                        CheckWinner();
                        break;
                    case enPlayer.Player2:
                        btn.Image = Resources.O;
                        PlayerTurn = enPlayer.Player1;
                        lblTurn.Text = "Player 1";
                        GameStatus.PlayCount++;
                        btn.Tag = "O";
                        CheckWinner();
                        break;
                }
            }

            else

            {
                MessageBox.Show("Wrong Choice", "Worng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (GameStatus.PlayCount == 9)
            {
                GameStatus.GameOver = true;
                GameStatus.Winner = enWinner.Draw;
                EndGame();
            }


        }

        private void Form3_Paint(object sender, PaintEventArgs e)
        {
            Color white = Color.FromArgb(255, 255, 255, 255);
            Pen whitePen = new Pen(white);
            whitePen.Width = 15;
            //whitePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            whitePen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            whitePen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            //draw Horizental lines
            e.Graphics.DrawLine(whitePen, 300, 170, 700, 170);
            e.Graphics.DrawLine(whitePen, 300, 300, 700 , 300);

            //draw Vertical lines
            e.Graphics.DrawLine(whitePen, 425, 70, 425, 400);
            e.Graphics.DrawLine(whitePen, 550, 70, 550, 400);
        }

        private void btn_Click(object sender, EventArgs e)
        {
            ChangeImage((Button)sender);
        }

        private void RestButton(Button btn)
        {
            btn.Image = Resources.question_mark_96;
            btn.Tag = "?";
            btn.BackColor = Color.Transparent;

        }
        private void RestartGame()
        {

           
            RestButton(btn1);
            RestButton(btn2);
            RestButton(btn3);
            RestButton(btn4);
            RestButton(btn5);
            RestButton(btn6);
            RestButton(btn7);
            RestButton(btn8);
            RestButton(btn9);

            PlayerTurn = enPlayer.Player1;
            lblTurn.Text = "Player 1";
            GameStatus.PlayCount = 0;
            GameStatus.GameOver = false;
            GameStatus.Winner = enWinner.GameInProgress;
            lblWinner.Text = "In Progress";



        }
       
        private void btnRestart_Click_1(object sender, EventArgs e)
        {
            RestartGame();
        }
    }
}
