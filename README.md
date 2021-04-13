# betterCaptcha | Uses Bitmap to create a picture of a captcha, very configurable. 

###### Example Code:
```csharp 
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Threading.Tasks;

string captchaCode = Program.captchaCode(5);
var captcha = Program.generateCaptchaImage(400, 200, HatchStyle.Percent90, captchaCode, new FontFamily("Hometown"), FontStyle.Underline, 110, HatchStyle.Percent90, 105, 104, 248, Color.Black);
captcha.Save("captcha.png");```

###### Example Captcha:
https://gyazo.com/8412de3111d92c584113568f7715f4d3
