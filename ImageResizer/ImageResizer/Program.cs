namespace ImageResizer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Hello, enter the local folder to the images that you want to resize: ");

            var path = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentException("Path cannot be null or white space.");

            Console.Write("Enter width for the new images in pixels: ");
            var width = int.Parse(Console.ReadLine() ?? "150");
            if (width <= 0)
                throw new ArgumentException("Width must be a positive number.");

            Console.Write("Enter height for the new images in pixels: ");
            var height = int.Parse(Console.ReadLine() ?? "150");
            if (height <= 0)
                throw new ArgumentException("Height must be a positive number.");

            var pngFiles = Directory.GetFiles(path, "*.png");

            foreach (var file in pngFiles)
            {
                using (Image image = Image.Load(file))
                {
                    // Resize the image to the desired width and height
                    image.Mutate(x => x.Resize(new Size(width, height)));

                    // Save the resized image to a new file or stream

                    var finalName = file.Replace(".png", "_resized.png");
                    image.Save(finalName);
                }
            }
        }
    }
}