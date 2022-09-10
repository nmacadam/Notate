# Notate
A note component for your inspector.

![Example](/.github/example.png "Example")

Use the `Note` component to add in-inspector comments or documentation.  Edit the note contents by clicking and typing like any text field, and customize the icon by clicking on it.
You can further customize the following in by putting the inspector into Debug mode:
- Message alignment & anchoring
- Background color
- Icon (specify any built-in icon [by name](https://github.com/halak/unity-editor-icons))

`Note` components are not included in build.

## Installation
### Git
This package can be installed with the Unity Package Manager by selecting the add package dropdown, clicking "Add package from git url...", and entering `https://github.com/nmacadam/Notate.git#upm`.

Alternatively the package can be added directly to the Unity project's manifest.json by adding the following line:
```
{
  "dependencies": {
      ...
      "com.nmacadam.notate":"https://github.com/nmacadam/Notate.git#upm"
      ...
  }
}
```

### Manual
Download the [upm](https://github.com/nmacadam/Notate/tree/upm) branch of this repository as a .zip file and extract it, open the Unity Package Manager window, and select "Add package from disk...".  Then select the package.json in the extracted folder.