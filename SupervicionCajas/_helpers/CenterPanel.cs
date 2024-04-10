namespace SupervicionCajas._helpers
{
    public class CenterPanel : Panel
    {
        public CenterPanel(int width, int height)
        {
            var loadingPicture = new PictureBox();

            loadingPicture.Image = Properties.Resources.Spinner_1s_90px;
            loadingPicture.Location = new Point(0, 0);
            loadingPicture.Name = "pictureBox1";
            loadingPicture.Dock = DockStyle.Fill;
            loadingPicture.SizeMode = PictureBoxSizeMode.CenterImage;
            loadingPicture.TabIndex = 0;
            loadingPicture.TabStop = false;
            loadingPicture.UseWaitCursor = true;
            loadingPicture.AutoSize = true;


            AutoSize = true;
            BackColor = Color.White;
            Size = new Size(115, 115);
            BorderStyle = BorderStyle.FixedSingle;

            int x = (width - Width) / 2;
            int y = (height - Height) / 2;

            Location = new Point(x, y);

            Controls.Add(loadingPicture);
        }
    }
}