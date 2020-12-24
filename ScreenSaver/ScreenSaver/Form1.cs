using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenSaver
{
	public partial class FormScreenSaver : Form
	{
		List<Image> BGImages = new List<Image>();
		List<Pics> BritPics = new List<Pics>();
		Random rand = new Random();
		
		class Pics
		{
			public int PicNum;
			public float x;
			public float y;
			public float Speed;

		}
		public FormScreenSaver()
		{
			InitializeComponent();
		}

		private void FormScreenSaver_Load(object sender, EventArgs e)
		{
			String[] images = System.IO.Directory.GetFiles("Pics");
			foreach(string image in images)
			{
				BGImages.Add(new Bitmap(image));
			}

			for (int i = 0; i < 1000; i++)
			{
				Pics mp = new Pics();
				mp.PicNum = i % BGImages.Count;
				mp.x = rand.Next(0, Width);
				mp.y = rand.Next(0, Height);

				BritPics.Add(mp);
			}
		}

		private void FormScreenSaver_KeyDown(object sender, KeyEventArgs e)
		{
			Close();
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			Refresh();

		}

		private void FormScreenSaver_Paint(object sender, PaintEventArgs e)
		{
			foreach (Pics bp in BritPics)
			{
				e.Graphics.DrawImage(BGImages[bp.PicNum], bp.x, bp.y);
				bp.x -= 2;

				if(bp.x < -250)
				{
					bp.x = Width + rand.Next(20, 100);
				}
			}
		}
	}
}
