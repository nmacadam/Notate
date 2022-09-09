# Notate
A note component for your inspector

Use the `Note` component to add in-inspector comments or documentation.  You can customize the note icon by right clicking, or by switching the inspector to Debug mode, and manually specifying a built in icon string.

## Installation
### Git
This package can be installed with the Unity Package Manager by selecting the add package dropdown, clicking "Add package from git url...", and entering `https://github.com/nmacadam/Notate.git`.

Alternatively the package can be added directly to the Unity project's manifest.json by adding the following line:
```
{
  "dependencies": {
      ...
      "com.bento.notate":"https://github.com/nmacadam/Notate.git"
      ...
  }
}
```
For either option, you can specify a specific release by appending `#<release>` to the URL.

### Manual
Download this repository as a .zip file and extract it, open the Unity Package Manager window, and select "Add package from disk...".  Then select the package.json in the extracted folder.