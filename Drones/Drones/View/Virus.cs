using AntiV.Helpers;
using AntiV.Properties;
using System.Drawing;

namespace AntiV
{
    public partial class Virus
    {


        public const int VIRUS_WIDTH = 90;
        public const int VIRUS_HEIGHT = 90;

        public void Render(BufferedGraphics drawingSpace)
        {

            drawingSpace.Graphics.DrawImage(Texture, _posX, _posY, VIRUS_WIDTH, VIRUS_HEIGHT);

            int barWidth = 10;
            int barHeight = VIRUS_HEIGHT;
            int barX = (int)_posX + VIRUS_WIDTH + 5;
            int barY = (int)_posY;

            float healthPercent = (float)Health / MaxHealth;
            int currentBarHeight = (int)(barHeight * healthPercent);

            Color healthColor = Color.FromArgb(
                (int)((1 - healthPercent) * 255),
                (int)(healthPercent * 255),
                0
            );

            using (var brush = new SolidBrush(healthColor))
                drawingSpace.Graphics.FillRectangle(brush, barX, barY + (barHeight - currentBarHeight), barWidth, currentBarHeight);

            drawingSpace.Graphics.DrawRectangle(Pens.Black, barX, barY, barWidth, barHeight);

            drawingSpace.Graphics.DrawString($"{Health} / {MaxHealth}", TextHelpers.drawFont, TextHelpers.writingBrush, barX - 10, barY + barHeight + 5);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
