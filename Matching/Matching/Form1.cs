using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matching
{
	public partial class Form1 : Form
	{
		Label firstClicked = null;
		Label secondClicked = null;
		Random rand = new Random();
		List<string> icons = new List<string>()
		{
			"!", "!", "A", "A", "B", "B", "C", "C",
			"D", "D", "E", "E", "F", "F", "G", "G"
		};
		public Form1()
		{
			InitializeComponent();
			AssignIconsToSquare();
		}
		private void AssignIconsToSquare()
		{



			foreach (Control control in tableLayoutPanel1.Controls)
			{
				Label iconLabel = control as Label;
				if(iconLabel != null)
				{
					int randomNumber = rand.Next(icons.Count);
					iconLabel.Text = icons[randomNumber];
					iconLabel.ForeColor = iconLabel.BackColor;
					icons.RemoveAt(randomNumber);
				}
			}
		} 

		private void label_click(object sender, EventArgs e)
		{
			if(timer1.Enabled == true)
			{
				return;
			}
			Label clickedLable = sender as Label;
			if(clickedLable != null)
			{
				if (clickedLable.ForeColor == Color.Black)
				{
					return;
				}
				//clickedLable.ForeColor = Color.Black;
				if (firstClicked == null)
				{
					firstClicked = clickedLable;
					firstClicked.ForeColor = Color.Black;
						return;
				}
				secondClicked = clickedLable;
				secondClicked.ForeColor = Color.Black;

				CheckForWinner();

				if(firstClicked.Text == secondClicked.Text)
				{
					firstClicked = null;
					secondClicked = null;
					return;
				}
				timer1.Start();
			}
		}

		private void CheckForWinner()
		{
			foreach(Control control in tableLayoutPanel1.Controls)
			{
				Label iconLabel = control as Label;
				if(iconLabel != null)
				{
					if(iconLabel.ForeColor == iconLabel.BackColor)
					{
						return;
					}
				}
			}
			MessageBox.Show("You found all the matching pictures");
			Close();
		}
		

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			timer1.Stop();
			firstClicked.ForeColor = firstClicked.BackColor;
			secondClicked.ForeColor = secondClicked.BackColor;
			firstClicked = null;
			secondClicked = null;

		}
	}
}
