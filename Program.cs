using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Threading.Tasks;

namespace betterCaptcha {
    public class Program {
        public static Random rnd = new Random();
        public static Bitmap generateCaptchaImage(int width, int height, HatchStyle hatchStyle, string captchaText, FontFamily font, FontStyle fontStyle, int fontSize, HatchStyle hatchStyle2, int r, int g, int b, Color backGround) {
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Graphics graphic = Graphics.FromImage(bitmap);
            Rectangle rect = new Rectangle(0, 0, width, height);
            HatchBrush hatchBrush = new HatchBrush(hatchStyle, backGround, backGround);
            graphic.FillRectangle(hatchBrush, rect);
            GraphicsPath graphicPath = new GraphicsPath();
            graphicPath.AddString(captchaText, font, (int)fontStyle, fontSize, rect, null);
            hatchBrush = new HatchBrush(hatchStyle2, Color.FromArgb(r, g, b), Color.FromArgb(r, g, b));
            graphic.FillPath(hatchBrush, graphicPath);
            for (int i = 0; i < (int)(rect.Width * rect.Height / 250F); i++) {
                int x = rnd.Next(width);
                int y = rnd.Next(height);
                int w = rnd.Next(10);
                int h = rnd.Next(10);
                graphic.FillEllipse(hatchBrush, x, y, w, h);
            }
            hatchBrush.Dispose();
            graphic.Dispose();
            return bitmap;
        }
        public static string captchaCode(int length) {
            return new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToLower(), length).Select(s => s[rnd.Next(s.Length)]).ToArray());
        }
        public static List<FontFamily> fonts() {
            List<FontFamily> fontList = new List<FontFamily>();
            using (InstalledFontCollection data = new InstalledFontCollection()) {
                foreach (FontFamily fa in data.Families) {
                    fontList.Add(fa);
                }
            }
            return fontList;
        }
        static async Task Main(string[] args) {
            string captchaCode = Program.captchaCode(5);
            var captcha = Program.generateCaptchaImage(400, 200, HatchStyle.Percent90, captchaCode, new FontFamily("Hometown"), FontStyle.Underline, 110, HatchStyle.Percent90, 105, 104, 248, Color.Black);
            captcha.Save("captcha.png");
            foreach (var fonts in Program.fonts()) {
                Console.WriteLine(fonts);
            }
            await Task.Delay(-1);
        }
    }
}
