# FontIconExtension for WPF
Similar to Xamarin.Forms FontImageSource. <br>
MarkupExtension to use FontIcons, for example the MaterialIcons or FluentUI Font with added Lignature support

Fonts can be access via CodePoint or Ligature-Name, see examples.

---
## Usage
* Copy the IconImageExtension into your project.
* Adjust the "FontFamily" and their paths to your needs
* Add the element to your XAML:
 ```c#
<Image Source="{local:IconImage IconLigatureName=thumb_up}" />
```
Result:
![alt text](https://github.com/erythana/WPF_FontIconExtension/blob/main/screenshot.png "Font ligature example")
---
## Properties
There are three properties in this Markup extension:
* IconLigatureName (String)
* IconCodePoint (Integer)
* IconSize (Integer, defaults to 16x16)

You either need to provide the IconLigatureName or the IconCodePoint to get a valid Icon. The IconLigatureName has precedence over the IconCodePoint.
