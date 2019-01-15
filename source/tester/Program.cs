using System;
using System.IO;
using Nuke.Common.OutputSinks;

namespace tester
{
    class Program
    {
        static void Main(string[] args)
        {
            var fontDir = @"D:\Privat\hbre-nuke-common\source\Nuke.Common\OutputSinks\Fonts\";

            foreach (var font in new DirectoryInfo(fontDir).GetFiles("*.flf"))
            {
                string fontName = Path.GetFileNameWithoutExtension(font.FullName);
                var text = FigletTransform.GetText("Hallo Welt 0123456789!", fontName);

                Console.WriteLine(fontName);

                Console.WriteLine(text);
            }
        }
    }
}
