using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppRogovski
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TripsTrapsTrull : ContentPage
    {
        int move = 0;
        string whoseMove;
        string player1 = "x";
        string player2 = "o";
        string winState = "";

        public TripsTrapsTrull()
        {
            InitializeComponent();
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {

        }

        private void bt1(object sender, EventArgs e)
        {
            move += 1;
            PlayerMove();
            var button = (Xamarin.Forms.Button)sender;

            SetSign(button);
            DetectWin();
        }

        private void bt2(object sender, EventArgs e)
        {
            move += 1;
            PlayerMove();
            var button = (Xamarin.Forms.Button)sender;

            SetSign(button);
            DetectWin();
        }

        private void bt3(object sender, EventArgs e)
        {
            move += 1;
            PlayerMove();
            var button = (Xamarin.Forms.Button)sender;

            SetSign(button);
            DetectWin();
        }

        private void bt4(object sender, EventArgs e)
        {
            move += 1;
            PlayerMove();
            var button = (Xamarin.Forms.Button)sender;

            SetSign(button);
            DetectWin();
        }

        private void bt5(object sender, EventArgs e)
        {
            move += 1;
            PlayerMove();
            var button = (Xamarin.Forms.Button)sender;

            SetSign(button);
            DetectWin();
        }

        private void bt6(object sender, EventArgs e)
        {
            move += 1;
            PlayerMove();
            var button = (Xamarin.Forms.Button)sender;

            SetSign(button);
            DetectWin();
        }

        private void bt7(object sender, EventArgs e)
        {
            move += 1;
            PlayerMove();
            var button = (Xamarin.Forms.Button)sender;

            SetSign(button);
            DetectWin();
        }

        private void bt8(object sender, EventArgs e)
        {
            move += 1;
            PlayerMove();
            var button = (Xamarin.Forms.Button)sender;

            SetSign(button);
            DetectWin();
        }

        private void bt9(object sender, EventArgs e)
        {
            move += 1;
            PlayerMove();
            var button = (Xamarin.Forms.Button)sender;
            SetSign(button);
            DetectWin();
        }

        private Xamarin.Forms.Button FindButtonById(string automationId)
        {
            var grid = ttt;

            foreach (var child in grid.Children)
            {
                if (child is Xamarin.Forms.Button button && button.AutomationId == automationId)
                {
                    return button;
                }
            }

            return null;
        }

        private Xamarin.Forms.Label FindLabelById(string automationId)
        {
            var grid = ttt;

            foreach (var child in grid.Children)
            {
                if (child is Xamarin.Forms.Label label && label.AutomationId == automationId)
                {
                    return label;
                }
            }

            return null;
        }

        private void PlayerMove()
        {
            var label = FindLabelById("Label1");
            if (move % 2 == 0)
            {
                label.Text = "1p";
                whoseMove = "1p";
            }
            else if (move % 2 != 0)
            {
                label.Text = "2p";
                whoseMove = "2p";
            }
        }

        private void SetSign(Xamarin.Forms.Button button)
        {
            if (whoseMove == "1p")
            {
                button.Text = player1;
            }
            else if (whoseMove == "2p")
            {
                button.Text = player2;
            }
        }

        private void DetectWin()
        {
            var b1 = FindButtonById("Button1");
            var b2 = FindButtonById("Button2");
            var b3 = FindButtonById("Button3");
            var b4 = FindButtonById("Button4");
            var b5 = FindButtonById("Button5");
            var b6 = FindButtonById("Button6");
            var b7 = FindButtonById("Button7");
            var b8 = FindButtonById("Button8");
            var b9 = FindButtonById("Button9");
            if (b1.Text == "x" && b2.Text == "x" && b3.Text == "x" ||
                b4.Text == "x" && b5.Text == "x" && b6.Text == "x" ||
                b7.Text == "x" && b8.Text == "x" && b9.Text == "x" ||

                b1.Text == "x" && b4.Text == "x" && b7.Text == "x" ||
                b2.Text == "x" && b5.Text == "x" && b8.Text == "x" ||
                b3.Text == "x" && b6.Text == "x" && b9.Text == "x" ||

                b1.Text == "x" && b5.Text == "x" && b9.Text == "x" ||
                b3.Text == "x" && b5.Text == "x" && b7.Text == "x"
                )
            {
                winState = "x";
                ClearBoxes();
            }
            else if (b1.Text == "o" && b2.Text == "o" && b3.Text == "o" ||
                     b4.Text == "o" && b5.Text == "o" && b6.Text == "o" ||
                     b7.Text == "o" && b8.Text == "o" && b9.Text == "o" ||

                     b1.Text == "o" && b4.Text == "o" && b7.Text == "o" ||
                     b2.Text == "o" && b5.Text == "o" && b8.Text == "o" ||
                     b3.Text == "o" && b6.Text == "o" && b9.Text == "o" ||

                     b1.Text == "o" && b5.Text == "o" && b9.Text == "o" ||
                     b3.Text == "o" && b5.Text == "o" && b7.Text == "o"
                     )
            {
                winState = "o";
                ClearBoxes();
            }
        }

        private void ClearBoxes()
        {
            var b1 = FindButtonById("Button1");
            var b2 = FindButtonById("Button2");
            var b3 = FindButtonById("Button3");
            var b4 = FindButtonById("Button4");
            var b5 = FindButtonById("Button5");
            var b6 = FindButtonById("Button6");
            var b7 = FindButtonById("Button7");
            var b8 = FindButtonById("Button8");
            var b9 = FindButtonById("Button9");

            b1.Text = "";
            b2.Text = "";
            b3.Text = "";
            b4.Text = "";
            b5.Text = "";
            b6.Text = "";
            b7.Text = "";
            b8.Text = "";
            b9.Text = "";
        }
    }
}