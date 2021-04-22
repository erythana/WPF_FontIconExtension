[MarkupExtensionReturnType(typeof(DrawingImage))]
public class IconImageExtension : StaticResourceExtension
{
    // Initial code from 
    // https://stackoverflow.com/questions/62936619/how-to-set-a-segoe-mdl-font-icon-as-image-source-in-wpf
    // -----------------------------------------------------------------------------------------------------------------------------------
    // -- Implemented support for FontLigatures which is, for example, available in Google's MaterialIcons: https://fonts.google.com/icons
    // -----------------------------------------------------------------------------------------------------------------------------------

    private static readonly FontFamily FontFamily = new FontFamily(new Uri("pack://application:,,,/font/MaterialIcons-Regular.ttf"), "./#Material Icons");
    //private static readonly FontFamily FontFamily = new FontFamily(new Uri("pack://application:,,,/font/FluentSystemIcons-Regular.ttf"), "./#FluentSystemIcons-Regular");

    /// <summary>
    /// The numerical representation of the symbol, for example 'e8dc' or 59612
    /// </summary>
    public int IconCodePoint { get; set; }

    /// <summary>
    /// The Ligature name of the icon, for example 'thumb_up'
    /// </summary>
    public string IconLigatureName { get; set; }

    /// <summary>
    /// The Size of the icon
    /// </summary>
    public double IconSize { get; set; } = 16;

    /// <summary>
    /// The markup extension to convert the input to a <see cref="DrawingImage" />
    /// </summary>
    /// <param name="serviceProvider"></param>
    /// <returns></returns>
    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        var textBlock = new TextBlock
        {
            FontFamily = FontFamily,
            Text = string.IsNullOrEmpty(IconLigatureName)
                ? char.ConvertFromUtf32(IconCodePoint)
                : GetUtf32RepresentationFromString(IconLigatureName)
        };

        var brush = new VisualBrush
        {
            Visual = textBlock,
            Stretch = Stretch.Uniform
        };

        var drawing = new GeometryDrawing
        {
            Brush = brush,
            Geometry = new RectangleGeometry(
                new Rect(0, 0, IconSize, IconSize))
        };
        return new DrawingImage(drawing);

        string GetUtf32RepresentationFromString(string input) =>
            Encoding.UTF32.GetString(Encoding.UTF32.GetBytes(input));
    }
}
