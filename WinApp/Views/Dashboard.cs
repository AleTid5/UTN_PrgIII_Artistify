using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Repository;

namespace WinApp.Views
{
    public partial class Dashboard : UserControl
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        public void UpdateView()
        {
            this.txtMusicAdded.Text = (new MusicRepository()).GetRepositoryCount().ToString();
            this.txtVideosAdded.Text = (new VideoRepository()).GetRepositoryCount().ToString();
            this.txtBooksAdded.Text = (new BookRepository()).GetRepositoryCount().ToString();
            this.txtImagesAdded.Text = (new ImageRepository()).GetRepositoryCount().ToString();
            this.chartMedia.Series["Count"].Points.Clear();
            this.chartMedia.Series["Count"].Points.AddXY("Videos", this.txtVideosAdded.Text);
            this.chartMedia.Series["Count"].Points.AddXY("Music", this.txtMusicAdded.Text);
            this.chartMedia.Series["Count"].Points.AddXY("Libros", this.txtBooksAdded.Text);
            this.chartMedia.Series["Count"].Points.AddXY("Imagenes", this.txtImagesAdded.Text);
        }
    }
}
