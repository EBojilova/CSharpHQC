namespace SOLID_and_Other_Principles
{
    using OpenClosedFileDownloadAfter;

    internal class SolidPrinciplesMain
    {
        public static void Main()
        {
            var file = new File();
            var music = new Music();
            var progressFile = new Progress(file);
            var progressMusic = new Progress(music);
        }
    }
}