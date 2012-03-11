VBPartial
=========

Download files from zips

Usage
-----

In your Visual Basic project, navigate to My Project > References > Add... > Browse > and select the VBPartial.dll

Then simply use the function **vbpartial**

Example:

```vbpartial("http://www.text.com/zippy.zip", "/folder/file.mp3", "C:\file.mp3")
```

This opens the zip file named **'zippy.zip'** and downloads the file **'/folder/file.mp3'** to **'C:\file.mp3'**

Credit
------

Most of the credit here goes to planetbeing for creating partial-zip in the first place.
The source for partial zip is located at https://github.com/planetbeing/partial-zip

The rest of the credit goes to GreggJTurner for creating the C# version of partial-zip which I then used to create this version.
