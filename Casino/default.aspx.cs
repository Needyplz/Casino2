using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Casino
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewState.Add("PlayersMoney", 100);
                moneyLabel.Text = String.Format("Players Money: {0:C}", ViewState["PlayersMoney"].ToString());
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string[] images = new string[12];

            images[0] = "Bar";
            images[1] = "Bell";
            images[2] = "Cherry";
            images[3] = "Diamond";
            images[4] = "HorseShoe";
            images[5] = "Lemon";
            images[6] = "Clover";
            images[7] = "Orange";
            images[8] = "Plum";
            images[9] = "Seven";
            images[10] = "Strawberry";
            images[11] = "Watermellon";

            Random random = new Random();

            string firstImage = images[random.Next(12)];
            Image1.ImageUrl = "/Images/" + firstImage + ".png";

            string secondImage = images[random.Next(12)];
            Image2.ImageUrl = "/Images/" + secondImage + ".png";

            string thirdImage = images[random.Next(12)];
            Image3.ImageUrl = "/Images/" + thirdImage + ".png";

            int PlayersMoney = int.Parse(ViewState["PlayersMoney"].ToString());

            int bet = 0;

            if (!int.TryParse(betTextBox.Text, out bet)) return;

            PlayersMoney -= bet;

            if (firstImage == "Cherry" || secondImage == "Cherry" || thirdImage == "Cherry")
            {
                PlayersMoney += bet *= 2;
            }

            if (firstImage == "Bar" || secondImage == "Bar" || thirdImage == "Bar")
            {
                PlayersMoney += bet *= 0;
            }

            if (firstImage == "Seven" && secondImage == "Seven" && thirdImage == "Seven")
            {
                PlayersMoney += bet *= 100;
            }

            if (PlayersMoney < 0)
            {
                Response.Redirect("Lose.aspx");
            }

            moneyLabel.Text = String.Format("Player's Money: {0:C}", PlayersMoney);

            ViewState["PlayersMoney"] = PlayersMoney;
        }
    }
}